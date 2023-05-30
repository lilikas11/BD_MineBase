-- login
create function login(@email varchar(64), @senha varchar(16)) 
returns table
as
	return (
		select ID from Jogador where Email = @email and Senha = @senha
	)
go

-- Função para ver se o player tem esmeraldas
-- como usar: SELECT Personagem.Nome FROM Personagem WHERE dbo.PodeComprar(Personagem.ID) = 1
CREATE FUNCTION PodeComprar(@id_personagem int) RETURNS INT
as
    BEGIN
    DECLARE @status int

    IF (SELECT TOP 1 ID FROM Item WHERE ID_Personagem = @id_personagem AND ID_TipoItem = 81) IS NOT NULL
    BEGIN
        SET @status = 1;
    END
    ELSE
    BEGIN
        SET @status = 0;
    END

    RETURN @status
end
go

-- inventário
create function Inventário(@id_personagem int)
returns table
as
	return(
		select ID, Nome, Tipo from InventárioView where ID_Personagem = @id_personagem
	)
go

-- retorna todas as coisas do bioma pela escolha do id
create function BiomaFunction(@id_bioma int)
returns table
as
	return(
		select ID, Nome, Tipo FROM MundoView where ID_Bioma = @id_bioma
	)

go

-- Função para ver se o player tem arma
create function TemArma(@id_personagem int) returns int
as
	begin
	declare @status int
	
	-- isto tem de dar umas voltas imensas -> item -> tipoitem + armas->tipoitem
	if(select top 1 I.ID
		from Item I 
		Join TipoItem T on T.ID = I.ID_TipoItem
		Join Arma A on A.ID_TipoItem = T.ID) is not null
	BEGIN
        SET @status = 1;
    END
    ELSE
    BEGIN
        SET @status = 0;
    END

    RETURN @status
end
go

-- count de kills
-- vais ter de guardar isto numa var global pq quando reset o dia o morto por tbm reseta
create function kills(@id_personagem int)
returns int
as 
begin
	return(
		select COUNT(*) as KillsCount
			from Mob where MortoPor_ID_Personagem = @id_personagem
	)
	end
go

-- Pegar a info do Item
-- retorna o nome + tipo + propriedade1 + propriedade2 -> caso não tenha fica null, 
-- ex. o item comum retorna nome = <nome>, tipo = itemComum, propriedade1 = null, propriedade2 = null
create function ItemInfo(@id_item int)
returns table
as
	return(
	-- pega no id_item busca o id_tipo_item e dá show das props desse
		select TI.Nome,
			-- primeiro tenho de fazer o tipo 
			case when A.ID_TipoItem is not null AND A.ID_TipoItem = I.ID_TipoItem
				then 'Arma'
				when C.ID_TipoItem is not null AND C.ID_TipoItem = I.ID_TipoItem
				then 'Comida'
				when P.ID_TipoItem is not null AND P.ID_TipoItem = I.ID_TipoItem
				then 'Poção'
				else 'Item Comum'
				end
			as Tipo,
			-- agora as propriedades (propriedade 1 e 2, se não tiver vai null)
			case 
				when A.ID_TipoItem is not null then A.Durabilidade
				when C.ID_TipoItem is not null then C.Fome
				when P.ID_TipoItem is not null then P.Efeito
				end
			as Propriedade1,
			case
				when A.ID_TipoItem is not null then A.Dano
				when P.ID_TipoItem is not null then P.Tempo
			end
			as Propriedade2
			from Item I 
		inner join TipoItem TI on TI.ID = I.ID_TipoItem
		left join Arma A on A.ID_TipoItem = TI.ID
		left join Comida C on C.ID_TipoItem = TI.ID
		left join Pocao P on P.ID_TipoItem = TI.ID
		where I.ID = @id_item
	)
go

-- pegar a info do Bloco
create function BlocoInfo(@id_bloco int)
returns table
as
	return (
		select Nome, Dureza from Bloco where ID = @id_bloco
	)
go


-- pegar a info do Mob
-- retorna as infos + trabalho -> null se não for villager
create function MobInfo(@id_mob int)
returns table
as
	 return(
			SELECT M.Nome, M.Personalidade, M.Dano_Facil, M.Dano_Normal, M.Dano_Dificil, TI.Nome AS [Drop], 
				 V.Trabalho
			FROM Mob M
			left JOIN Villager V ON V.ID_Mob = M.ID
			left JOIN TipoItem TI ON TI.ID = M.ID_TipoItem
			WHERE M.ID = @id_mob
	 )
go


create function FiltroMundo(@id_bioma int, @tipo varchar(16))
returns table
as
	return (
		select ID, Nome, Tipo from MundoView where ID_Bioma = @id_bioma and 
			(Tipo = @tipo or (Tipo = 'villager' and @tipo = 'Mob'))
	)
go

-- filtra o inventario por bloco, item, arma, comida, poção, item comum
create function FiltroInventario(@id_personagem int, @tipo varchar(16))
returns table
as
	return(
		select ID, Nome from InventárioView IV where IV.ID_Personagem=@id_personagem and 
            (@tipo = 'bloco' AND EXISTS (
                SELECT *
                FROM Bloco B
				where Tipo = @tipo and ID = B.ID
            ))
            OR (@tipo = 'item' AND EXISTS (
                SELECT 1
                FROM Item I
                where Tipo = @tipo and ID = I.ID
            ))
            OR (@tipo = 'arma' AND EXISTS (
                SELECT 1
                FROM Arma A
                INNER JOIN Item I ON I.ID_TipoItem = A.ID_TipoItem
                WHERE Tipo = 'item' and I.ID = IV.ID
            ))
            OR (@tipo = 'comida' AND EXISTS (
                SELECT 1
                FROM Comida C
                INNER JOIN Item I ON I.ID_TipoItem = C.ID_TipoItem
                WHERE Tipo = 'item' and I.ID = IV.ID
            ))
            OR (@tipo = 'poção' AND EXISTS (
                SELECT 1
                FROM Pocao P
                INNER JOIN Item I ON I.ID_TipoItem = P.ID_TipoItem
                WHERE Tipo = 'item' and I.ID = IV.ID
            ))
            OR (@tipo = 'item comum' AND EXISTS (
                SELECT 1
                FROM ItemComum IC
                INNER JOIN Item I ON I.ID_TipoItem = IC.ID_TipoItem
                WHERE Tipo = 'item' and I.ID = IV.ID
            ))
	)
go


-- procura QUALQUER COISA no mundo
create function SearchMundo(@string varchar(128), @id_bioma int)
returns table
as
	return(
		select ID, Nome, Tipo from MundoView where ID_Bioma = @id_bioma and 
			(Nome like '%' + @string + '%' or Tipo like '%' + @string + '%')
			-- assim podes procurar só a string na palavra :)
	)
go


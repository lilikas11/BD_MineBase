Use MineBase
GO


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
		select ID, Nome from InventárioView where ID_Personagem = @id_personagem
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

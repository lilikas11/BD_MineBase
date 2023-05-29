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
CREATE FUNCTION Compra(@id_personagem int) RETURNS INT
as
    BEGIN
    DECLARE @status int;

    IF (SELECT TOP 1 ID FROM Item WHERE ID_Personagem = @id_personagem AND ID_TipoItem = 81) IS NOT NULL
    BEGIN
        -- Mob está vivo
        SET @status = 1;
    END
    ELSE
    BEGIN
        -- Mob está morto
        SET @status = 0;
    END

    RETURN @status;
go


-- inventário
create function Inventário(@id_personagem int)
returns table
as
	return(
		select ID, Nome from InventárioView where ID_Personagem = @id_personagem
	)
go

-- retorna todas as coisas do mundo
create function MundoFunction()
returns table
as
	return(
		select ID, Nome, Tipo FROM MundoView
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

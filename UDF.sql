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
CREATE FUNCTION Compra(@id_personagem int) RETURNS table
as
	return(SELECT TOP 1 ID FROM Item WHERE ID_Personagem = @id_personagem AND ID_TipoItem = 81)
go

-- ver se o mob tá vivo
CREATE FUNCTION Morto(@id_mob int) RETURNS int
AS
BEGIN
    DECLARE @status int;

    IF (SELECT ID_Bioma FROM Mob WHERE ID = @id_mob) IS NOT NULL
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
END;

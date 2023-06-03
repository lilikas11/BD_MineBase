Use MineBase
GO


-- DELETE WITH RELATIONSHIPS
CREATE TRIGGER Delete_Jogador ON Jogador
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Item WHERE ID_Personagem IN (SELECT ID FROM deleted);
    DELETE FROM Personagem WHERE ID_Jogador IN (SELECT ID FROM deleted);
    DELETE FROM Jogador WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Mundo ON Mundo
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Personagem WHERE Seed_Mundo IN (SELECT Seed FROM deleted);
    DELETE FROM Mundo WHERE Seed IN (SELECT Seed FROM deleted);
END
GO

CREATE TRIGGER Delete_Personagem ON Personagem
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Item WHERE ID_Personagem IN (SELECT ID FROM deleted);
    DELETE FROM Personagem WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Bioma ON Bioma
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Mob WHERE ID_Bioma IN (SELECT ID FROM deleted);
    DELETE FROM Bloco WHERE ID_Bioma IN (SELECT ID FROM deleted);
    DELETE FROM Bioma WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_TipoItem ON TipoItem
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Arma WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM Comida WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM Pocao WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM ItemComum WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM Item WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM Mob WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM Villager WHERE ID_TipoItem IN (SELECT ID FROM deleted);
    DELETE FROM TipoItem WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Item ON Item
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Item WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Mob ON Mob
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Mob WHERE MortoPor_ID_Personagem IN (SELECT ID FROM deleted);
    DELETE FROM Aquisicao WHERE ID_Villager IN (SELECT ID FROM deleted);
    DELETE FROM Mob WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Bloco ON Bloco
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Bloco WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Aquisicao ON Aquisicao
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Aquisicao WHERE ID IN (SELECT ID FROM deleted);
END
GO

CREATE TRIGGER Delete_Villager ON Villager
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Aquisicao WHERE ID_Villager IN (SELECT ID FROM deleted);
    DELETE FROM Villager WHERE ID IN (SELECT ID FROM deleted);
END
GO



-- Loggin
create trigger checkEmailJogador on Jogador for insert, update
as
	begin
		if(UPDATE(Email) and exists(select 1 from inserted where not Email like '%_@__%.__%') )
		begin
			raiserror('Insira um email válido', 16, 1);
			ROLLBACK;
		end
	end
go

create trigger checkIdioma on dbo.Jogador for insert, update
as
    DECLARE @ValidIdiomas VARCHAR(1000)
    SET @ValidIdiomas = 'Portugues, Ingles, Espanhol'
    
    IF (UPDATE(Idioma) AND EXISTS(SELECT 1 FROM inserted WHERE Idioma NOT IN (SELECT value FROM STRING_SPLIT(@ValidIdiomas, ','))))
    BEGIN
        RAISERROR('O idioma inserido não é válido', 16, 1);
        ROLLBACK;
    END
go




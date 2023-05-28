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
    DELETE FROM Aquisicao WHERE ID_Villager IN (SELECT ID_Mob FROM deleted);
    DELETE FROM MobComum WHERE ID_Mob IN (SELECT ID FROM deleted);
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
    DELETE FROM Aquisicao WHERE ID_Villager IN (SELECT ID_Mob FROM deleted);
    DELETE FROM Villager WHERE ID_Mob IN (SELECT ID_Mob FROM deleted);
END
GO



-- Add do Villager
CREATE PROCEDURE dbo.create_villager_with_mob (
    @v_nome VARCHAR(32),
    @v_personalidade VARCHAR(16),
    @v_id_bioma INT,
    @v_dano_facil INT,
    @v_dano_normal INT,
    @v_dano_dificil INT,
    @v_id_tipo_item INT,
    @v_trabalho VARCHAR(32),
    @v_id_tipo_item_villager INT
)
AS
BEGIN
    DECLARE @mob_id INT;

    INSERT INTO Mob(Nome, Personalidade, ID_Bioma, Dano_Facil, Dano_Normal, Dano_Dificil, ID_TipoItem, MortoPor_ID_Personagem)
    VALUES (@v_nome, @v_personalidade, @v_id_bioma, @v_dano_facil, @v_dano_normal, @v_dano_dificil, @v_id_tipo_item, NULL);

    SET @mob_id = SCOPE_IDENTITY();

    INSERT INTO Villager(ID_Mob, Trabalho, ID_TipoItem)
    VALUES (@mob_id, @v_trabalho, @v_id_tipo_item_villager);

END;

CREATE TRIGGER Add_Villager_Mob ON dbo.Villager for insert, update
as
	begin
		EXEC dbo.create_villager_with_mob 'New Mob', 'Personality', 1, 10, 20, 30, 1, 'Farmer', 2 ;
	end
go






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




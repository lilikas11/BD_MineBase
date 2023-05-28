USE MineBase
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

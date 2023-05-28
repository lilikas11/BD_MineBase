USE MineBase
GO


-- Add do Villager
CREATE PROCEDURE dbo.create_villager_with_mob (
    @v_id_bioma INT,
	@v_trabalho VARCHAR(32),
    @v_id_tipo_item INT
)
AS
BEGIN
    DECLARE @mob_id INT;

    INSERT INTO Mob(Nome, Personalidade, ID_Bioma, Dano_Facil, Dano_Normal, Dano_Dificil, ID_TipoItem, MortoPor_ID_Personagem)
    VALUES ('Villager', 'Passiva', @v_id_bioma, 0, 0,0, @v_id_tipo_item, NULL);

    SET @mob_id = SCOPE_IDENTITY();

    INSERT INTO Villager(ID_Mob, Trabalho, ID_TipoItem)
    VALUES (@mob_id, @v_trabalho, @v_id_tipo_item);

END;



-- compra villager (esta atualiza os elementos)
-- EXEC dbo.Compra <id_personagem> , <id_villager>
CREATE PROCEDURE EfetuaCompra(@id_personagem int, @id_villager int, @id_item int)
AS
BEGIN
    -- Remove a esmeralda
    DELETE FROM Item WHERE ID = @id_item;

    -- tipo item villager
    DECLARE @tipoItem int;
    SET @tipoItem = (SELECT ID_TipoItem FROM Villager WHERE ID_Mob = @id_villager);

    INSERT INTO Item VALUES (47, @tipoItem, @id_personagem);
END
GO

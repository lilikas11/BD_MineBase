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
-- EXEC dbo.EfetuaCompra <id_personagem> , <id_villager>
CREATE PROCEDURE EfetuaCompra(@id_personagem int, @id_villager int)
AS
BEGIN
    -- Remove a esmeralda
    DELETE FROM Item WHERE ID = (SELECT TOP 1 ID FROM Item WHERE ID_Personagem = @id_personagem AND ID_TipoItem = 81);

    -- tipo item villager
    DECLARE @tipoItem int;
    SET @tipoItem = (SELECT ID_TipoItem FROM Villager WHERE ID_Mob = @id_villager);

    INSERT INTO Item VALUES (@tipoItem, @id_personagem);
END
GO


-- matar o mobzito
CREATE PROCEDURE Matar(@id_personagem int, @id_mob int)
as
	begin
		-- matou
		UPDATE Mob
		SET ID_Bioma = NULL, MortoPor_ID_Personagem = @id_personagem
		where ID = @id_mob

		 -- tipo item villager
		DECLARE @tipoItem int;
		SET @tipoItem = (SELECT ID_TipoItem FROM Mob WHERE ID = @id_mob);
		if @tipoItem is not null
		begin
			INSERT INTO Item VALUES (@tipoItem, @id_personagem);
		end

	end
go

-- Fazer as acoes do minerar
CREATE procedure Minerar(@id_bloco int, @id_personagem int)
as
	begin
		-- matar bloco
			Update Bloco
			set ID_Bioma = NULL, 
			ID_Personagem = @id_personagem
			where ID = @id_bloco

	end
go

-- PassarDia
CREATE procedure PassarDia(@id_bioma int)
as
 begin
	update Mob
	set ID_Bioma = @id_bioma,
	MortoPor_ID_Personagem = null
	where ID_Bioma is null
 end
go

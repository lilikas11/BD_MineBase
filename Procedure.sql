
-- Add do Villager
CREATE PROCEDURE create_villager_with_mob (
    @v_id_bioma INT,
	@v_trabalho VARCHAR(32),
    @v_id_tipo_item INT
)
AS
BEGIN
    DECLARE @mob_id INT;
    	BEGIN TRANSACTION;
	BEGIN TRY
			INSERT INTO Mob(Nome, Personalidade, ID_Bioma, Dano_Facil, Dano_Normal, Dano_Dificil, ID_TipoItem, MortoPor_ID_Personagem)
			VALUES ('Villager', 'Passiva', @v_id_bioma, 0, 0,0, @v_id_tipo_item, NULL);

			SET @mob_id = SCOPE_IDENTITY();

			INSERT INTO Villager(ID_Mob, Trabalho, ID_TipoItem)
			VALUES (@mob_id, @v_trabalho, @v_id_tipo_item);
			COMMIT;
	    END TRY
	    BEGIN CATCH
		ROLLBACK;
		THROW;
	    END CATCH;

END
go



-- compra villager (esta atualiza os elementos)
-- EXEC dbo.EfetuaCompra <id_personagem> , <id_villager>
CREATE PROCEDURE EfetuaCompra(@id_personagem int, @id_villager int)
AS
BEGIN
		BEGIN TRANSACTION;
	BEGIN TRY
    -- Remove a esmeralda
    DELETE FROM Item WHERE ID = (SELECT TOP 1 ID FROM Item WHERE ID_Personagem = @id_personagem AND ID_TipoItem = 81);

	Insert into Aquisicao values
		(@id_personagem, @id_villager)

    -- tipo item villager
    DECLARE @tipoItem int;
    SET @tipoItem = (SELECT ID_TipoItem FROM Villager WHERE ID_Mob = @id_villager);

    INSERT INTO Item VALUES (@tipoItem, @id_personagem);
    		COMMIT;
	    END TRY
	    BEGIN CATCH
		ROLLBACK;
		THROW;
	    END CATCH;
END
GO


-- matar o mobzito
CREATE PROCEDURE Matar(@id_personagem int, @id_mob int)
as
	begin
	BEGIN TRANSACTION;
	BEGIN TRY
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
	    COMMIT;
	    END TRY
	    BEGIN CATCH
		ROLLBACK;
		THROW;
	    END CATCH;

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
AS
BEGIN
    declare @mob_id INT;

    declare mob_cursor CURSOR FOR
    SELECT ID
    FROM Mob
    WHERE ID_Bioma IS NULL;

    OPEN mob_cursor;

    fetch NEXT FROM mob_cursor INTO @mob_id;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        UPDATE Mob
        SET ID_Bioma = @id_bioma,
            MortoPor_ID_Personagem = NULL
        WHERE ID = @mob_id;

        fetch NEXT FROM mob_cursor into @mob_id;
    END;

    close mob_cursor;
    deallocate mob_cursor;
END
go

-- adicionar Jogador
create procedure AddJogador(@nome varchar(64), @senha varchar(16), @data datetime, @email varchar(64), @idioma varchar(16))
as
begin
	Insert into Jogador values
		(@nome, @senha,@data,@email,@idioma)
end
go

-- adicionar personagem
create procedure AddPersonagem(@nome varchar(64), @id_jogador int, @seed_mundo int)
as
begin
	insert into Personagem values
		(@nome, @id_jogador, @seed_mundo)
end
go

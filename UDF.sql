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

-- inventário
-- sou muito boa neste videojogo
CREATE VIEW InventárioView AS
select 'Item' AS Tipo, TI.Nome AS Nome, I.ID_Personagem
from Item I
-- aqui faz-se o inner join
inner join TipoItem TI on I.ID_Personagem = TI.ID
where I.ID_Personagem is not null

union all

select 'Bloco' as Tipo, B.Nome as Nome, B.ID_Personagem
FROM Bloco B
where B.ID_Personagem is not null

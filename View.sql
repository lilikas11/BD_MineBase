-- inventário
-- sou muito boa neste videojogo
CREATE VIEW InventárioView AS
select I.ID, TI.Nome AS Nome, I.ID_Personagem, 'Item' as Tipo
from Item I
-- aqui faz-se o inner join
inner join TipoItem TI on I.ID = TI.ID
where I.ID_Personagem is not null

union all

select B.ID, B.Nome as Nome, B.ID_Personagem, 'Bloco' as Tipo
FROM Bloco B
where B.ID_Personagem is not null
go


-- mundo view para ver as coisas que tão no mundo 
Create view MundoView AS

	select B.ID, B.Nome, 'Bloco' as Tipo, B.ID_Bioma
	from Bloco B
	where B.ID_Bioma is not null

	union all

	-- left join m + v -> se não for v fica null 
	select M.ID, M.Nome,
		case when V.ID_Mob is not null 
			then 'Villager' 
			else 'Mob'
			end as Tipo, 
		M.ID_Bioma
	from Mob M
	left join Villager V on M.ID = V.ID_Mob
	where M.ID_Bioma is not null

	-- os villagers são mobs, mas tem tipo 'Villager'
go


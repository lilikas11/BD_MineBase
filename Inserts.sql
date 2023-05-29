Use MineBase
GO


---INSERT INTO TABLES

INSERT INTO Jogador(ID, Nome, Senha, Data_Nascimento, Email, Idioma)
VALUES
  (1, 'Lia', 'lia1234', 02/01/2003, 'lia@gmail.com', 'portugues'),
  (2, 'Lili', 'lili1234', 02/01/2003, 'lili@gmail.com', 'portugues')

INSERT INTO Mundo(Seed, Nome, Dificuldade) VALUES
	(1234, 'DETI', 'Dificil')

INSERT INTO Personagem(ID, Nome, ID_Jogador, Seed_Mundo) VALUES
	(1, 'P1',1, 1234),
	(2, 'P2',2, 1234),
	(3, 'P3',1, NULL)
	

INSERT INTO Bioma (ID, Seed_Mundo, Nome) VALUES
(1, 1234, 'Floresta'),
(2, 1234, 'Deserto'),
(3, 1234, 'Planicie')


INSERT INTO TipoItem(ID,Nome) VALUES 
(1, 'Espada de Ferro'),
(2, 'Arco e Flecha'),
(3, 'Peixe'),
(4, 'Maçã Dourada'),
(5, 'Frasco de Encantamentos'),
(6, 'Pena'),
(7, 'Pó de Redstone'),
(8, 'Pérola do Fim'),
(9, 'Pólvora'),
(10, 'Carapaça'),
(11, 'Vara de Pesca'),
(12, 'Escada'),
(13, 'Sementes de Trigo'),
(14, 'Cenoura'),
(15, 'Melancia'),
(16, 'Sementes de Abóbora'),
(17, 'Flecha'),
(18, 'Carvão'),
(19, 'Balde de Água'),
(20, 'Balde de Lava'),
(21, 'Olho de aranha'),
(22, 'Vara de madeira'),
(23, 'Pó de Pedra Luminosa'),
(24, 'Escudo'),
(25, 'Flecha Flamejante'),
(26, 'Bússola'),
(27, 'Mel'),
(28, 'Areia'),
(29, 'Sementes de Beterraba'),
(30, 'Pergaminho de Encantamento'),
(31, 'Pó de Blaze'),
(32, 'Bambu'),
(33, 'Teia'),
(34, 'Vidro'),
(35, 'Sementes de Melão'),
(36, 'Pena de Escrever'),
(37, 'Folha de Carvalho'),
(38, 'Frasco de XP'),
(39, 'Redstone'),
(40, 'Ferro'),
(41, 'Carne'),
(42, 'Pele de Coelho'),
(43, 'Folha de Carvalho Escuro'),
(44, 'Cenoura Dourada'),
(45, 'Papel'),
(46, 'Cabeça de guardião'),
(47, 'Vara de Blaze'),
(48, 'Bola de Neve'),
(49, 'Semente de Batata'),
(50, 'Livro Encantado'),
(51, 'Olho do enderman'),
(52, 'Corda'),
(53, 'Cenoura Dourada Brilhante'),
(54, 'Lágrimas de fantasma'),
(55, 'Semente de Abóbora'),
(56, 'Estrela do Nether'),
(57, 'Carne Podre'),
(58, 'Tijolo de Pedra Vermelha'),
(59, 'Açúcar'),
(60, 'Barra de Ouro'),
(61, 'Picareta de pedra'),
(62, 'Picareta de diamante'),
(63, 'Enxada de diamante'),
(64, 'Bolo'),
(65, 'Batata Assada'),
(66, 'Salmão Assado'),
(67, 'Picareta de madeira'),
(68, 'Tesoura'),
(69, 'Pá de Madeira'),
(70, 'Slime'),
(71, 'Poção de Regeneração'),
(72, 'Poção de Respiração Aquática'),
(73, 'Poção de Agilidade'),
(74, 'Poção de Resistência ao Fogo'),
(75, 'Poção de Cura'),
(76, 'Poção de Visão Noturna'),
(77, 'Poção de Força'),
(78, 'Poção de Invisibilidade'),
(79, 'Osso'),
(80, 'Lã'),
(81, 'Esmeralda')

INSERT INTO Arma (ID_TipoItem, Durabilidade, Dano) VALUES
	 (1, 250, 7),
  (2, 384, 5),
  (5, 1561, 10),
  (6, 384, 8),
  (61, 250, 3),
  (62, 1700, 5),
  (63, 700, 2),
  (67, 100, 1),
  (68, 238, 1),
  (69, 60, 1),
  (70, null, 1)

INSERT INTO Comida (ID_TipoItem, Fome) VALUES
	(4, 3),
	(14, 1),
	(15, 1),
	(44, 3),
	(53, 4),
	(57, 1),
	(64, 1 ),
	(65, 2),
	(66, 2)

INSERT INTO Pocao (ID_TipoItem, Tempo, Efeito) VALUES
	(71, 45, 'Restaura vida'),
	(72, 180, 'Respirar debaixo de agua'),
	(73, 180, 'Aumento da velocidade'),
	(74, 180, 'Imunidade ao dano de fogo'),
	(75, 0, 'Restaura vida'),
	(76, 180, 'Ilumina todo a nivel de luz'),
	(77, 180, 'Aumento de dano corpo a corpo'),
	(78, 180, 'Modelo da personagem desaparece')

INSERT INTO ItemComum (ID_TipoItem) VALUES
(3),
(7),
(8),
(9),
(10),
(11),
(12),
(13),
(16),
(17),
(18),
(19),
(20),
(21),
(22),
(23),
(24),
(25),
(26),
(27),
(28),
(29),
(30),
(31),
(32),
(33),
(34),
(35),
(36),
(37),
(38),
(39),
(40),
(41),
(42),
(43),
(45),
(46),
(47),
(48),
(49),
(50),
(51),
(52),
(54),
(55),
(56),
(58),
(59),
(60),
(79),
(80),
(81)

INSERT INTO Item(ID_TipoItem, ID_Personagem) VALUES
	(72, 1),
	(56, 1),
	(5, 1),
	(6, 2),
	(23, 2),
	(81, 1),
	(81, 1),
	(81, 1),
	(81, 1),
	(81, 1),
	(81, 1),
	(81, 1)

INSERT INTO Mob (Nome, Personalidade, ID_Bioma, Dano_Facil, Dano_Normal, Dano_Dificil, ID_TipoItem, MortoPor_ID_Personagem) VALUES
('Axalote', 'Passiva', 1, 2, 2, 2, NULL, NULL),
('Burro', 'Passiva', 1, 0, 0, 0, NULL, NULL),
('Cavalo', 'Passiva', 1, 0, 0, 0, NULL, NULL),
('Cavalo Esqueleto', 'Passiva', 1, 0, 0, 0, 79, NULL),
('Coelho', 'Passiva', 1, 0, 0, 0, 41, NULL),
('Galinha', 'Passiva', 1, 0, 0, 0, 6, NULL),
('Gato', 'Passiva', 1, 3, 3, 3, NULL, NULL),
('Golem de neve', 'Passiva', 1, 0, 0, 0, 48, NULL),
('Mula', 'Passiva', 1, 0, 0, 0, NULL, NULL),
('Morcego', 'Passiva', 1, 0, 0, 0, NULL, NULL),
('Urso Polar', 'Neutra', 1, 4, 6, 9, NULL, NULL),
('Ovelha', 'Passiva', 1, 0, 0, 0, 80, NULL),
('Salmão', 'Passiva', 2, 0, 0, 0, 3, NULL),
('Tartaruga', 'Passiva', 2, 0, 0, 0, 10, NULL),
('Vaca', 'Passiva', 2, 0, 0, 0, 41, NULL),
('Vendedor ambulante', 'Passiva', 2, 0, 0, 0, NULL, NULL),
('Abelha', 'Neutral', 2, 2, 2, 3, 27, NULL),
('Aranha', 'Neutral', 2, 2, 2, 3, 33, NULL),
('Cabra', 'Neutral', 2, 1, 2, 3, 41, NULL),
('Golfinho', 'Neutral', 3, 2.5, 3, 4, NULL, NULL),
('Enderman', 'Neutral', 3, 4, 6, 10, 51, NULL),
('Golem de Ferro', 'Neutral', 3, 8, 14, 21, 40, NULL),
('Lhama', 'Neutral', 3, 1, 1, 1, 52, NULL),
('Lobo', 'Neutral', 3, 3, 4, 6, NULL, NULL),
('Panda', 'Neutral', 3, 4, 6, 9, 32, NULL),
('Peixe-balão', 'Neutral', 3, 2, 2, 3, 3, NULL),
('Afogado', 'Hostil', 3, 2, 3, 4, 57, NULL),
('Aldeão zumbi', 'Hostil', 1, 2.5, 3, 4, 57, NULL),
('Blaze', 'Hostil', 1, 5, 5, 5, 47, NULL),
('Bruxa', 'Hostil', 1, 6, 6, 6, NULL, NULL),
('Creeper', 'Hostil', 1, 22, 43, 64, 9, NULL),
('Globo de Magma Grande', 'Hostil', 1, 4, 6, 9, 70, NULL),
('Globo de Magma Médio', 'Hostil', 1, 3, 4, 6, 70, NULL),
('Globo de Magma Pequeno', 'Hostil', 1, 2, 3, 4, 70, NULL),
('Esqueleto', 'Hostil', 2, 2, 2, 3, 79, NULL),
('Fantasma', 'Hostil', 2, 4, 6, 9, 54, NULL),
('Guardião', 'Hostil', 2, 4, 6, 9, 46, NULL),
('Silverfish', 'Hostil', 2, 1, 1, 1, 3, NULL),
('Grande Slime', 'Hostil', 2, 3, 4, 6, 70, NULL),
('Médio Slime', 'Hostil', 3, 2, 2, 3, 70, NULL),
('Pequeno Slime', 'Hostil', 3, 0, 0, 0, 70, NULL),
('Zombie', 'Hostil', 3, 2, 3, 4, 57, NULL)

INSERT INTO MobComum(ID_mob) VALUES
	(1),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(11),
(12),
(13),
(14),
(15),
(16),
(17),
(18),
(19),
(20),
(21),
(22),
(23),
(24),
(25),
(26),
(27),
(28),
(29),
(30),
(31),
(32),
(33),
(34),
(35),
(36),
(37),
(38),
(39),
(40),
(41),
(42),
(43)

-- ADD VILLAGERS
EXEC dbo.create_villager_with_mob 2, 'Desempregado', 56;
EXEC dbo.create_villager_with_mob 3, 'Cartógrafo', 45;
EXEC dbo.create_villager_with_mob 2,  'Fazendeiro', 17;
EXEC dbo.create_villager_with_mob 1, 'Pedreiro', 2;
EXEC dbo.create_villager_with_mob 1, 'Bibliotecário', 12;
EXEC dbo.create_villager_with_mob 2, 'Armeiro', 1;


INSERT INTO Bloco (ID, Nome, Dureza, ID_Bioma,  ID_Personagem) 
VALUES
-- Blocos de construção
(1, 'Pedra', 3, 1, NULL),
(2, 'Pedra Lisa', 2, 1, NULL),
(3, 'Pedra Talhada', 4, 1, NULL),
(4, 'Tijolos de Pedra', 4, 1, NULL),
(5, 'Tijolos de Pedra Talhada', 4, 1, NULL),
(6, 'Pedregulho', 2, 1, NULL),
(7, 'Ardósia', 3, 1, NULL),
(8, 'Tijolos de Ardósia', 4, 1, NULL),
(9, 'Laje de Pedra', 2, 1, NULL),
(10, 'Laje de Ardósia', 2, 1, NULL),
-- Blocos coloridos
(11, 'Lã Branca', 0.8, 1, NULL),
(12, 'Lã Laranja', 0.8, 1, NULL),
(13, 'Lã Magenta', 0.8, 1, NULL),
(14, 'Lã Azul Claro', 0.8, 1, NULL),
(15, 'Lã Amarela', 0.8, 1, NULL),
(16, 'Lã Verde Limão', 0.8, 1, NULL),
(17, 'Lã Rosa', 0.8, 1, NULL),
(18, 'Lã Cinza', 0.8, 1, NULL),
-- Blocos naturais
(19, 'Terra', 0.5, 1, NULL),
(20, 'Grama', 0.6, 1, NULL),
(21, 'Cascalho', 0.6, 1, NULL),
(22, 'Tijolos de Pedra do End', 4, 1, NULL),
(23, 'Obsidiana', 50, 1, NULL),
-- Blocos naturais
(24, 'Gelo', 0.5, 1, NULL),
(25, 'Neve', 0.2, 1, NULL),
(26, 'Bloco de Gelo', 0.5, 1, NULL),
(27, 'Areia', 0.5, 1, NULL),
(28, 'Areia Vermelha', 0.5, 1, NULL),
(29, 'Tijolos de Pedregulho do Nether', 2, 1, NULL),
(30, 'Tijolos Vermelhos', 4, 1, NULL),
(31, 'Lã Azul', 0.8, 1, NULL),
(32, 'Lã Marrom', 0.8, 1, NULL),
(33, 'Lã Verde', 0.8, 1, NULL),
(34, 'Lã Vermelha', 0.8, 1, NULL),
(35, 'Fornalha', 3.5, 1, NULL),
(36, 'Dispenser', 3.5, 1, NULL),
(37, 'Alçapão', 3, 1, NULL),
(38, 'Porta de Ferro', 5, 1, NULL),
(39, 'Repetidor de Redstone', 0.1, 1, NULL),
(40, 'Comparador de Redstone', 0.2, 1, NULL),
(41, 'Lâmpada de Redstone', 0.3, 1, NULL),
(42, 'Pistão', 0.5, 1, NULL),
(43, 'Pedra Lisa', 2, 1, NULL),
(44, 'Pedra Talhada', 4, 1, NULL),
(45, 'Tijolos de Pedra', 4, 1, NULL),
(46, 'Tijolos de Pedra Talhada', 4, 1, NULL),
(47, 'Pedregulho', 2, 1, NULL),
(48, 'Lã Branca', 0.8, 1, NULL),
(49, 'Lã Laranja', 0.8, 1, NULL),
(50, 'Bloco de Madeira de Carvalho', 2, 1, NULL),
(51, 'Bloco de Madeira de Abeto', 2, 1, NULL),
(52, 'Bloco de Madeira de Eucalipto', 2, 1, NULL),
(53, 'Bloco de Madeira de Selva', 2, 1, NULL),
(54, 'Bloco de Pedra Vermelha', 4, 1, NULL),
(55, 'Bloco de Quartzo', 0.8, 1, NULL),
(56, 'Bloco de Pedra Luminosa', 0.3, 1, NULL),
(57, 'Bloco de Esmeralda', 5, 1, NULL),
(58, 'Bloco de Diamante', 5, 1, NULL),
(59, 'Bloco de Ouro', 3, 1, NULL),
(60, 'Bloco de Ferro', 3, 1, NULL),
(61, 'Bloco de Redstone', 0.5, 1, NULL),
(62, 'Bloco de Lapiz Lazuli', 3, 1, NULL),
(63, 'Bloco de Argila', 1.25, 1, NULL),
(64, 'Bloco de Netherrack', 0.4, 1, NULL),
(65, 'Bloco de Pedregulho do Nether', 2, 1, NULL),
(66, 'Bloco de Magma', 0.5, 3, NULL),
(67, 'Bloco de Areia', 0.5, 3, NULL),
(68, 'Bloco de Vidro', 0.3, 3, NULL),
(69, 'Bloco de TNT', 0.7, 3, NULL),
(70, 'Bloco de Melancia', 1, 3, NULL),
(71, 'Bloco de Abóbora', 1, 3, NULL),
(72, 'Bloco de Gelo', 0.5, 3, NULL),
(73, 'Bloco de Pedra End', 4, 3, NULL),
(74, 'Bloco de Tijolos do End', 4, 3, NULL),
(75, 'Bloco de Quartzo do End', 0.8, 3, NULL),
(76, 'Bloco de Obsidiana', 10, 3, NULL),
(77, 'Bloco de Arenito Vermelho', 0.8, 3, NULL),
(78, 'Bloco de Pedra Lisa', 2, 3, NULL),
(79, 'Bloco de Tijolos de Pedra', 2, 3, NULL),
(80, 'Bloco de Tijolos de Pedra com Musgo', 2, 3, NULL),
(81, 'Bloco de Tijolos de Pedra Rachados', 2, 3, NULL),
(82, 'Bloco de Tijolos de Pedra Talhados', 2, 3, NULL),
(83, 'Bloco de Prismarinho', 5, 3, NULL),
(84, 'Bloco de Prismarinho Escuro', 5, 3, NULL),
(85, 'Bloco de Calcário', 2, 3, NULL),
(86, 'Bloco de Arenito Liso', 2, 3, NULL),
(87, 'Bloco de Arenito Vermelho Liso', 2, 3, NULL),
(88, 'Bloco de Andesito Liso', 2, 3, NULL),
(89, 'Bloco de Diorito Liso', 2, 3, NULL),
(90, 'Bloco de Granito Liso', 2, 3, NULL),
(91, 'Bloco de Prismarinho de Tijolos', 5, 3, NULL),
(92, 'Bloco de Prismarinho Escuro de Tijolos', 5, 3, NULL),
(93, 'Bloco de Calcário de Tijolos', 2, 3, NULL),
(94, 'Bloco de Arenito Liso Cortado', 2, 3, NULL),
(95, 'Bloco de Arenito Vermelho Liso Cortado', 2, 3, NULL),
(96, 'Bloco de Andesito Liso Cortado', 2, 3, NULL),
(97, 'Bloco de Diorito Liso Cortado', 2, 3, NULL),
(98, 'Bloco de Granito Liso Cortado', 2, 3, NULL),
(99, 'Bloco de Prismarinho de Tijolos Cinza', 5, 3, NULL),
(100, 'Bloco de Prismarinho Escuro de Tijolos Cinza', 1, 3, NULL),
(101, 'Bloco de Calcário de Tijolos Cinza', 1, 3, NULL),
(102, 'Bloco de Arenito Liso Vermelho Cortado', 1, 3, NULL),
(103, 'Bloco de Arenito Vermelho Liso Vermelho Cortado', 1, 3, NULL),
(104, 'Bloco de Andesito Liso Vermelho Cortado', 1, 3, NULL),
(105, 'Bloco de Diorito Liso Vermelho Cortado', 1, 3, NULL),
(106, 'Bloco de Granito Liso Vermelho Cortado', 1, 3, NULL),
(107, 'Bloco de Quartzo de Tijolos', 1, 3, NULL),
(108, 'Bloco de Quartzo Talhado', 1, 3, NULL),
(109, 'Bloco de Quartzo Liso', 1, 3, NULL),
(110, 'Bloco de Cogumelo', 1, 3, NULL),
(111, 'Bloco de Esporo de Cogumelo', 1, 3, NULL),
(112, 'Bloco de Fungo do Nether', 1, 3, NULL),
(113, 'Bloco de Raiz do Nether', 1, 3, NULL),
(114, 'Bloco de Tubérculo do Nether', 1, 3, NULL),
(115, 'Bloco de Estalactite de Pedra', 1, 3, NULL),
(116, 'Bloco de Calcário Pintado', 1, 3, NULL),
(117, 'Bloco de Arenito Pintado', 1, 3, NULL),
(118, 'Bloco de Arenito Vermelho Pintado', 1, 3, NULL),
(119, 'Bloco de Andesito Pintado', 1, 3, NULL),
(120, 'Bloco de Batata', 1, 3, NULL),
(121, 'Bloco de Feno', 1, 3, NULL),
(122, 'Bloco de TNT', 1, 3, NULL),
(123, 'Bloco de Esponja', 1, 3, NULL),
(124, 'Bloco de Coral', 1, 3, NULL),
(125, 'Bloco de Tubarão', 1, 3, NULL),
(126, 'Bloco de Bolhas', 1, 3, NULL),
(127, 'Bloco de Gelo Azul', 1, 3, NULL),
(128, 'Bloco de Ancora', 1, 3, NULL)


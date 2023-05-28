CREATE DATABASE MineBase
COLLATE SQL_Latin1_General_CP1_CI_AI
GO

---CREATE TABLES


CREATE TABLE Jogador(
[ID][int] NOT NULL PRIMARY KEY,
[Nome] [varchar](64) NOT NULL,
[Senha] [varchar](16) NOT NULL,
[Data_Nascimento][datetime] NOT NULL,
[Email][varchar](64) NOT NULL,
[Idioma][varchar](16) NOT NULL
)

CREATE TABLE Mundo (
	[Seed][int] NOT NULL PRIMARY KEY,
	[Nome] [varchar](64) NOT NULL,
	[Dificuldade] [varchar](16) NOT NULL
)
GO

CREATE TABLE Personagem(
	[ID][int] NOT NULL PRIMARY KEY,
	[Nome][varchar](64) NOT NULL,
	[ID_Jogador][int] NOT NULL REFERENCES Jogador([ID]),
	[Seed_Mundo][int] REFERENCES Mundo([Seed])
)


CREATE TABLE Bioma (
	[ID][int] NOT NULL PRIMARY KEY,
	[Seed_Mundo][int] NOT NULL REFERENCES Mundo([Seed]),
	[Nome][varchar](64) NOT NULL
)

CREATE TABLE TipoItem(
	[ID][int] NOT NULL PRIMARY KEY,
	[Nome][varchar](32) NOT NULL
)

CREATE TABLE Arma (
	[ID_TipoItem][int] NOT NULL PRIMARY KEY REFERENCES TipoItem([ID]),
	[Durabilidade][int],
	[Dano][int] NOT NULL
)

CREATE TABLE Comida (
	[ID_TipoItem][int] NOT NULL PRIMARY KEY REFERENCES TipoItem([ID]),
	[Fome][int] NOT NULL
)

CREATE TABLE Pocao (
	[ID_TipoItem][int] NOT NULL PRIMARY KEY REFERENCES TipoItem([ID]),
	[Tempo][int] NOT NULL,
	[Efeito][varchar](128)
)

CREATE TABLE ItemComum (
	[ID_TipoItem][int] NOT NULL PRIMARY KEY REFERENCES TipoItem([ID])
) 
GO


CREATE TABLE Item (
	[ID][int] NOT NULL PRIMARY KEY,
	[ID_TipoItem][int] NOT NULL REFERENCES TipoItem([ID]),
	[ID_Personagem][int] NOT NULL REFERENCES Personagem([ID])
)
GO

CREATE TABLE Mob(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Nome] [varchar](32) NOT NULL,
	[Personalidade] [varchar](16) NOT NULL,
	[ID_Bioma][int] REFERENCES Bioma([ID]),
	[Dano_Facil][int] NOT NULL,
	[Dano_Normal][int] NOT NULL,
	[Dano_Dificil][int] NOT NULL,
	[ID_TipoItem][int] REFERENCES TipoItem([ID]),
	[MortoPor_ID_Personagem][int] REFERENCES Personagem([ID])
)
GO

CREATE TABLE MobComum(
	[ID_Mob][int] NOT NULL REFERENCES Mob([ID]) PRIMARY KEY
)
GO

CREATE TABLE Bloco(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Nome] [varchar](32) NOT NULL,
	[Dureza] [float] NOT NULL,
	[ID_Bioma][int] REFERENCES Bioma([ID]),
	[ID_Personagem][int] REFERENCES Personagem([ID]),

)
GO

CREATE TABLE Aquisicao(
	[ID][int] NOT NULL PRIMARY KEY,
	[ID_Personagem][int] NOT NULL REFERENCES Personagem([ID]),
	[ID_Villager][int] NOT NULL REFERENCES Villager([ID_Mob]),
)
GO

CREATE TABLE Villager(
	[ID_Mob][int] NOT NULL REFERENCES Mob([ID]) PRIMARY KEY,
	[Trabalho][varchar](32) NOT NULL,
	[ID_TipoItem][int] NOT NULL REFERENCES TipoItem([ID])
)
GO

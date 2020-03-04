-- Cria o banco de dados
CREATE DATABASE InLock_Games;
GO

-- Define qual banco de dados será utilizado
USE InLock_Games;
GO

-- Cria as tabelas
CREATE TABLE TiposUsuario(
	IdTipoUsuario		INT PRIMARY KEY IDENTITY
	,Titulo				VARCHAR (255) UNIQUE NOT NULL
);
GO

CREATE TABLE Usuarios(
	IdUsuario		INT PRIMARY KEY IDENTITY
	,Email			VARCHAR (255) UNIQUE NOT NULL
	,Senha			VARCHAR (255) NOT NULL
	,IdTipoUsuario	INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
);
GO

CREATE TABLE Estudios(
	IdEstudio		INT PRIMARY KEY IDENTITY
	,NomeEstudio	VARCHAR (255) UNIQUE NOT NULL
);
GO

CREATE TABLE Jogos(
	IdJogo			INT PRIMARY KEY IDENTITY
	,NomeJogo		VARCHAR (255) UNIQUE NOT NULL
	,Descricao		TEXT NOT NULL
	,DataLancamento	DATE NOT NULL
	,Valor			DECIMAL (18,2) NOT NULL
	,IdEstudio		INT FOREIGN KEY REFERENCES Estudios(IdEstudio)
);
GO
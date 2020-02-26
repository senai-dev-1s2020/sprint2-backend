-- Cria o banco de dados Filmes
CREATE DATABASE Filmes_tarde;
GO

-- Define o banco de dados que será utilizado
USE Filmes_tarde;
GO

-- Cria a tabela Generos
CREATE TABLE Generos(
	IdGenero	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR (255) NOT NULL UNIQUE
);
GO

-- Cria a tabela Filmes
CREATE TABLE Filmes(
	IdFilme		INT PRIMARY KEY IDENTITY
	,Titulo		VARCHAR (255) NOT NULL UNIQUE
	,IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);
GO
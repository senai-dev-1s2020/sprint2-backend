-- Cria o banco de dados
CREATE DATABASE Peoples;

-- Define qual banco de dados será utilizado
USE Peoples;

-- Cria a tabela Funcionarios
CREATE TABLE Funcionarios 
(
	IdFuncionario	INT IDENTITY PRIMARY KEY
	,Nome			VARCHAR(200) NOT NULL
	,Sobrenome		VARCHAR(255)
);
GO

-- Adiciona a coluna DataNascimento na tabela Funcionarios
ALTER TABLE Funcionarios
ADD DataNascimento DATE

-- Cria a tabela TiposUsuario
CREATE TABLE TiposUsuario(
	IdTipoUsuario	INT PRIMARY KEY IDENTITY
	,Titulo			VARCHAR(255) UNIQUE NOT NULL
);

-- Cria a tabela Usuarios
CREATE TABLE Usuarios(
	IdUsuario		INT PRIMARY KEY IDENTITY
	,Email			VARCHAR(255) UNIQUE NOT NULL
	,Senha			VARCHAR(255) NOT NULL
	,IdTipoUsuario	INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
);
GO
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
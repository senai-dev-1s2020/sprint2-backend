-- Define o banco de dados que será utilizado
USE Peoples;

-- Exibe todas as informações de todos os funcionários
SELECT * FROM Funcionarios;

-- Exibe todos os funcionários
SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios;

-- Exibe o funcionário com ID = 1
SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = 1;

-- Exibe o funcionário que tenha o nome Catarina
SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE Nome = 'Catarina';

-- Exibe o nome completo dos funcionários
SELECT IdFuncionario, CONCAT (Nome,' ',Sobrenome) AS [Nome Completo], DataNascimento FROM Funcionarios;

-- Exibe todos os funcionários de forma ordenada
SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios ORDER BY Nome DESC;
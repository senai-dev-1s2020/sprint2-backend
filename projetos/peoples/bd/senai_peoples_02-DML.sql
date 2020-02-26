-- Define o banco de dados que será utilizado
USE Peoples;

-- Insere dois funcionários
INSERT INTO Funcionarios (Nome, Sobrenome) 
VALUES	('Catarina', 'Strada')
		,('Tadeu', 'Vitelli');

-- Atualiza o valor da coluna DataNascimento
UPDATE Funcionarios SET DataNascimento = '1993-03-17';
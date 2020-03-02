-- Define o banco de dados que será utilizado
USE Peoples;

-- Insere dois funcionários
INSERT INTO Funcionarios	(Nome, Sobrenome) 
VALUES						('Catarina', 'Strada')
							,('Tadeu', 'Vitelli');

-- Atualiza o valor da coluna DataNascimento
UPDATE Funcionarios SET DataNascimento = '1993-03-17';

-- Insere dois tipos de usuário
INSERT INTO TiposUsuario	(Titulo)
VALUES						('Administrador'),('Comum');
GO

-- Insere três usuários
INSERT INTO Usuarios	(Email, Senha, IdTipoUsuario)
VALUES					('admin@email.com','admin123',1)
						,('catarina@email.com','catarina123',2)
						,('tadeu@email.com','tadeu123',2)
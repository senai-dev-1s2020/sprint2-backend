-- Define o banco de dados que será utilizado
USE Filmes_manha;
GO

-- Insere dois gêneros na tabela Generos
INSERT INTO Generos	(Nome)
VALUES				('Ação')
					,('Drama');
GO

-- Insere dois filmes na tabela Filmes
INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('A vida é bela', 2)
					,('Rambo', 1);
GO
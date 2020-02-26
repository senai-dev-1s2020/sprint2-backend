-- Define o banco de dados que será utilizado
USE Filmes_tarde;
GO

-- Lista todos os gêneros
SELECT * FROM Generos;

-- Lista todos os filmes
SELECT * FROM Filmes;

-- Lista todos os gêneros definindo as colunas exibidas
SELECT IdGenero, Nome from Generos;
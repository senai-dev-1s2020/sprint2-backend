-- Define o banco de dados que será utilizado
USE Filmes_manha;
GO

-- Lista todos os gêneros
SELECT * FROM Generos;

-- Lista todos os filmes
SELECT * FROM Filmes;

-- Lista todos os gêneros definindo as colunas exibidas
SELECT IdGenero, Nome from Generos;

-- Lista todos os usuários
SELECT * FROM Usuarios

-- Busca um usuário através do email e da senha
SELECT IdUsuario, Email, Senha, Permissao FROM Usuarios WHERE Email = 'saulo@email.com' AND Senha = '123';
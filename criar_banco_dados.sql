USE master 
GO 
IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'mobgames_store') 
	DROP DATABASE mobgames_store 
GO 
CREATE DATABASE mobgames_store 
GO 
USE mobgames_store 
GO 
SET DATEFORMAT dmy 
GO 

CREATE TABLE Usuario ( 
	id_usuario INT IDENTITY(1,1) PRIMARY KEY, 
	nome NVARCHAR(100) NOT NULL, 
	email NVARCHAR(150) NOT NULL UNIQUE, 
	senha_hash NVARCHAR(255) NOT NULL, 
	data_criacao DATETIME DEFAULT GETDATE(), 
	endereco NVARCHAR(150), 
	bairro NVARCHAR(100), 
	cidade NVARCHAR(100), 
	cep NVARCHAR(10),
	telefone NVARCHAR(15),
	cpf NVARCHAR(20),
	is_admin BIT NOT NULL DEFAULT 0
)
GO 

CREATE TABLE Jogo (
	id_jogo INT IDENTITY(1,1) PRIMARY KEY,
	nome NVARCHAR(100) NOT NULL UNIQUE,
	categoria NVARCHAR(150) NOT NULL,
	preco DECIMAL(10,2) NOT NULL,
	ativo BIT NOT NULL DEFAULT 1,
	data_cadastro DATETIME DEFAULT GETDATE()
)
GO 

CREATE TABLE Compra (
	id_compra INT IDENTITY(1,1) PRIMARY KEY,
	id_usuario INT NOT NULL,
	nome_jogo NVARCHAR(100) NOT NULL,
	data_compra DATETIME DEFAULT GETDATE(),
	CONSTRAINT FK_Compra_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
	CONSTRAINT UQ_Compra_Usuario_Jogo UNIQUE (id_usuario, nome_jogo)
)
GO 

INSERT INTO Usuario (nome, email, senha_hash, endereco, bairro, cidade, cep, telefone, cpf) VALUES 
('Lucas Borges', 'lucas@email.com', 'hash123', 'Rua A', 'Centro', 'São Paulo', '01000-000', '(11) 98765-4321', '123.456.789-00'), 
('Ana Silva', 'ana@email.com', 'hash456', 'Rua B', 'Jardins', 'São Paulo', '02000-000', '(11) 97654-3210', '987.654.321-00'),
('Carlos Santos', 'carlos@email.com', 'hash789', 'Rua C', 'Vila Mariana', 'São Paulo', '03000-000', '(11) 96543-2109', '456.789.123-00')
GO

INSERT INTO Usuario (nome, email, senha_hash, endereco, bairro, cidade, cep, telefone, cpf, is_admin) VALUES
('Admin', 'admin@mobgames.com', 'hash_admin', '', '', '', '', '', '000.000.000-00', 1)
GO

INSERT INTO Jogo (nome, categoria, preco) VALUES
('GTA VI', 'Simulacao, Tiro', 349.90),
('EA FC 26', 'Esporte, Simulacao', 299.90),
('MINECRAFT', 'Aventura, Exploracao', 99.90),
('RED DEAD REDEMPTION 2', 'Acao, Aventura', 249.90),
('FORZA HORIZON 5', 'Corrida, Mundo Aberto', 199.90),
('THE LAST OF US PART I', 'Acao, Sobrevivencia', 249.90),
('HOGWARTS LEGACY', 'RPG, Aventura', 229.90),
('CYBERPUNK 2077', 'RPG, Mundo Aberto', 199.90),
('GOD OF WAR', 'Acao, Aventura', 199.90),
('ELDEN RING', 'RPG, Acao', 279.90)
GO

SELECT * FROM Usuario
SELECT * FROM Jogo
GO

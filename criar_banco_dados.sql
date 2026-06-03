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
	cpf NVARCHAR(20)
)
GO 

INSERT INTO Usuario (nome, email, senha_hash, endereco, bairro, cidade, cep, telefone, cpf) VALUES 
('Lucas Borges', 'lucas@email.com', 'hash123', 'Rua A', 'Centro', 'São Paulo', '01000-000', '(11) 98765-4321', '123.456.789-00'), 
('Ana Silva', 'ana@email.com', 'hash456', 'Rua B', 'Jardins', 'São Paulo', '02000-000', '(11) 97654-3210', '987.654.321-00'),
('Carlos Santos', 'carlos@email.com', 'hash789', 'Rua C', 'Vila Mariana', 'São Paulo', '03000-000', '(11) 96543-2109', '456.789.123-00')
GO

SELECT * FROM Usuario
GO

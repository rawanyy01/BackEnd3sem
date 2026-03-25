CREATE DATABASE ConnectPlus;
USE ConnectPlus;


CREATE TABLE TipoContato (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL
);

GO

CREATE TABLE Contato (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    DadosContato VARCHAR(150) NOT NULL,
    Imagem VARCHAR(255),
    TipoContatoId INT NOT NULL,

    FOREIGN KEY (TipoContatoId)
    REFERENCES TipoContato(Id)
 );

 GO

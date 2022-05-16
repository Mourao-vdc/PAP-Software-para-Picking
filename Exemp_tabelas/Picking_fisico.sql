/* Picking_logico: */

CREATE TABLE Artigos (
    ID int PRIMARY KEY NOT NULL IDENTITY(1,1),
    Nome nvarchar(254),
    Cod_Barras nvarchar(254)
);

CREATE TABLE Encomendas_Artigos (
    ID int PRIMARY KEY NOT NULL IDENTITY(1,1),
    ID_Encomendas int,
    ID_Artigos int,
    Cod_Barras nvarchar(254),
    Situacao nvarchar(254),
    Quant_artigos int,
    Quant_artigos_cliente int
);

CREATE TABLE Encomendas (
    ID int PRIMARY KEY NOT NULL IDENTITY(1,1),
    ID_Utilizadores int ,
    Data datetime,
    Estado nvarchar(254)
);

CREATE TABLE Permissoes_Gerais (
    ID int  PRIMARY KEY NOT NULL IDENTITY(1,1),
    ID_Grupo int ,
    ID_Permicoes int ,
    Estado nvarchar(254)
);

CREATE TABLE Grupos (
    ID int  PRIMARY KEY NOT NULL IDENTITY(1,1),
    Nome nvarchar(254)
);

CREATE TABLE Permissoes_List (
    ID int  PRIMARY KEY NOT NULL IDENTITY(1,1),
    Nome nvarchar(254)
);

CREATE TABLE Utilizador (
    ID int  PRIMARY KEY NOT NULL IDENTITY(1,1),
    ID_Grupo int ,
    Nome nvarchar(254),
    Email nvarchar(254),
    Password nvarchar(254)
);
 
ALTER TABLE Encomendas_Artigos ADD CONSTRAINT FK_Encomendas_Artigos_2
    FOREIGN KEY (ID_Artigos)
    REFERENCES Artigos (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Encomendas ADD CONSTRAINT FK_Encomendas_2
    FOREIGN KEY (ID_Utilizadores)
    REFERENCES Utilizador (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Permissoes_Gerais ADD CONSTRAINT FK_Permissoes_Gerais_2
    FOREIGN KEY (ID_Grupo)
    REFERENCES Grupos (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Permissoes_Gerais ADD CONSTRAINT FK_Permissoes_Gerais_3
    FOREIGN KEY (ID_Permicoes)
    REFERENCES Permissoes_List (ID)
    ON DELETE CASCADE;
 
ALTER TABLE Utilizador ADD CONSTRAINT FK_Utilizador_2
    FOREIGN KEY (ID_Grupo)
    REFERENCES Grupos (ID)
    ON DELETE CASCADE;
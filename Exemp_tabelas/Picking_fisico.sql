/* Picking_logico: */

CREATE TABLE Artigos (
    ID int PRIMARY KEY,
    Nome nvarchar,
    Cod_Barras int
);

CREATE TABLE Encomendas (
    ID int PRIMARY KEY,
    ID_Artigos int,
    Cod_Barras int,
    Situacao bit,
    Quant_artigos int
);
 
ALTER TABLE Encomendas ADD CONSTRAINT FK_Encomendas_2
    FOREIGN KEY (ID_Artigos)
    REFERENCES Artigos (ID)
    ON DELETE RESTRICT;
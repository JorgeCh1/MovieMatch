/*
 * ER/Studio Data Architect SQL Code Generation
 * Project :      BdPelisChidorris.DM1
 *
 * Date Created : Saturday, June 10, 2023 03:24:21
 * Target DBMS : Microsoft SQL Server 2016
 */

USE master
go
CREATE DATABASE BdPelis
go
USE BdPelis
go
/* 
 * TABLE: Comentarios 
 */

CREATE TABLE Comentarios(
    idComentarios    int               IDENTITY(1,1),
    Comentario       nvarchar(4000)    NULL,
    IdUsuario        int               NOT NULL,
    IdPelicula       int               NOT NULL,
    CONSTRAINT PK9 PRIMARY KEY NONCLUSTERED (idComentarios, IdUsuario, IdPelicula)
)
go



IF OBJECT_ID('Comentarios') IS NOT NULL
    PRINT '<<< CREATED TABLE Comentarios >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Comentarios >>>'
go

/* 
 * TABLE: Peliculas 
 */

CREATE TABLE Peliculas(
    IdPelicula          int               IDENTITY(1,1),
    Titulo              nvarchar(100)     NOT NULL,
    Sinopsis            nvarchar(1000)    NOT NULL,
    Genero              nvarchar(60)      NULL,
    Rating              float             NULL,
    FechaLanzamiento    date              NULL,
    Poster              nvarchar(100)     NULL,
    Match               tinyint           NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (IdPelicula)
)
go



IF OBJECT_ID('Peliculas') IS NOT NULL
    PRINT '<<< CREATED TABLE Peliculas >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Peliculas >>>'
go

/* 
 * TABLE: Usuarios 
 */

CREATE TABLE Usuarios(
    IdUsuario              int               IDENTITY(1,1),
    PrimerNombre           nvarchar(50)      NOT NULL,
    SegundoNombre          nvarchar(50)      NULL,
    PrimerApellido         nvarchar(50)      NOT NULL,
    SegundoApellido        nvarchar(50)      NULL,
    Usuario                nvarchar(50)      NOT NULL,
    Clave                  nvarchar(64)      NOT NULL,
    CorreoElectronico      nvarchar(100)     NOT NULL,
    FechaCreacionCuenta    date              NOT NULL,
    Imagen                 varbinary(200)    NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (IdUsuario)
)
go



IF OBJECT_ID('Usuarios') IS NOT NULL
    PRINT '<<< CREATED TABLE Usuarios >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Usuarios >>>'
go

/* 
 * TABLE: Comentarios 
 */

ALTER TABLE Comentarios ADD CONSTRAINT RefUsuarios6 
    FOREIGN KEY (IdUsuario)
    REFERENCES Usuarios(IdUsuario)
go

ALTER TABLE Comentarios ADD CONSTRAINT RefPeliculas7 
    FOREIGN KEY (IdPelicula)
    REFERENCES Peliculas(IdPelicula)
go







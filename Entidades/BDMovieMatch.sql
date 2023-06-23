
 USE master
go
CREATE DATABASE BdPelis
go
USE BdPelis
go
/* 
 * TABLE: Peliculas 
 */

CREATE TABLE Peliculas(
    IdPelicula          int               IDENTITY(1,1),
    Titulo              nvarchar(100)     NOT NULL,
    Sinopsis            nvarchar(1000)    NOT NULL,
    Rating              float             NULL,
    FechaLanzamiento    date              NULL,
    Generos             nvarchar(100)     NULL,
    Poster              nvarchar(max)     NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (IdPelicula)
)
go



IF OBJECT_ID('Peliculas') IS NOT NULL
    PRINT '<<< CREATED TABLE Peliculas >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Peliculas >>>'
go

/* 
 * TABLE: PeliculasUsuarios 
 */

CREATE TABLE PeliculasUsuarios(
    IdUsuario     int    NOT NULL,
    IdPelicula    int    NOT NULL,
    CONSTRAINT PK10 PRIMARY KEY NONCLUSTERED (IdUsuario, IdPelicula)
)
go



IF OBJECT_ID('PeliculasUsuarios') IS NOT NULL
    PRINT '<<< CREATED TABLE PeliculasUsuarios >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE PeliculasUsuarios >>>'
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
    Imagen                 varbinary(max)    NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (IdUsuario)
)
go



IF OBJECT_ID('Usuarios') IS NOT NULL
    PRINT '<<< CREATED TABLE Usuarios >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Usuarios >>>'
go

/* 
 * TABLE: PeliculasUsuarios 
 */

ALTER TABLE PeliculasUsuarios ADD CONSTRAINT RefUsuarios8 
    FOREIGN KEY (IdUsuario)
    REFERENCES Usuarios(IdUsuario) ON DELETE CASCADE
go

ALTER TABLE PeliculasUsuarios ADD CONSTRAINT RefPeliculas9 
    FOREIGN KEY (IdPelicula)
    REFERENCES Peliculas(IdPelicula) ON DELETE CASCADE
go



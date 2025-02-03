--+++++++ QUERY CRUD SQL AND C# +++++++

--CREACION DE LA BD
CREATE DATABASE CRUD_PERSONA_BD

--CREACION DE TABLA

CREATE TABLE Persona(
	IdPersona INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(100),
	Edad INT
);
-- SELECT * FROM Persona
GO

--INSERT INTO Persona(Nombre,Edad) --OPCIONAL
--VALUES ('Andy Cruz',22),
--	   ('Jos� Garc�a',23)
IF OBJECT_ID ('dbo.gestores_bd') IS NOT NULL
	DROP TABLE dbo.gestores_bd
GO

CREATE TABLE dbo.gestores_bd
	(
	Id        INT IDENTITY NOT NULL,
	Name      VARCHAR (50) NOT NULL,
	Launch    INT NOT NULL,
	Developer VARCHAR (50) NOT NULL
	)
GO
CREATE DATABASE skinetDB;
GO
USE skinetDB;
GO

DROP TABLE IF EXISTS tblProduct;
GO

CREATE TABLE [dbo].[tblProduct]
(
	[Id] BIGINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(100),
	[Description] VARCHAR(100),
	[Price] DECIMAL,
	[PictureUrl] VARCHAR(100),
	[Type] VARCHAR(50),
	[Brand] VARCHAR(50),
	[QuantityInStock] INT
);


ALTER TABLE [tblProduct]
ALTER COLUMN [Price] DECIMAL(18, 4);
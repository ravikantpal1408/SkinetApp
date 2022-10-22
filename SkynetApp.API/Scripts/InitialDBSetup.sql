CREATE DATABASE skinetDB;

USE skinetDB;

CREATE TABLE tblProduct
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Price DECIMAL
);
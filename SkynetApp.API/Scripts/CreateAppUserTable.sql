USE skinetDB;
GO
DROP TABLE IF EXISTS tblAppUser;
GO
CREATE TABLE tblAppUser
(
	Id  INT PRIMARY KEY IDENTITY(1,1),
	UserId  UNIQUEIDENTIFIER, -- GUID for in the C# code 
	Username VARCHAR(100) NOT NULL UNIQUE,
	PasswordHash BINARY(64) not null ,
	PasswordSalt BINARY(128) not null,
	CreatedBy VARCHAR(100) ,
	CreatedDate DATETIME DEFAULT GETDATE(),
	UpdatedBy VARCHAR(100) ,
	UpdatedDate DATETIME,
	IsActive BIT
)


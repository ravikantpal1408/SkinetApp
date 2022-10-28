USE skinetDB;
GO

CREATE TABLE tblAppUser
(
	Id NVARCHAR(255) PRIMARY KEY ,
	Username VARCHAR(100) not null unique,
	PasswordHash BINARY(64) not null ,
	PasswordSalt BINARY(128) not null,
	CreatedBy VARCHAR(100) ,
	CreatedDate DATETIME DEFAULT GETDATE(),
	UpdatedBy VARCHAR(100) ,
	UpdatedDate DATETIME,
	IsActive BIT
)


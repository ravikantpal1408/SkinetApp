USE skinetDB;
GO

CREATE OR ALTER PROCEDURE spRegisterUser
(
	@Id UNIQUEIDENTIFIER,
	@Username VARCHAR(100),
	@PasswordHash BINARY(64),
	@PasswordSalt BINARY(128)
)
AS
	BEGIN	
		INSERT INTO tblAppUser ([Id], [Username], [PasswordHash], [PasswordSalt], [CreatedBy] , [IsActive])
		OUTPUT Inserted.Id, Inserted.Username, Inserted.CreatedBy, Inserted.IsActive -- [ this code allows to return the inserted record ] 
		VALUES(@Id, @Username, @PasswordHash, @PasswordSalt , 'Admin', 1);
	END
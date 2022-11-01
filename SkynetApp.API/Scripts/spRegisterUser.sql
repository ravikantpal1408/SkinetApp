USE skinetDB;
GO

CREATE OR ALTER PROCEDURE spRegisterUser
(
	@UserId UNIQUEIDENTIFIER,
	@Username VARCHAR(100),
	@PasswordHash BINARY(64),
	@PasswordSalt BINARY(128)
)
AS
	BEGIN	
		INSERT INTO tblAppUser 
		(
			[UserId],
			[Username], 
			[PasswordHash], 
			[PasswordSalt], 
			[CreatedBy] , 
			[IsActive])
		OUTPUT Inserted.Id,Inserted.UserId, Inserted.Username, Inserted.CreatedBy, Inserted.IsActive -- [ this code allows to return the inserted record ] 
		VALUES(@UserId, @Username, @PasswordHash, @PasswordSalt , 'Admin', 1);
	END
USE skinetDB;
GO

CREATE PROCEDURE spRegisterUser
(
	@Id NVARCHAR(255),
	@Username VARCHAR(100),
	@PasswordHash BINARY(64),
	@PasswordSalt BINARY(128)
)
AS
	BEGIN	
		INSERT INTO tblAppUser ([Id], [Username], [PasswordHash], [PasswordSalt], [CreatedBy] , [IsActive])

		VALUES(@Id, @Username, @PasswordHash, @PasswordSalt , 'Admin', 1);
	END
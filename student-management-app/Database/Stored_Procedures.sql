USE BCiTS;

GO

CREATE PROCEDURE spAddStudent
(
		@ID			INT,
		@Name		VARCHAR(20),
		@Surname	VARCHAR(20),
		@Picture	VARBINARY(MAX),
		@DOB		DATE,
		@Gender		CHAR(1),
		@Phone		BIGINT,
		@Address	VARCHAR(40)
)
AS
BEGIN
INSERT INTO tbl_Student VALUES(@ID,@Name,@Surname,@Picture,@DOB,@Gender,@Phone,@Address);
END

GO

CREATE PROCEDURE spUpdateStudent
(
		@ID			INT,
		@Name		VARCHAR(30),
		@Surname	VARCHAR(30),
		@Picture	VARBINARY(MAX),
		@DOB		DATE,
		@Gender		CHAR(1),
		@Phone		BIGINT,
		@Address	VARCHAR(50)
)
AS
BEGIN
UPDATE tbl_Student SET SName = @Name,Surname = @Surname,Picture = @Picture, DOB = @DOB,Gender = @Gender,Phone = @Phone,SAddress = @Address WHERE StudentNumber = @ID;
END

GO

CREATE PROCEDURE spAddModule
(

		@ModCode			INT,
		@Name				VARCHAR(20),
		@Desc				VARCHAR(40),
		@Link				VARCHAR(30)

)
AS
BEGIN
INSERT INTO tbl_Modules VALUES(@ModCode,@Name,@Desc,@Link);
END

GO

CREATE PROCEDURE spUpdateModule
(

		@ModCode			INT,
		@Name				VARCHAR(20),
		@Desc				VARCHAR(40),
		@Link				VARCHAR(30)

)
AS
BEGIN
UPDATE tbl_Modules SET MName = @Name, MDescription = @Desc, Link = @Link WHERE ModuleCode = @ModCode;
END

GO

CREATE PROCEDURE spAddStudentModule
(
		@StudNo			INT,
		@ModCode		INT
)
AS
BEGIN
INSERT INTO tbl_StudentModules VALUES(@StudNo,@ModCode);
END
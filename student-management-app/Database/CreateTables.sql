USE BelgiumCampus
GO

CREATE TABLE Modules
(
	ModuleCode INT IDENTITY(01,1) PRIMARY KEY,
	ModuleName VARCHAR(30) NOT NULL,
	ModuleDesciption VARCHAR(255) NOT NULL,
	ModuleLinks VARCHAR(255) NOT NULL,
);
GO

CREATE TABLE Students
(
	StudentNumber INT IDENTITY(001, 1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	Surname VARCHAR(50) NOT NULL,
	Picture VARBINARY(MAX),
	DateOfBirth DATE NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	Phone VARCHAR(20) NOT NULL UNIQUE,
	Address VARCHAR(255) NOT NULL,
	ModuleCode INT REFERENCES Modules(ModuleCode)
);
GO
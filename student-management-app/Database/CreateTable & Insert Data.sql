


USE BCiTS;

GO

IF OBJECT_ID('dbo.tbl_Student', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_Student;

IF OBJECT_ID('dbo.tbl_Modules', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_Modules;

IF OBJECT_ID('dbo.tbl_StudentModules', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_StudentModules;

-- Create tbl_Student table

CREATE TABLE tbl_Student
(
    StudentNumber   INT PRIMARY KEY,
    SName           VARCHAR(20) NOT NULL,
    Surname         VARCHAR(20) NOT NULL,
    Picture         IMAGE,
    DOB             DATETIME NOT NULL,
    Gender          CHAR(1) NOT NULL,
    Phone           BIGINT NOT NULL,
    SAddress        VARCHAR(40) NOT NULL
);

-- Create tbl_Modules table

CREATE TABLE tbl_Modules
(
    ModuleCode      INT PRIMARY KEY,
    MName           VARCHAR(20) NOT NULL,
    MDescription    VARCHAR(40),
    Link            VARCHAR(30)
);

-- Create tbl_StudentModules junction table

CREATE TABLE tbl_StudentModules
(
    StudentNumber   INT,
    ModuleCode      INT,
    PRIMARY KEY (StudentNumber, ModuleCode),
    FOREIGN KEY (StudentNumber) REFERENCES tbl_Student(StudentNumber),
    FOREIGN KEY (ModuleCode) REFERENCES tbl_Modules(ModuleCode)
);

-- Insert data into tbl_Student

INSERT INTO tbl_Student (StudentNumber, SName, Surname, Picture, DOB, Gender, Phone, SAddress) VALUES 
(1, 'John', 'Doe', NULL, '1990-05-15', 'M', 1234567890, '123 Main St'),
(2, 'Jane', 'Smith', NULL, '1992-08-21', 'F', 9876543210, '456 Oak St'),
(3, 'Bob', 'Johnson', NULL, '1991-03-10', 'M', 5551234567, '789 Pine St'),
(4, 'Alice', 'Williams', NULL, '1993-11-02', 'F', 3339876543, '101 Elm St'),
(5, 'Charlie', 'Brown', NULL, '1995-07-14', 'M', 9995551234, '202 Birch St'),
(6, 'Eva', 'Miller', NULL, '1994-01-30', 'F', 7773339999, '303 Cedar St'),
(7, 'David', 'Davis', NULL, '1996-09-05', 'M', 1112223333, '404 Maple St'),
(8, 'Grace', 'Anderson', NULL, '1997-04-18', 'F', 4448887777, '505 Walnut St'),
(9, 'Frank', 'Taylor', NULL, '1998-12-25', 'M', 6669991111, '606 Pineapple St'),
(10, 'Sophie', 'Clark', NULL, '1999-06-08', 'F', 2224446666, '707 Peach St');

-- Insert data into tbl_Modules

INSERT INTO tbl_Modules (ModuleCode, MName, MDescription, Link) VALUES 
(101, 'CS101', 'Introduction to Computer Science', 'cs101-link'),
(102, 'MATH201', 'Linear Algebra', 'math201-link'),
(103, 'ENG301', 'Advanced Literature', 'eng301-link'),
(104, 'PHYS101', 'Physics for Beginners', 'phys101-link'),
(105, 'CHEM201', 'Inorganic Chemistry', 'chem201-link'),
(106, 'HIST301', 'Modern History', 'hist301-link'),
(107, 'ART150', 'Introduction to Fine Arts', 'art150-link'),
(108, 'BUS420', 'Business Ethics', 'bus420-link'),
(109, 'PSYC301', 'Cognitive Psychology', 'psyc301-link'),
(110, 'MUSC110', 'Music Appreciation', 'musc110-link');

-- Insert data into tbl_StudentModules junction table

INSERT INTO tbl_StudentModules (StudentNumber, ModuleCode) VALUES
(1, 101),
(1, 102),
(2, 103),
(2, 104),
(3, 105),
(3, 106),
(4, 107),
(4, 108),
(5, 109),
(5, 110),
(6, 101),
(6, 103),
(7, 102),
(7, 104),
(8, 105),
(8, 107),
(9, 108),
(9, 110),
(10, 106),
(10, 109);








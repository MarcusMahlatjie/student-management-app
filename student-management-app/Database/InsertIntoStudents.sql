USE BelgiumCampus
GO 

ALTER TABLE Students
ALTER COLUMN Gender CHAR(1) NOT NULL;
GO

INSERT INTO Students(FirstName, Surname, Picture, DateOfBirth, Gender, Phone, Address, ModuleCode) VALUES
('John', 'Doe', NULL, '2000-01-01', 'M', '1234567890', '123 Main St', 01),
('Jane', 'Smith', NULL, '1999-05-15', 'F', '9876543210', '456 Oak St', 02),
('Bob', 'Johnson', NULL, '2002-03-20', 'M', '5551234567','789 Pine St', 03),
('Alice', 'Williams', NULL, '2001-07-10', 'F', '7778889999','567 Elm St', 04),
('David', 'Miller', NULL, '2003-09-05', 'M', '4445556666', '890 Maple St', 05),
('Sophia', 'Brown', NULL, '2000-12-18', 'F', '1112223333', '234 Birch St', 06),
('Chris', 'Taylor', NULL, '1998-04-25', 'M', '9998887777', '678 Cedar St', 07),
('Emily', 'Davis', NULL, '2002-08-30', 'F', '6667778888', '345 Fir St', 08),
('Michael', 'White', NULL, '1999-11-12', 'M', '2223334444', '789 Redwood St', 09),
('Olivia', 'Jones', NULL, '2001-06-08', 'F', '3334445555','456 Spruce St', 10);
GO

SELECT * FROM Students
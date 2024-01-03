USE BCiTDB;

GO 

ALTER TABLE tbl_Students
ALTER COLUMN Phone_Number BIGINT NOT NULL;

INSERT INTO tbl_Students (studNumber, SName, Surname, Phone_Number, Picture, DOB, Gender, P_Address, Module_Code, Module_Name, Module_Description, Link)
VALUES(1, 'John', 'Doe', 1234567890, NULL, '2000-01-01', 'M', '123 Main St', 101, 'Mathematics', 'Intro to Calculus', 'http://example.com/math101'),
	  (2, 'Jane', 'Smith', 9876543210, NULL, '1999-05-15', 'F', '456 Oak St', 102, 'English Literature', 'World Classics', 'http://example.com/eng102'),
	  (3, 'Bob', 'Johnson', 5551234567, NULL, '2002-03-20', 'M', '789 Pine St', 103, 'History', 'Ancient Civilizations', 'http://example.com/history103'),
	  (4, 'Alice', 'Williams', 7778889999, NULL, '2001-07-10', 'F', '567 Elm St', 104, 'Computer Science', 'Introduction to Programming', 'http://example.com/cs104'),
	  (5, 'David', 'Miller', 4445556666, NULL, '2003-09-05', 'M', '890 Maple St', 105, 'Chemistry', 'Organic Chemistry', 'http://example.com/chem105'),
	  (6, 'Sophia', 'Brown', 1112223333, NULL, '2000-12-18', 'F', '234 Birch St', 106, 'Physics', 'Mechanics', 'http://example.com/phy106'),
	  (7, 'Chris', 'Taylor', 9998887777, NULL, '1998-04-25', 'M', '678 Cedar St', 107, 'Economics', 'Microeconomics', 'http://example.com/eco107'),
	  (8, 'Emily', 'Davis', 6667778888, NULL, '2002-08-30', 'F', '345 Fir St', 108, 'Political Science', 'International Relations', 'http://example.com/ps108'),
	  (9, 'Michael', 'White', 2223334444, NULL, '1999-11-12', 'M', '789 Redwood St', 109, 'Psychology', 'Abnormal Psychology', 'http://example.com/psy109'),
	  (10, 'Olivia', 'Jones', 3334445555, NULL, '2001-06-08', 'F', '456 Spruce St', 110, 'Sociology', 'Social Structures', 'http://example.com/soc110');

	  SELECT * FROM tbl_Students;
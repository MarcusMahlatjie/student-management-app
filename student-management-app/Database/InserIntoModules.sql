USE BelgiumCampus
GO

INSERT INTO Modules(ModuleName, ModuleDesciption, ModuleLinks) VALUES
('Mathematics', 'Intro to Calculus', 'http://example.com/math101'),
('English Literature', 'World Classics', 'http://example.com/eng102'),
('History', 'Ancient Civilizations', 'http://example.com/history103'),
('Computer Science', 'Introduction to Programming', 'http://example.com/cs104'),
('Chemistry', 'Organic Chemistry', 'http://example.com/chem105'),
('Physics', 'Mechanics', 'http://example.com/phy106'),
('Economics', 'Microeconomics', 'http://example.com/eco107'),
('Political Science', 'International Relations', 'http://example.com/ps108'),
('Psychology', 'Abnormal Psychology', 'http://example.com/psy109'),
('Sociology', 'Social Structures', 'http://example.com/soc110');
GO

SELECT * FROM Modules;
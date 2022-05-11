--USE LessonMonitorDb

-- DROP TABLE MemberAccounts
-- DROP TABLE Members
-- DROP TABLE Lessons
-- DROP TABLE VisitedLessons

-- CREATE TABLE Members(
--     Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
--     Name NVARCHAR(50) NOT NULL,
--     CreateDate DATETIME2 DEFAULT GETDATE()
-- )

-- CREATE TABLE MemberAccounts(
--     Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
--     MemberId INT NOT NULL,
--     UserName NVARCHAR(50) NOT NULL,
--     Link NVARCHAR(200) NULL,
--     CreateDate DATETIME2 DEFAULT GETDATE(),
--     CONSTRAINT FK_MemberAccounts_Members FOREIGN KEY (MemberId) REFERENCES [Members](Id)
-- )

-- CREATE TABLE Lessons(
--     Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
--     Title NVARCHAR(200) NOT NULL,
--     Description NVARCHAR(2000) NULL,
--     StartDate DATETIME2 NOT NULL,
--     CreateDate DATETIME2 DEFAULT GETDATE()
-- )
-- CREATE TABLE VisitedLessons(    
--     MemberId INT NOT NULL,
--     LessonId INT NOT NULL,
--     CreateDate DATETIME2 DEFAULT GETDATE(),
--     CONSTRAINT PK_MemberId_LessonId PRIMARY KEY (MemberId, LessonId),
--     CONSTRAINT FK_VisitedLessons_Members FOREIGN KEY (MemberId) REFERENCES [Members](Id),
--     CONSTRAINT FK_VisitedLessons_Lessons FOREIGN KEY (LessonId) REFERENCES [Lessons](Id)
-- )

INSERT Members (Name)
VALUES ('Valera')

INSERT INTO MemberAccounts (MemberId, UserName)
VALUES (3, N'Тело хранитель')

INSERT Lessons (Title, StartDate, [Description])
VALUES (N'Резка по камню', '2022-04-20 16:00:00', N'Вырезаем бабу (не глиняную)')

INSERT VisitedLessons (MemberId, LessonId)
VALUES (1, 2)

SELECT * FROM Members
SELECT * FROM MemberAccounts
SELECT * FROM Lessons
SELECT * FROM VisitedLessons

INSERT INTO Members (Name)
VALUES (N'Раста')

INSERT INTO Lessons(Title, [Description], StartDate) VALUES (N'Растафарианство', N'Курить мараву', '2022-04-25 16:20:00')
INSERT INTO VisitedLessons(MemberId, LessonId) SELECT Id, 4 FROM Members WHERE Name != 'Жорик'
DELETE FROM VisitedLessons WHERE MemberId = 4 AND LessonId = 4

SELECT LessonId, COUNT(*) as N'Посетили' FROM VisitedLessons GROUP BY LessonId

SELECT Name as N'Кто хапает' FROM Members WHERE Id in(
    SELECT MemberId FROM VisitedLessons
    WHERE LessonId = 4
)

SELECT l.Id, l.Title as N'Lessons', COUNT(*) as N'Посетителей', l.StartDate
FROM VisitedLessons vl 
INNER JOIN Members m ON vl.MemberId = m.Id
INNER JOIN Lessons l ON l.Id = vl.LessonId
GROUP BY Title, l.Id, StartDate
ORDER BY l.Id

SELECT COUNT(l.MemberId) as N'Сколько людей посещает занятия' FROM VisitedLessons l

SELECT m.Name as N'Кто посещает занятия', l.Title FROM VisitedLessons vl
INNER JOIN Members m ON m.Id = vl.MemberId
INNER JOIN Lessons l ON l.Id = vl.LessonId

SELECT Id, Name as N'Бездельники' FROM Members m
LEFT JOIN VisitedLessons vl ON vl.MemberId = m.Id
WHERE vl.MemberId IS NULL


SELECT COUNT(*) FROM Members m

INSERT INTO Members (Name) VALUES (N'Шлепа')
DELETE FROM VisitedLessons WHERE MemberId = 10
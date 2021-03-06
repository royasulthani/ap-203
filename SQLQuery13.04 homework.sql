CREATE DATABASE University
USE University
CREATE TABLE STUDENTS
( 
 ID INT PRIMARY KEY IDENTITY,
 GROUPSID INT FOREIGN KEY REFERENCES GROUPS(ID),
 NAME NVARCHAR(20)NOT NULL UNIQUE,
 SURNAME NVARCHAR(20)NOT NULL UNIQUE,
 )
  CREATE TABLE GROUPS
  (ID INT PRIMARY KEY IDENTITY,
   GROUPNO NVARCHAR(10)NOT NULL UNIQUE,
   )
   INSERT INTO GROUPS
VALUES
('P201'),
('P202'),
('P203'),
('P207')


   ALTER TABLE STUDENTS
   ADD GROUPSID INT 
   ALTER TABLE STUDENTS
   ADD CONSTRAINT FK_STDNTS_GROUPSID FOREIGN KEY (GROUPSID) REFERENCES GROUPS(ID)
   CREATE TABLE EXAMS
   (ID INT PRIMARY KEY IDENTITY,
    DATE DATETIME2,DEFAULT(GETUTCDATE()),
	)
	 CREATE TABLE SUBJECTS
  (ID INT PRIMARY KEY IDENTITY,
  SUBJECTSID INT FOREIGN KEY REFERENCES SUBJECTS(ID),
   NAME NVARCHAR(20)NOT NULL UNIQUE,
   )
   ALTER TABLE EXAMS
   ADD SUBJECTSID INT 
   ALTER TABLE EXAMS
   ADD CONSTRAINT FK_EXAMS_SUBJECTSID FOREIGN KEY (SUBJECTSID) REFERENCES SUBJECTS(ID)
   CREATE TABLE STUDENTSEXAMS
  (ID INT PRIMARY KEY IDENTITY,
   STUDENTSID INT FOREIGN KEY REFERENCES STUDENTS(ID),
   EXAMSID INT FOREIGN KEY REFERENCES EXAMS(ID),
   RESULT TINYINT NOT NULL,
   )
   ALTER TABLE STUDENTSEXAMS
   ADD SUBJECTSID INT 
   ALTER TABLE STUDENTSEXAMS
   ADD CONSTRAINT FK_STDNTSEXAMS_SUBJECTSID FOREIGN KEY (SUBJECTSID) REFERENCES SUBJECTS(ID)
    ALTER TABLE STUDENTSEXAMS
   ADD EXAMSID INT 
   ALTER TABLE STUDENTSEXAMS
   ADD CONSTRAINT FK_STDNTSEXAMS_EXAMSID FOREIGN KEY (EXAMSID) REFERENCES EXAMS(ID)

   SELECT * FROM STUDENTS
   JOIN GROUPS ON STUDENTS.GROUPSID=GROUPSID
   SELECT S.Id,S.Name AS 'STUDENTSName',G.ID AS 'GROUPSName'
   FULL OUTER JOIN STUDENTS AS S ON SE.STUDENTSID=S.Id
   FULL OUTER JOIN GROUPS AS g ON SE.GROUPSID = G.Id
   FULL OUTER JOIN EXAMS AS e ON SE.EXAMSID=E.Id





  

   
   
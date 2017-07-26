-- Create some data

/* 
Sample course:
	COMP3231
		-> Asst1
			-> Part 1
			-> Part 2
			-> Part 3
		-> Quiz 1
			-> Q1
				-> (i)
				-> (ii)
				-> (iii)
			-> Q2
				-> (i)
					-> A
					-> B
				-> (ii)
			-> Q3
*/

-- Course: COMP3231
INSERT INTO courses(rowid,name) VALUES (1,'COMP3231');

-- COMP3231: Asst1
INSERT INTO assessments(rowid,name,dueDateTime,marks,weighting,courseID)
VALUES (1,'Asst1','25/07/2017 11:59:59pm',40,20,1);

-- COMP3231: Asst1: Part 1
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (1,'Part 1', 5, 1, NULL);

-- COMP3231: Asst1: Part 2
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (2,'Part 2', 10, 1, NULL);

-- COMP3231: Asst1: Part 3
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (3,'Part 3',15,1,NULL);

-- COMP3231: Quiz 1
INSERT INTO assessments(rowid,name,dueDateTime,marks,weighting,courseID)
VALUES (2,'Quiz 1','30/08/2017 11:59:59pm',50,30,1);

-- COMP3231: Quiz 1: Q1
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (4,'Q1',15,2,NULL);

-- COMP3231: Quiz 1: Q1: (i)
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (5,'(i)',4,2,4);

-- COMP3231: Quiz 1: Q1: (ii)
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (6,'(ii)',5,2,4);

-- COMP3231: Quiz 1: Q1: (iii)
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (7,'(iii)',6,2,4);

-- COMP3231: Quiz 1: Q2
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (8,'Q2',25,2,NULL);

-- COMP3231: Quiz 1: Q2: (i)
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (9,'(i)',15,2,8);

-- COMP3231: Quiz 1: Q2: (i): A
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (10,'A',5,2,9);

-- COMP3231: Quiz 1: Q2: (i): B
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (11,'B',10,2,9);

-- COMP3231: Quiz 1: Q2: (ii)
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (12,'(ii)',10,2,8);

-- COMP3231: Quiz 1: Q3
INSERT INTO components (rowid, name, marks, assessmentID, parentComponent)
VALUES (13,'Q3',10,2,NULL);

/* 
Sample group (and students) for COMP3231:
	Group A
		-> Student 2
		-> Student 2
*/
-- COMP3231: Group A
INSERT INTO groups (rowid, name, courseID)
VALUES(1, 'Group A', 1);

-- Student A
INSERT INTO students (rowid, fname, lname)
VALUES (1, 'Student', 'A');

-- Student B
INSERT INTO students (rowid, fname, lname)
VALUES (2, 'Student', 'B');

-- Group A: Student 1
INSERT INTO student_belongs (groupID, studID)
VALUES (1, 1);

-- Group A: Student 2
INSERT INTO student_belongs (groupID, studID)
VALUES (1, 2);

-- Initialises tables in the db
CREATE TABLE courses (
	`name` CHAR(20) NOT NULL UNIQUE
);

CREATE TABLE assessments (
	`name` CHAR(20) NOT NULL,
	`dueDateTime` TEXT,
	`marks` INT,
	`weighting` INT,
	`comments` TEXT,
	`courseID` INT NOT NULL,

	FOREIGN KEY(`courseID`) REFERENCES courses(`rowid`),
	UNIQUE(`name`, `courseID`)
);

CREATE TABLE components (
	`name` CHAR(20) NOT NULL,
	`marks` INT,
	`comments` TEXT,
	`assessmentID` INT,
	`parentComponent` INT,

	FOREIGN KEY(`assessmentID`) REFERENCES assessments(`rowid`),
	FOREIGN KEY(`parentComponent`) REFERENCES components(`rowid`),
	UNIQUE(`name`, `parentComponent`)
);

CREATE TABLE groups (
	`name` CHAR(20) NOT NULL,
	`courseID` INT NOT NULL,

	FOREIGN KEY(`courseID`) REFERENCES courses(`rowid`),
	UNIQUE(`name`, `courseID`)
);

CREATE TABLE students (
	`fname` CHAR(20) NOT NULL,
	`lname` CHAR(20) NOT NULL,

	UNIQUE (`fname`, `lname`)
);

-- Association between student and group
CREATE TABLE student_belongs (
	`groupID` INT NOT NULL,
	`studID` INT NOT NULL,

	PRIMARY KEY (`groupID`, `studID`),
	FOREIGN KEY (`groupID`) REFERENCES groups(`rowid`),
	FOREIGN KEY (`studID`) REFERENCES students(`rowid`)
);

-- Association between groups and courses
CREATE TABLE group_participate (
	`courseID` INT NOT NULL,
	`groupID` INT NOT NULL,

	PRIMARY KEY (`courseID`, `groupID`),
	FOREIGN KEY (`courseID`) REFERENCES courses(`rowid`),
	FOREIGN KEY (`groupID`) REFERENCES groups(`rowid`)
);

-- Student marks
CREATE TABLE student_mark_info (
	`componentID` INT NOT NULL,
	`studID` INT NOT NULL,
	`givenMark` INT,
	`feedback` TEXT,
	
	PRIMARY KEY (`componentID`, `studID`),
	FOREIGN KEY (`componentID`) REFERENCES components(`rowid`),
	FOREIGN KEY (`studID`) REFERENCES students(`rowid`)
);
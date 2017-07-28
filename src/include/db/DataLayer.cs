using MarkTracker.include.entities;
using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarkTracker.include.db.DataLayerConstants;

namespace MarkTracker.include.db {

    /**
     * Implementation of the Data Layer abstraction class
     */
    //public class DataLayer : DataLayerInterface {
    public class DataLayer : DataLayerInterface {

        /* Database connection handler */
        private SQLiteConnection dbConn = null;

        /* Name of currently opened database */
        private string curOpenDB = "";

        /* Constructor */
        public DataLayer() { }

        /**
         * ------------------------------------
         * DB MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region DB Management Functions

        /**
         * Creates the database / data file
         */
        public DBResult createDB(string dbName) {

            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;
            /* Check that the database file does not already exist */
            if (File.Exists(fullDBName)) {
                return new DBResult(ErrorCode.ERROR_DB_ALREADY_EXISTS);
            }

            /* Create the new data file */
            SQLiteConnection.CreateFile(fullDBName);
            return new DBResult(ErrorCode.OP_SUCCESS);
        }

        /**
         * Removes a data source
         */
        public DBResult removeDB(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;

            /* Check that the data source exists */
            if (!File.Exists(fullDBName)) {
                return new DBResult(ErrorCode.ERROR_DB_NOT_EXIST);
            }

            /* Check that the db is currently not connected or opened */
            if (this.dbConn != null && this.curOpenDB.Equals(fullDBName)) {
                return new DBResult(ErrorCode.ERROR_DB_CUR_OPENED);
            }

            /* Remove the database file */
            File.Delete(fullDBName);
            return new DBResult(ErrorCode.OP_SUCCESS);
        }

        /**
         * Check if a db with a certain name exists
         */
        public DBResult dbExists(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;
            return new DBResult(File.Exists(fullDBName));
        }

        /**
         * Open the data source
         */
        public DBResult openDB(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;

            /* Check that there is no existing open connection */
            if (this.dbConn != null
                && this.dbConn.State == System.Data.ConnectionState.Open) {

                if (this.curOpenDB.Equals(fullDBName)) {
                    return new DBResult(ErrorCode.ERROR_DB_CUR_OPENED);
                } else {
                    return new DBResult(ErrorCode.ERROR_DB_OPENED);
                }
            }

            /* Open given data source */
            this.dbConn = new SQLiteConnection("Data Source=" + fullDBName + ";Version=3;");
            this.dbConn.Open();
            this.curOpenDB = fullDBName;

            return new DBResult(ErrorCode.OP_SUCCESS);
        }

        /**
         * Close the currently opened data source
         */
        public DBResult closeDB() {
            /* Check that connection is not already closed */
            if (this.dbConn == null 
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Close connection */
            this.dbConn.Close();
            this.dbConn.Dispose();
            this.dbConn = null;
            this.curOpenDB = "";
            GC.Collect();
            return new DBResult(ErrorCode.OP_SUCCESS);
        }

        /**
         * Checks if db is currently connected
         */
        public DBResult hasConnection() {
            bool result = (this.dbConn != null &&
                this.dbConn.State == System.Data.ConnectionState.Open);
            return new DBResult(result);
        }

        /**
         * initialises the tables
         * for a data source with the given data source name
         */
        public DBResult initialiseDB() {
            /* Check that the current database is opened */
            if (this.dbConn == null 
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Attempt to create the tables */
            string sql = "";
            SQLiteCommand command = new SQLiteCommand(this.dbConn);

            /* Course table */
            sql = @"
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
                ";

            command.CommandText = sql;
            command.ExecuteNonQuery();

            /* Dispose the command object */
            command.Dispose();
            GC.Collect();   /* forced garbage collector clean up */

            return new DBResult(ErrorCode.OP_SUCCESS);
        }

        /**
         * Checks whether data source is initialised
         */
        public DBResult dbInitialised() {

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Count the number of tables in the data source.
             * There should be 8:
             *  - Course, Assessment, Component, Group, Student,
             *    student_belongs, group_participate, and smi
             */
            int numTables;
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                string sql = "SELECT count(*) as numTables FROM sqlite_master WHERE type = 'table' ORDER BY 1;";
                command.CommandText = sql;
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                numTables = Convert.ToInt32(reader["numTables"]);
            }
            if (numTables != 8) {
                return new DBResult(false);
            }
            return new DBResult(true);
        }

        #endregion

        /**
         * ------------------------------------
         * COURSE MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region Course Management Functions

        /**
         * Adds a new course into the DB with the specified name
         */
        public DBResult addNewCourse(string newCourseName) {

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* DB Result to return */
            DBResult result;

            /* Create the new course */
            /* NOTE: Assumes newCourseName is non-empty, and decently sanitised */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "INSERT INTO courses(name) VALUES ( :newCourseName )";
                    command.Parameters.Add("newCourseName", System.Data.DbType.String).Value = newCourseName;
                    command.ExecuteNonQuery();

                    /* Get the ID of the newly added course object */
                    command.Parameters.Clear();
                    command.CommandText = "SELECT rowid FROM courses WHERE name LIKE :newCourseName";
                    command.Parameters.Add("newCourseName", System.Data.DbType.String).Value = newCourseName;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int id = Convert.ToInt32(reader["rowid"]);
                    result = new DBResult(ErrorCode.OP_SUCCESS, id);

                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */

                    /* Unique constraint failed - ie duplicate entry attempted */
                    /* NOTE: Ideally, the if statement should say:
                     *      e.ErrorCode == SQLiteErrorCode.Constraint_Unique 
                     * which is more specific
                     */
                    if (e.ErrorCode == (int)SQLiteErrorCode.Constraint) {
                        result = new DBResult(ErrorCode.ERROR_COURSE_ALREADY_EXISTS);
                    }

                    /* Unknown error */
                    else {
                        result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                    }
                }
            }
            return result;
        }

        /**
         * Obtains a course object with the specified course ID
         */
        public DBResult getCourseObj(int courseID) {
            
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }
            
            DBResult result;    /* DB Result to return */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "SELECT rowid, * FROM courses WHERE rowid = :courseID";
                    command.Parameters.Add("courseID", System.Data.DbType.Int32).Value = courseID;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();
                    reader.Read();

                    /* Check if there are results */
                    if (reader.HasRows) {
                        /* Parse into course object, and attach to result */
                        Course c = new Course();
                        c.id = Convert.ToInt32(reader["rowid"]);
                        c.name = reader["name"] as string;
                        result = new DBResult(ErrorCode.OP_SUCCESS, c);
                    } else {
                        result = new DBResult(ErrorCode.ERROR_COURSE_NOT_EXIST);
                    }

                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                    /* FOR NOW, THROW ERROR UNKNOWN */
                    result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                }
            }
            return result;
        }

        /**
         * Removes a course from the DB with the specified ID
         */
        public DBResult deleteCourse(int courseID) {

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            return this.deleteRecord("courses", courseID);
        }

        /**
         * Updates a course given a course object
         */
        public DBResult updateCourse(Course c) {

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }
            
            DBResult result;    /* DB Result to return */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {

                    /* NOTE: Only the 'name' field is changeable for a course */
                    command.CommandText = "UPDATE courses SET name = :newCourseName WHERE rowid = :courseID";
                    command.Parameters.Add("courseID", System.Data.DbType.Int32).Value = c.id;
                    command.Parameters.Add("newCourseName", System.Data.DbType.String).Value = c.name;
                    command.ExecuteNonQuery();
                    result = new DBResult(ErrorCode.OP_SUCCESS);
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                    /* FOR NOW, THROW ERROR UNKNOWN */
                    result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                }
            }
            return result;
        }

        #endregion

        /**
         * ------------------------------------
         * ASSESSMENT MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region Assessment Management Functions

        /**
        * Adds a new assessment into the DB with the specified name
        */
        public DBResult addNewAssessment(string newAssessmentName, int courseID) {
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* DB Result to return */
            DBResult result;

            /* Create the new assessment */
            /* NOTE: Assumes new assessment name is non-empty, and decently sanitised */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "INSERT INTO assessments(name, courseID) VALUES ( :newAssessmentName, :courseID )";
                    command.Parameters.Add("newAssessmentName", System.Data.DbType.String).Value = newAssessmentName;
                    command.Parameters.Add("courseID", System.Data.DbType.Int32).Value = courseID;
                    command.ExecuteNonQuery();

                    /* Get the ID of the newly added assessment object */
                    command.Parameters.Clear();
                    command.CommandText = "SELECT rowid FROM assessments WHERE name LIKE :newAssessmentName";
                    command.Parameters.Add("newAssessmentName", System.Data.DbType.String).Value = newAssessmentName;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int id = Convert.ToInt32(reader["rowid"]);
                    result = new DBResult(ErrorCode.OP_SUCCESS, id);

                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */

                    /* Unique constraint failed - ie duplicate entry attempted */
                    /* NOTE: Ideally, the if statement should say:
                     *      e.ErrorCode == SQLiteErrorCode.Constraint_Unique 
                     * which is more specific
                     */
                    if (e.ErrorCode == (int)SQLiteErrorCode.Constraint) {
                        result = new DBResult(ErrorCode.ERROR_ASSESSMENT_ALREADY_EXISTS);
                    }

                    /* Unknown error */
                    else {
                        result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                    }
                }
            }
            return result;
        }

        /**
         * Obtains an assessment object with the specified course ID
         */
        public DBResult getAssessmentObj(int assessmentID) {
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            DBResult result;    /* DB Result to return */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "SELECT rowid, * FROM assessments WHERE rowid = :assessmentID";
                    command.Parameters.Add("assessmentID", System.Data.DbType.Int32).Value = assessmentID;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();
                    reader.Read();

                    /* Check if there are results */
                    if (reader.HasRows) {
                        /* Parse into course object, and attach to result */
                        Assessment a = new Assessment();
                        a.id = Convert.ToInt32(reader["rowid"]);
                        a.name = reader["name"] as string;
                        a.dueDate = Convert.ToDateTime(reader["dueDateTime"] as string);
                        a.availableMarks = Convert.ToInt32(reader["marks"]);
                        a.weighting = Convert.ToInt32(reader["weighting"]);
                        a.comments = reader["comments"] as string;
                        result = new DBResult(ErrorCode.OP_SUCCESS, a);
                    } else {
                        result = new DBResult(ErrorCode.ERROR_ASSESSMENT_NOT_EXIST);
                    }

                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                    /* FOR NOW, THROW ERROR UNKNOWN */
                    result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                }
            }
            return result;
        }

        /**
         * Removes an assessmente from the DB with the specified ID
         */
        public DBResult deleteAssessment(int assessmentID) {
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            return this.deleteRecord("assessments", assessmentID);
        }

        /**
         * Updates an assessment given a assessment object
         */
        public DBResult updateAssessment(Assessment a) {
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            DBResult result;    /* DB Result to return */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = @"
                        UPDATE assessments SET 
                            name = :newAssessmentName,
                            dueDateTime = :newDueDateTime,
                            marks = :newMark,
                            weighting = :newWeighting,
                            comments = :newComments
                        WHERE rowid = :assessmentID";
                    command.Parameters.Add("assessmentID", System.Data.DbType.Int32).Value = a.id;
                    command.Parameters.Add("newAssessmentName", System.Data.DbType.String).Value = a.name;
                    command.Parameters.Add("newDueDateTime", System.Data.DbType.String).Value = a.dueDate;
                    command.Parameters.Add("newMark", System.Data.DbType.Int32).Value = a.availableMarks;
                    command.Parameters.Add("newWeighting", System.Data.DbType.Int32).Value = a.weighting;
                    command.Parameters.Add("newComments", System.Data.DbType.String).Value = a.comments;
                    command.ExecuteNonQuery();
                    result = new DBResult(ErrorCode.OP_SUCCESS);
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                    /* FOR NOW, THROW ERROR UNKNOWN */
                    result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                }
            }
            return result;
        }

        #endregion

        /**
         * ------------------------------------
         * COMPONENT MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region Component Management Functions

        /**
         * Adds a new component given minimal info.
         * "parentComponentID":         null when creating a root component
         * "associatedAssessmentID":    null when creating a child component
         */
        public DBResult addNewComponent(string newComponentName,
                            Nullable<int> parentComponentID,
                            Nullable<int> associatedAssessmentID) {
            return new DBResult(DataLayerConstants.ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Obtains a component object with the specified ID
         */
        public DBResult getComponentObj(int componentID) {
            return null;
        }

        /**
         * Removes a component from the DB with the specified ID
         */
        public DBResult deleteComponent(int componentID) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Updates a component given a component object
         */
        public DBResult updateComponent(AssessmentComponent ac) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        #endregion

        /**
         * ------------------------------------
         * GROUP MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region Group Management Functions

        /**
        * Adds a new group into the DB with the specified name
        * and associated course
        */
        public DBResult addNewGroup(string newGroupName, int associatedCourse) {
            return new DBResult(DataLayerConstants.ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Obtains a group object with the specified ID
         */
        public DBResult getGroupObj(int groupID) {
            return new DBResult(null);
        }

        /**
         * Removes a group from the DB with the specified ID
         */
        public DBResult deleteGroup(int groupID) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Updates a group given a group object
         */
        public DBResult updateGroup(Group g) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        #endregion

        /**
        * ------------------------------------
        * STUDENT MANAGEMENT FUNCTIONS
        * ------------------------------------
        */
        #region Student Management Functions

        /**
        * Adds a new student into the DB with the specified name
        * and associated group id
        */
        public DBResult addNewStudent(string newStudentName, int groupID) {
            return new DBResult(DataLayerConstants.ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Obtains a student object with the specified ID
         */
        public DBResult getStudentObj(int studentID) {
            return new DBResult(null);
        }

        /**
         * Removes a student from the DB with the specified ID
         * and course ID
         */
        public DBResult deleteStudent(int studentID, int courseID) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Updates a student given a student object
         */
        public DBResult updateStudent(Student s) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }


        #endregion

        /**
        * ------------------------------------
        * SMI MANAGEMENT FUNCTIONS
        * ------------------------------------
        */
        #region Student Mark Info Management Functions

        /**
         * Create a new student mark record
         */
        public DBResult addNewStudentMark(int studentID, int componentID) {
            return new DBResult(DataLayerConstants.ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Obtains a student mark given the student and component IDs
         */
        public DBResult getStudentMark(int studentID, int componentID) {
            return new DBResult(null);
        }

        /**
         * Updates the student mark into the database
         * given an SMI object
         */
        public DBResult updateStudentMark(StudentMarkInfo smi) {
            return new DBResult(DataLayerConstants.ErrorCode.ERROR_UNKNOWN);
        }

        #endregion

        /**
         * ------------------------------------
         * OTHER USEFUL FUNCTIONS
         * ------------------------------------
         */
        #region Other useful functions

        /**
         * Update only the name field of a particular record.
         */
        public DBResult updateName(EntityConstants.EntityType type, 
                                    int id, string newName) {
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed)
            {
                Console.WriteLine("Error: DB not yet opened");
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }
            
            try {
                SQLiteCommand command;
                using (command = new SQLiteCommand(this.dbConn)) {

                    /* Construct the appropriate SQL */
                    switch (type) {
                        case EntityConstants.EntityType.Course:
                            command.CommandText = "UPDATE courses SET name = :newName WHERE rowid = :id";
                            command.Parameters.Add("newName", System.Data.DbType.String).Value = newName;
                            command.Parameters.Add("id", System.Data.DbType.Int32).Value = id;
                            break;

                        case EntityConstants.EntityType.Assessment:
                            command.CommandText = "UPDATE assessments SET name = :newName WHERE rowid = :id";
                            command.Parameters.Add("newName", System.Data.DbType.String).Value = newName;
                            command.Parameters.Add("id", System.Data.DbType.Int32).Value = id;
                            break;

                        case EntityConstants.EntityType.Component:
                            command.CommandText = "UPDATE components SET name = :newName WHERE rowid = :id";
                            command.Parameters.Add("newName", System.Data.DbType.String).Value = newName;
                            command.Parameters.Add("id", System.Data.DbType.Int32).Value = id;
                            break;

                        case EntityConstants.EntityType.Group:
                            command.CommandText = "UPDATE groups SET name = :newName WHERE rowid = :id";
                            command.Parameters.Add("newName", System.Data.DbType.String).Value = newName;
                            command.Parameters.Add("id", System.Data.DbType.Int32).Value = id;
                            break;

                        case EntityConstants.EntityType.Student:
                            /* 'name' for student is a little different
                             * - needs to be parsed into firstname and lastname */
                            /* FOR NOW, FIXED SPACE DELIMITERED FORMAT. ASSUMES VALID SPLIT */
                            string[] nameComponents = newName.Split(' ');
                            command.CommandText = "UPDATE students SET fname = :fname, lname = :lname WHERE rowid = :id";
                            command.Parameters.Add("fname", System.Data.DbType.String).Value = nameComponents[0];
                            command.Parameters.Add("lname", System.Data.DbType.String).Value = nameComponents[1];
                            command.Parameters.Add("id", System.Data.DbType.Int32).Value = id;
                            break;

                        default:        /* should not get here */
                            Console.WriteLine("REACHED UNREACHABLE SPOT function 'updateName' from DB!");
                            break;  
                    }
                    command.ExecuteNonQuery();
                }

            } catch (SQLiteException e) {
                Console.WriteLine("DB Error: " + e.Message);
                /* SQL update error handlers go here */
                /* FOR NOW, THROW ERROR UNKNOWN */
                return new DBResult(ErrorCode.ERROR_UNKNOWN);
            }

            return new DBResult(DataLayerConstants.ErrorCode.OP_SUCCESS);
        }

        /**
         * Obtain a list of all root nodes (ie course nodes) from data source,
         * attaching all child nodes appropriately (ie assessments and components)
         */
        public List<UITreeViewNode> getAllAPNodes(ContextMenuStrip courseCMS, ContextMenuStrip assessmentCMS, ContextMenuStrip componentCMS) {

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                Console.WriteLine("Error: DB not yet opened");
                return new List<UITreeViewNode>();
            }

            List<UITreeViewNode> result = new List<UITreeViewNode>();    /* Holds the final result */

            /* Get the list of courses */
            List<UITreeViewNode> courseNodes = this.getAllCourseNodes(courseCMS);
            result.AddRange(courseNodes);   /* NOTE: Because of the way a TreeView works, 
                                             * We ONLY add the course nodes, and attach the 
                                             * assessments to it (and then components to 
                                             * assessessments). */

            foreach (UITreeViewNode courseNode in courseNodes) {

                /* Attach all assessments for this course */
                List<UITreeViewNode> assessmentNodes = this.getAllAssessmentNodes(courseNode.id, courseNode, assessmentCMS);
                foreach (UITreeViewNode assessmentNode in assessmentNodes) {

                    /* Attach all component nodes for this assessment, and components to components */
                    List<UITreeViewNode> componentNodes = this.getAllComponentNodes(assessmentNode.id, assessmentNode, componentCMS);
                }
            }

            return result;
        }

        /**
         * Obtain a list of all participant nodes related to a particular course
         */
        public List<UITreeViewNode> getAllPPNodes(int courseID,
                                           ContextMenuStrip groupCMS,
                                           ContextMenuStrip studentCMS) {
            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                Console.WriteLine("Error: DB not yet opened");
                return new List<UITreeViewNode>();
            }

            List<UITreeViewNode> result = new List<UITreeViewNode>();    /* Holds the final result */

            /* Get the list of group nodes */
            List<UITreeViewNode> groupNodes = this.getAllGroupNodes(courseID, groupCMS);
            result.AddRange(groupNodes);   /* NOTE: Because of the way a TreeView works, 
                                             * We ONLY add the group nodes, and attach the 
                                             * assessments to it (and then components to 
                                             * assessessments). Similar to courses */

            /* Attach all students for this group */
            foreach (UITreeViewNode groupNode in groupNodes) {
                this.getAllStudentNodes(groupNode.id, groupNode, studentCMS);
            }

            return result;
        }

        /**
         * Retrieve the number of records across all tables
         */
        public void showDBCount() {

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                Console.WriteLine("Error: DB not yet opened");
                return;
            }

            SQLiteCommand command;
            SQLiteDataReader reader;
            string sql;
            try {

                using (command = new SQLiteCommand(this.dbConn)) {
                    sql = "SELECT COUNT(*) AS count FROM courses;";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine("Num courses: " + reader["count"]);
                }

                using (command = new SQLiteCommand(this.dbConn)) {
                    sql = "SELECT COUNT(*) AS count FROM assessments;";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine("Num assessents: " + reader["count"]);
                }

                using (command = new SQLiteCommand(this.dbConn)) {
                    sql = "SELECT COUNT(*) AS count FROM components;";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine("Num components: " + reader["count"]);
                }

                using (command = new SQLiteCommand(this.dbConn)) {
                    sql = "SELECT COUNT(*) AS count FROM groups;";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine("Num groups: " + reader["count"]);
                }

                using (command = new SQLiteCommand(this.dbConn)) {
                    sql = "SELECT COUNT(*) AS count FROM students;";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    reader.Read();
                    Console.WriteLine("Num studentse: " + reader["count"]);
                }

            } catch (SQLiteException e) {
                Console.WriteLine("DB Error: " + e.Message);
                /* SQL update error handlers go here */
                /* FOR NOW, THROW ERROR UNKNOWN */
            }
        }

        #endregion

        /**
         * Functions private to this class
         */
        #region Private functions

        /**
         * Return a list of course nodes as UITreeViewNodes
         * NOTE: Assumes DB connection is open and connected
         */
        private List<UITreeViewNode> getAllCourseNodes(ContextMenuStrip courseCMS) {
            List<UITreeViewNode> result = new List<UITreeViewNode>();   /* Hold the final result */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    string sql = "SELECT rowid,* FROM courses;";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();

                    /* Read all the records */
                    while (reader.Read()) {
                        UITreeViewNode courseNode = new UITreeViewNode(
                                EntityConstants.EntityType.Course,
                                Convert.ToString(reader["name"]),
                                null,       /* Courses have no parent nodes */
                                courseCMS
                            );
                        courseNode.id = Convert.ToInt32(reader["rowid"]);
                        result.Add(courseNode);
                    }
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                }
            }
            return result;
        }

        /**
         * Return a list of assessment nodes as UITreeViewNodes
         * NOTE: Assumes DB connection is open and connected
         */
        private List<UITreeViewNode> getAllAssessmentNodes(int courseID, UITreeViewNode courseNode, ContextMenuStrip assessmentCMS) {

            List<UITreeViewNode> result = new List<UITreeViewNode>();   /* Hold the final result */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "SELECT rowid,* FROM assessments WHERE courseID = :courseID";
                    command.Parameters.Add("courseID", System.Data.DbType.Int32).Value = courseID;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();

                    /* Read all the records */
                    while (reader.Read()) {
                        UITreeViewNode assessmentNode = new UITreeViewNode(
                                    EntityConstants.EntityType.Assessment,
                                    Convert.ToString(reader["name"]),
                                    courseNode,       /* Parent of this assessment is given courseNode */
                                    assessmentCMS
                            );
                        assessmentNode.id = Convert.ToInt32(reader["rowid"]);
                        courseNode.Nodes.Add(assessmentNode);       /* Hook this assessment node to course node */
                        result.Add(assessmentNode);
                    }
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                }
            }
            return result;
        }

        //this.getAllComponentNodes(assessmentNode.id);
        /**
         * Return a list of component nodes as UITreeViewNodes
         * NOTE: Assumes DB connection is open and connected
         */
        private List<UITreeViewNode> getAllComponentNodes(int assessmentID, UITreeViewNode assessmentNode, ContextMenuStrip componentCMS) {

            List<UITreeViewNode> result = new List<UITreeViewNode>();
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    /* NOTE: This is a hacky method to obtain components and 
                     * hook them to each other appropriately, exploiting the
                     * fact that the componentID < parentID.
                     * 
                     * This sql statement provides the records with the above
                     * property. In particular, it'll show the components in 
                     * increasing tree depth (root -> 1st level -> 2nd level etc.) */
                    command.CommandText = @"SELECT rowid,* FROM components 
                            WHERE (assessmentID = :assessmentID)
                            ORDER BY parentComponent ASC, rowid ASC;";
                    command.Parameters.Add("assessmentID", System.Data.DbType.Int32).Value = assessmentID;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();

                    /* Read all the records */
                    while (reader.Read()) {
                        UITreeViewNode componentNode = new UITreeViewNode(
                                EntityConstants.EntityType.Component,
                                Convert.ToString(reader["name"]),
                                null,      /* For now, component is attached to nothing */
                                componentCMS
                            );
                        componentNode.id = Convert.ToInt32(reader["rowid"]);

                        /* Find the correct assessment / component node to hook */
                        /* Case when the component is root level */
                        if (reader.IsDBNull(reader.GetOrdinal("parentComponent"))) {
                            assessmentNode.Nodes.Add(componentNode);       /* Hook this assessment node to course node */
                            componentNode.parentNode = assessmentNode;
                        }

                        /* Case when parent component is another component */
                        else {
                            /* Find the parent component */
                            int parentComponentNodeID = Convert.ToInt32(reader["parentComponent"]);

                            /* NOTE: This is hacky!! (Because 'result' is 
                             * guaranteed to contain the parent node. 
                             * Refer to the note earlier in this function */
                            UITreeViewNode parentComponentNode = null;          /* Assigned null to remove compiler issues */
                            foreach (UITreeViewNode cnode in result) {          /* NOTE: This is also a linear search in a sorted list.
                                                                                 * Further optimisations can be done, eg binary search. */
                                if (cnode.id == parentComponentNodeID) {
                                    parentComponentNode = cnode;
                                    break;
                                }
                            }
                            parentComponentNode.Nodes.Add(componentNode);
                            componentNode.parentNode = parentComponentNode;
                        }
                        result.Add(componentNode);
                    }
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                }
            } 
            return result;
        }

        /**
         * Obtain all groups as UITreeViewNodes 
         * NOTE: Assumes DB connection is open and connected
         */
        private List<UITreeViewNode> getAllGroupNodes(int courseID, ContextMenuStrip groupCMS) {
            List<UITreeViewNode> result = new List<UITreeViewNode>();   /* Hold the final result */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "SELECT rowid,* FROM groups WHERE courseID = :courseID";
                    command.Parameters.Add("courseID", System.Data.DbType.Int32).Value = courseID;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();

                    /* Read all the records */
                    while (reader.Read()) {
                        UITreeViewNode groupNode = new UITreeViewNode(
                                EntityConstants.EntityType.Group,
                                Convert.ToString(reader["name"]),
                                null,       /* Groups have no parent nodes */
                                groupCMS
                            );
                        groupNode.id = Convert.ToInt32(reader["rowid"]);
                        result.Add(groupNode);
                    }
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                }
            } 
            return result;
        }

        /**
         * Obtain all the students as UITreeView nodes, corr to a particular group
         * NOTE: Assumes open DB Connection
         */
        private List<UITreeViewNode> getAllStudentNodes(int groupID, UITreeViewNode groupNode, ContextMenuStrip studentCMS) {
            List<UITreeViewNode> result = new List<UITreeViewNode>();
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = @"
                            SELECT 
                            s.rowid, s.fname || ' ' || s.lname AS studName
                            FROM students s
                            LEFT JOIN student_belongs sb
                            WHERE (
	                            sb.groupID = :groupID AND
	                            sb.studID = s.rowid
                            );";
                    command.Parameters.Add("groupID", System.Data.DbType.Int32).Value = groupID;
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();

                    /* Read all the records */
                    while (reader.Read()) {
                        UITreeViewNode studentNode = new UITreeViewNode(
                                    EntityConstants.EntityType.Student,
                                    Convert.ToString(reader["studName"]),
                                    groupNode,       /* Parent of this student is given groupNode */
                                    studentCMS
                            );
                        studentNode.id = Convert.ToInt32(reader["rowid"]);
                        groupNode.Nodes.Add(studentNode);       /* Hook this assessment node to course node */
                        result.Add(studentNode);
                    }
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                }
            }
            return result;
        }

        /**
         * Removes a specific record from a table.
         * Assumes DB connection is open.
         */
        private DBResult deleteRecord(string tableName, int recordID) {
            DBResult result;    /* DB Result to return */
            using (SQLiteCommand command = new SQLiteCommand(this.dbConn)) {
                try {
                    command.CommandText = "DELETE FROM :tableName WHERE rowid = :recordID";
                    command.Parameters.Add("tableName", System.Data.DbType.String).Value = tableName;
                    command.Parameters.Add("recordID", System.Data.DbType.Int32).Value = recordID;
                    command.ExecuteNonQuery();
                    result = new DBResult(ErrorCode.OP_SUCCESS);
                } catch (SQLiteException e) {
                    Console.WriteLine("DB Error: " + e.Message);
                    /* SQL update error handlers go here */
                    /* FOR NOW, THROW ERROR UNKNOWN */
                    result = new DBResult(ErrorCode.ERROR_UNKNOWN);
                }
            }
            return result;
        }

        #endregion
    }
}

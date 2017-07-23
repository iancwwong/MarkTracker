using MarkTracker.include.entities;
using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

            /* Count the number of tables in the data source.
             * There should be 8:
             *  - Course, Assessment, Component, Group, Student,
             *    student_belongs, group_participate, and smi
             */
            string sql = "SELECT count(*) as numTables FROM sqlite_master WHERE type = 'table' ORDER BY 1;";
            SQLiteCommand command = new SQLiteCommand(sql, this.dbConn);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            int numTables = Convert.ToInt32(reader["numTables"]);
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

            /* DB Result to return */
            DBResult result;

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Prepare command object */
            SQLiteCommand command = new SQLiteCommand(this.dbConn);

            /* Create the new course */
            /* NOTE: Assumes newCourseName is sanitised */
            string sql = "INSERT INTO courses(name) VALUES ('" + newCourseName + "');";
            try {
                command.CommandText = sql;
                command.ExecuteNonQuery();

                /* Get the ID of the newly added course object */
                sql = "SELECT rowid FROM courses WHERE name LIKE '" + newCourseName + "';";
                command.CommandText = sql;
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

            } finally {
                /* Dispose the command object */
                command.Dispose();
                GC.Collect();   /* forced garbage collector clean up */
            }
            return result;
        }

        /**
         * Obtains a course object with the specified course ID
         */
        public DBResult getCourseObj(int courseID) {

            /* DB Result to return */
            DBResult result;

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Attempt to retrieve the course using the id */
            SQLiteCommand command = new SQLiteCommand(this.dbConn);
            try {
                string sql = "SELECT rowid,name FROM courses WHERE rowid = " + courseID + ";";
                command.CommandText = sql;
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
            } finally {
                /* Dispose the command object */
                command.Dispose();
                GC.Collect();   /* forced garbage collector clean up */
            }

            return result;
        }

        /**
         * Removes a course from the DB with the specified ID
         */
        public DBResult deleteCourse(int courseID) {

            /* DB Result to return */
            DBResult result;

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Attempt to retrieve the course using the id */
            SQLiteCommand command = new SQLiteCommand(this.dbConn);
            try {
                string sql = "DELETE FROM courses WHERE rowid = " + courseID + ";";
                command.CommandText = sql;
                command.ExecuteNonQuery();
                result = new DBResult(ErrorCode.OP_SUCCESS);

            } catch (SQLiteException e) {
                Console.WriteLine("DB Error: " + e.Message);
                /* SQL update error handlers go here */
                /* FOR NOW, THROW ERROR UNKNOWN */
                result = new DBResult(ErrorCode.ERROR_UNKNOWN);
            } finally {
                /* Dispose the command object */
                command.Dispose();
                GC.Collect();   /* forced garbage collector clean up */
            }

            return result;
        }

        /**
         * Updates a course given a course object
         */
        public DBResult updateCourse(Course c) {

            /* DB Result to return */
            DBResult result;

            /* Check that the current database is opened */
            if (this.dbConn == null
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return new DBResult(ErrorCode.ERROR_DB_CLOSED);
            }

            /* Attempt to retrieve the course using the id */
            SQLiteCommand command = new SQLiteCommand(this.dbConn);
            try {

                /* NOTE: We only need to change the name */
                string sql = 
                    @"UPDATE courses SET name = '" + c.name + "' WHERE rowid = " + c.id + ";";
                command.CommandText = sql;
                command.ExecuteNonQuery();
                result = new DBResult(ErrorCode.OP_SUCCESS);

            } catch (SQLiteException e) {
                Console.WriteLine("DB Error: " + e.Message);
                /* SQL update error handlers go here */
                /* FOR NOW, THROW ERROR UNKNOWN */
                result = new DBResult(ErrorCode.ERROR_UNKNOWN);
            } finally {
                /* Dispose the command object */
                command.Dispose();
                GC.Collect();   /* forced garbage collector clean up */
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
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Obtains an assessment object with the specified course ID
         */
        public DBResult getAssessmentObj(int assessmentID) {
            return new DBResult(null);
        }

        /**
         * Removes an assessmente from the DB with the specified ID
         */
        public DBResult deleteAssessment(int assessmentID) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Updates an assessment given a assessment object
         */
        public DBResult updateAssessment(Assessment a) {
            return new DBResult(ErrorCode.ERROR_UNKNOWN);
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
            return new DBResult(DataLayerConstants.ErrorCode.ERROR_UNKNOWN);
        }

        /**
         * Obtain a list of all course-assessment nodes from data source
         */
        public List<UITreeViewNode> getAllAPNodes() {
            return new List<UITreeViewNode>();
        }

        /**
         * Obtain a list of all participant nodes related to a particular course
         */
        public List<UITreeViewNode> getAllPPNodes(int courseID) {
            return new List<UITreeViewNode>();
        }

        #endregion

    }
}

﻿using MarkTracker.include.entities;
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
        public ErrorCode createDB(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;
            /* Check that the database file does not already exist */
            if (File.Exists(fullDBName)) {
                return ErrorCode.ERROR_DB_ALREADY_EXISTS;
            }

            /* Create the new data file */
            SQLiteConnection.CreateFile(fullDBName);
            return ErrorCode.OP_SUCCESS;
        }

        /**
         * Removes a data source
         */
        public ErrorCode removeDB(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;

            /* Check that the data source exists */
            if (!File.Exists(fullDBName)) {
                return ErrorCode.ERROR_DB_NOT_EXIST;
            }

            /* Check that the db is currently not connected */
            if (this.dbConn != null && this.curOpenDB.Equals(fullDBName)) {
                return ErrorCode.ERROR_DB_CUR_OPENED;
            }

            /* Remove the database file */
            File.Delete(fullDBName);
            return ErrorCode.OP_SUCCESS;
        }

        /**
         * Check if a db with a certain name exists
         */
        public bool dbExists(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;
            return File.Exists(fullDBName);
        }

        /**
         * Open the data source
         */
        public ErrorCode openDB(string dbName) {
            string fullDBName = dbName + DataLayerConstants.DB_FILE_EXTENSION;

            /* Check that there is no existing open connection */
            if (this.dbConn != null
                && this.dbConn.State == System.Data.ConnectionState.Open) {

                if (this.curOpenDB.Equals(fullDBName)) {
                    return ErrorCode.ERROR_DB_CUR_OPENED;
                } else {
                    return ErrorCode.ERROR_DB_OPENED;
                }
            }

            /* Open given data source */
            this.dbConn = new SQLiteConnection("Data Source=" + fullDBName + ";Version=3;");
            this.dbConn.Open();
            this.curOpenDB = fullDBName;
            return ErrorCode.OP_SUCCESS;
        }

        /**
         * Close the currently opened data source
         */
        public ErrorCode closeDB() {
            /* Check that connection is not already closed */
            if (this.dbConn == null 
                || this.dbConn.State == System.Data.ConnectionState.Closed) {
                return ErrorCode.ERROR_DB_CLOSED;
            }

            /* Close connection */
            this.dbConn.Close();
            this.dbConn = null;
            this.curOpenDB = "";
            return ErrorCode.OP_SUCCESS;
        }

        /**
         * Checks if db is currently connected
         */
        public bool hasConnection() {
            return (this.dbConn != null && this.dbConn.State == System.Data.ConnectionState.Open);
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
        public ErrorCode addNewCourse(string newCourseName) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
        }

        /**
         * Obtains a course object with the specified course ID
         */
        public Course getCourseObj(int courseID) {
            return null;
        }

        /**
         * Removes a course from the DB with the specified ID
         */
        public ErrorCode deleteCourse(int courseID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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
        public ErrorCode addNewAssessment(string newAssessmentName, int courseID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
        }

        /**
         * Obtains an assessment object with the specified course ID
         */
        public Assessment getAssessmentObj(int assessmentID) {
            return null;
        }

        /**
         * Removes an assessmente from the DB with the specified ID
         */
        public ErrorCode deleteAssessment(int assessmentID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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
        public ErrorCode addNewComponent(string newComponentName,
                            Nullable<int> parentComponentID,
                            Nullable<int> associatedAssessmentID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
        }

        /**
         * Obtains a component object with the specified ID
         */
        public AssessmentComponent getComponentObj(int componentID) {
            return null;
        }

        /**
         * Removes a component from the DB with the specified ID
         */
        public ErrorCode deleteComponent(int componentID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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
        public ErrorCode addNewGroup(string newGroupName, int associatedCourse) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
        }

        /**
         * Obtains a group object with the specified ID
         */
        public Group getGroupObj(int groupID) {
            return null;
        }

        /**
         * Removes a group from the DB with the specified ID
         */
        public ErrorCode deleteGroup(int groupID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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
        public ErrorCode addNewStudent(string newStudentName, int groupID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
        }

        /**
         * Obtains a student object with the specified ID
         */
        public Student getStudentObj(int studentID) {
            return null;
        }

        /**
         * Removes a student from the DB with the specified ID
         * and course ID
         */
        public ErrorCode deleteStudent(int studentID, int courseID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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
        public ErrorCode addNewStudentMark(int studentID, int componentID) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
        }

        /**
         * Obtains a student mark given the student and component IDs
         */
        public StudentMarkInfo getStudentMark(int studentID, int componentID) {
            return null;
        }

        /**
         * Updates the student mark into the database
         * given an SMI object
         */
        public ErrorCode saveStudentMark(StudentMarkInfo smi) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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
        public ErrorCode updateName(EntityConstants.EntityType type, 
                                    int id, string newName) {
            return DataLayerConstants.ErrorCode.ERROR_UNKNOWN;
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

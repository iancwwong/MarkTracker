using MarkTracker.include.entities;
using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.db {

    /**
     * Implementation of the Data Layer abstraction class
     */
    //public class DataLayer : DataLayerInterface {
    public class DataLayer : DataLayerInterface {

        /**
         * ------------------------------------
         * DB MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region DB Management Functions

        /**
         * Creates the database / data file
         */
        public int createDB(string dbName) {
            return -1;
        }

        /**
         * Removes a data source
         */
        public int removeDB(string dbName) {
            return -1;
        }

        /**
         * Check if a db with a certain name exists
         */
        public bool dbExists(string dbName) {
            return false;
        }

        /**
         * Open the data source
         */
        public int openDB(string dbName) {
            return -1;
        }

        /**
         * Close the currently opened data source
         */
        public int closeDB() {
            return -1;
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
        public int addNewCourse(string newCourseName) {
            return -1;
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
        public int deleteCourse(int courseID) {
            return -1;
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
        public int addNewAssessment(string newAssessmentName, int courseID) {
            return -1;
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
        public int deleteAssessment(int assessmentID) {
            return -1;
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
        public int addNewComponent(string newComponentName,
                            Nullable<int> parentComponentID,
                            Nullable<int> associatedAssessmentID) {
            return -1;
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
        public int deleteComponent(int componentID) {
            return -1;
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
        public int addNewGroup(string newGroupName, int associatedCourse) {
            return -1;
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
        public int deleteGroup(int groupID) {
            return -1;
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
        public int addNewStudent(string newStudentName, int groupID) {
            return -1;
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
        public int deleteStudent(int studentID, int courseID) {
            return -1;
        }

        #endregion

        /**
        * ------------------------------------
        * SMI MANAGEMENT FUNCTIONS
        * ------------------------------------
        */
        #region Student Mark Info Management Functions

        /**
         * Obtains a student mark given the student and component IDs
         */
        public StudentMarkInfo getStudentMark(int studentID, int componentID) {
            return null;
        }

        /**
         * Updates the student mark into the database
         */
        public int saveStudentMark(StudentMarkInfo smi) {
            return -1;
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
        public int updateName(EntityConstants.EntityType type, int id, string newName) {
            return -1;
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

using MarkTracker.include.entities;
using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarkTracker.include.db.DataLayerConstants;

namespace MarkTracker.include.db {

    /**
     * Functions that allow the application to interact
     * with the database / data layer.
     * 
     * This class is also responsible for the conversion between 
     * objects and relations (to and from data source)
     */
    public interface DataLayerInterface {

        /**
         * ------------------------------------
         * DB MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region DB Management Functions

        /**
         * Creates the database / data file
         */
        ErrorCode createDB(string dbName);

        /**
         * Removes a data source
         */
        ErrorCode removeDB(string dbName);

        /**
         * Check if a db with a certain name exists
         */
        bool dbExists(string dbName);

        /**
         * Open the data source
         */
        ErrorCode openDB(string dbName);

        /**
         * Close the currently opened data source
         */
        ErrorCode closeDB();

        /**
         * Checks if db is currently connected
         */
        bool hasConnection();

        /**
         * Creates and initialises the tables
         * for a data source with the given data source name
         */
        ErrorCode initialiseDB();

        /**
         * Checks whether data source is initialised
         */
        bool dbInitialised();

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
        ErrorCode addNewCourse(string newCourseName);

        /**
         * Obtains a course object with the specified course ID
         */
        Course getCourseObj(int courseID);

        /**
         * Removes a course from the DB with the specified ID
         */
        ErrorCode deleteCourse(int courseID);

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
        ErrorCode addNewAssessment(string newAssessmentName, int courseID);

        /**
         * Obtains an assessment object with the specified course ID
         */
        Assessment getAssessmentObj(int assessmentID);

        /**
         * Removes an assessmente from the DB with the specified ID
         */
        ErrorCode deleteAssessment(int assessmentID);

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
        ErrorCode addNewComponent(string newComponentName, 
                            Nullable<int> parentComponentID,        
                            Nullable<int> associatedAssessmentID);

        /**
         * Obtains a component object with the specified ID
         */
        AssessmentComponent getComponentObj(int componentID);

        /**
         * Removes a component from the DB with the specified ID
         */
        ErrorCode deleteComponent(int componentID);

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
        ErrorCode addNewGroup(string newGroupName, int associatedCourse);

        /**
         * Obtains a group object with the specified ID
         */
        Group getGroupObj(int groupID);

        /**
         * Removes a group from the DB with the specified ID
         */
        ErrorCode deleteGroup(int groupID);

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
        ErrorCode addNewStudent(string newStudentName, int groupID);

        /**
         * Obtains a student object with the specified ID
         */
        Student getStudentObj(int studentID);

        /**
         * Removes a student from the DB with the specified ID
         * and course ID
         */
        ErrorCode deleteStudent(int studentID, int courseID);

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
        ErrorCode addNewStudentMark(int studentID, int componentID);

        /**
         * Obtains a student mark given the student and component IDs
         */
        StudentMarkInfo getStudentMark(int studentID, int componentID);

        /**
         * Updates the student mark into the database
         * given an SMI object
         */
        ErrorCode saveStudentMark(StudentMarkInfo smi);

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
        ErrorCode updateName(EntityConstants.EntityType type, int id, string newName);

        /**
         * Obtain a list of all course-assessment nodes from data source
         */
        List<UITreeViewNode> getAllAPNodes();

        /**
         * Obtain a list of all participant nodes related to a particular course
         */
        List<UITreeViewNode> getAllPPNodes(int courseID);

        #endregion

    }
}

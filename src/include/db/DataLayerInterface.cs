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
        DBResult createDB(string dbName);

        /**
         * Removes a data source
         */
        DBResult removeDB(string dbName);

        /**
         * Check if a db with a certain name exists
         */
        DBResult dbExists(string dbName);

        /**
         * Open the data source
         */
        DBResult openDB(string dbName);

        /**
         * Close the currently opened data source
         */
        DBResult closeDB();

        /**
         * Checks if db is currently connected
         */
        DBResult hasConnection();

        /**
         * Creates and initialises the tables
         * for a data source with the given data source name
         */
        DBResult initialiseDB();

        /**
         * Checks whether data source is initialised
         */
        DBResult dbInitialised();

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
        DBResult addNewCourse(string newCourseName);

        /**
         * Obtains a course object with the specified course ID
         */
        DBResult getCourseObj(int courseID);

        /**
         * Removes a course from the DB with the specified ID
         */
        DBResult deleteCourse(int courseID);

        /**
         * Updates a course given a course object
         */
        DBResult updateCourse(Course c);

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
        DBResult addNewAssessment(string newAssessmentName, int courseID);

        /**
         * Obtains an assessment object with the specified course ID
         */
        DBResult getAssessmentObj(int assessmentID);

        /**
         * Removes an assessmente from the DB with the specified ID
         */
        DBResult deleteAssessment(int assessmentID);

        /**
         * Updates an assessment given a assessment object
         */
        DBResult updateAssessment(Assessment a);

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
        DBResult addNewComponent(string newComponentName, 
                            Nullable<int> parentComponentID,        
                            Nullable<int> associatedAssessmentID);

        /**
         * Obtains a component object with the specified ID
         */
        DBResult getComponentObj(int componentID);

        /**
         * Removes a component from the DB with the specified ID
         */
        DBResult deleteComponent(int componentID);

        /**
         * Updates a component given a component object
         */
        DBResult updateComponent(AssessmentComponent ac);

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
        DBResult addNewGroup(string newGroupName, int associatedCourse);

        /**
         * Obtains a group object with the specified ID
         */
        DBResult getGroupObj(int groupID);

        /**
         * Removes a group from the DB with the specified ID
         */
        DBResult deleteGroup(int groupID);

        /**
         * Updates a group given a group object
         */
        DBResult updateGroup(Group g);

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
        DBResult addNewStudent(string newStudentName, int groupID);

        /**
         * Obtains a student object with the specified ID
         */
        DBResult getStudentObj(int studentID);

        /**
         * Removes a student from the DB with the specified ID
         * and course ID
         */
        DBResult deleteStudent(int studentID, int courseID);

        /**
         * Updates a student given a student object
         */
        DBResult updateStudent(Student s);

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
        DBResult addNewStudentMark(int studentID, int componentID);

        /**
         * Obtains a student mark given the student and component IDs
         */
        DBResult getStudentMark(int studentID, int componentID);

        /**
         * Updates the student mark into the database
         * given an SMI object
         */
        DBResult updateStudentMark(StudentMarkInfo smi);

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
        DBResult updateName(EntityConstants.EntityType type, int id, string newName);

        /**
         * Obtain a list of all course-assessment nodes from data source
         */
        List<UITreeViewNode> getAllAPNodes();

        /**
         * Obtain a list of all participant nodes related to a particular course
         */
        List<UITreeViewNode> getAllPPNodes(int courseID);

        /**
         * Retrieve the number of records across all tables
         */
        void showDBCount();

        #endregion

    }
}

using MarkTracker.include.entities;
using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.db {

    /**
     * Functions that allow the application to interact
     * with the database / data layer.
     * 
     * This class is also responsible for the conversion between 
     * objects and relations (to and from data source)
     */
    public interface DataLayerInterface {

        /*
            NOTE: By convention, data layer operations that are carried
            out successfully should return 0. For those "add" functions,
            the ID of the newly created record is returned.

            If an error has occurred, a negative error code should be returned,
            that corresponds to a predefined error message.
        */
        
        /**
         * ------------------------------------
         * DB MANAGEMENT FUNCTIONS
         * ------------------------------------
         */
        #region DB Management Functions

        /**
         * Creates the database / data file
         */
        int createDB(string dbName);

        /**
         * Removes a data source
         */
        int removeDB(string dbName);

        /**
         * Check if a db with a certain name exists
         */
        bool dbExists(string dbName);

        /**
         * Open the data source
         */
        int openDB(string dbName);

        /**
         * Close the currently opened data source
         */
        int closeDB();

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
        int addNewCourse(string newCourseName);

        /**
         * Obtains a course object with the specified course ID
         */
        Course getCourseObj(int courseID);

        /**
         * Removes a course from the DB with the specified ID
         */
        int deleteCourse(int courseID);

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
        int addNewAssessment(string newAssessmentName, int courseID);

        /**
         * Obtains an assessment object with the specified course ID
         */
        Assessment getAssessmentObj(int assessmentID);

        /**
         * Removes an assessmente from the DB with the specified ID
         */
        int deleteAssessment(int assessmentID);

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
        int addNewComponent(string newComponentName, 
                            Nullable<int> parentComponentID,        
                            Nullable<int> associatedAssessmentID);

        /**
         * Obtains a component object with the specified ID
         */
        AssessmentComponent getComponentObj(int componentID);

        /**
         * Removes a component from the DB with the specified ID
         */
        int deleteComponent(int componentID);

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
        int addNewGroup(string newGroupName, int associatedCourse);

        /**
         * Obtains a group object with the specified ID
         */
        Group getGroupObj(int groupID);

        /**
         * Removes a group from the DB with the specified ID
         */
        int deleteGroup(int groupID);

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
        int addNewStudent(string newStudentName, int groupID);

        /**
         * Obtains a student object with the specified ID
         */
        Student getStudentObj(int studentID);

        /**
         * Removes a student from the DB with the specified ID
         * and course ID
         */
        int deleteStudent(int studentID, int courseID);

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
        StudentMarkInfo getStudentMark(int studentID, int componentID);

        /**
         * Updates the student mark into the database
         */
        int saveStudentMark(StudentMarkInfo smi);

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
        int updateName(EntityConstants.EntityType type, int id, string newName);

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

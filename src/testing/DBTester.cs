using MarkTracker.include.db;
using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;               /* Used for Debug.Assert. To preserve assert statements in "release", use Trace.Assert instead */
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarkTracker.include.db.DataLayerConstants;

namespace MarkTracker.testing {

    /* Tests the Database layer abstraction */
    public class DBTester {

        /* Constructor */
        public DBTester() { }

        /**
         * Function that runs the tests 
         */
        public void Run() {
            Console.WriteLine("== Now running tests for data layer...");

            this.TestNewDataSource();
            this.TestInitialiseDataSource();
            this.TestCourseManipulation();

            Console.WriteLine("\n** All tests passed! You are AWESOME!");
            Console.Read();
        }

        /**
         * Test functions related to creating a new data source
         * and removing the newly created db
         */
        private void TestNewDataSource() {
            Console.WriteLine("= Testing New Data Source...");
            DataLayer db = new DataLayer();
            DBResult result;

            /* Create test database */
            string testDBName = System.Reflection.Assembly.GetExecutingAssembly().Location + "_testDB";
            string fileExt = DataLayerConstants.DB_FILE_EXTENSION;
            /* NOTE: Assumes the datalayer is file-oriented */
            Console.WriteLine("testDBName: " + testDBName);
            Debug.Assert(File.Exists(testDBName + fileExt) == false);

            result = db.dbExists(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == false);

            result = db.createDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(File.Exists(testDBName + fileExt) == true);
            result = db.dbExists(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == true);

            /* Check that it cannot create same db again */
            result = db.createDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.ERROR_DB_ALREADY_EXISTS);

            /* Open connection and check */
            result = db.hasConnection();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == false);

            result = db.openDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            result = db.hasConnection();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == true);

            /* Check db cannot be opened again */
            result = db.openDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.ERROR_DB_CUR_OPENED);
            result = db.openDB("blah_db");
            Debug.Assert(result.ecode == ErrorCode.ERROR_DB_OPENED);

            /* Check that the currently opened DB cannot be removed */
            result = db.removeDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.ERROR_DB_CUR_OPENED);
            Debug.Assert(File.Exists(testDBName + fileExt) == true);

            /* Close connection and check */
            result = db.closeDB();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);

            result = db.hasConnection();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == false);

            /* Check deletion of data source */
            Debug.Assert(File.Exists(testDBName + fileExt) == true);
            result = db.removeDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(File.Exists(testDBName + fileExt) == false);

            /* Deletion of data source that doesn't exist */
            result = db.removeDB("_blah");
            Debug.Assert(result.ecode == ErrorCode.ERROR_DB_NOT_EXIST);

            /* Check that the same data source cannot be removed */
            result = db.removeDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.ERROR_DB_NOT_EXIST);

            Console.WriteLine("= New Data Source testing complete.");
        }

        /**
         * Test the initialisation of data source
         */
        private void TestInitialiseDataSource() {

            Console.WriteLine("= Testing Initialisation...");
            DataLayer db = new DataLayer();
            DBResult result;         /* Track operation results */

            /* Create db specific for this test */
            string testDBName = System.Reflection.Assembly.GetExecutingAssembly().Location + "_initTestDB";
            this.CreateTestDB(testDBName, db);

            /* Check that data source is not yet initialised */
            result = db.dbInitialised();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == false);

            result = db.initialiseDB();

            result = db.dbInitialised();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == true);

            /* Clean up */
            this.CleanUp(testDBName, db);

            Console.WriteLine("= Initialisation testing complete.");
        }

        /**
         * Test functions related to courses
         */
        private void TestCourseManipulation() {
            Console.WriteLine("= Testing Course manipulation...");
            DataLayer db = new DataLayer();
            DBResult result;         /* Track operation results */

            /* Create db specific for this test */
            string testDBName = System.Reflection.Assembly.GetExecutingAssembly().Location + "_courseTestDB";
            this.CreateTestDB(testDBName, db);

            /* Insert some courses */
            string c1Name = "History";
            string c2Name = "Modern History";
            string c3Name = "Ancient History";
            result = db.addNewCourse(c1Name);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            int c1ID = result.intVal;

            result = db.addNewCourse(c2Name);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            int c2ID = result.intVal;

            result = db.addNewCourse(c3Name);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            int c3ID = result.intVal;

            /* Check that all 3 ID's are not equal */
            Debug.Assert(c1ID != c2ID);
            Debug.Assert(c1ID != c3ID);
            Debug.Assert(c2ID != c3ID);

            /* Check duplicate course names cannot be added */
            result = db.addNewCourse(c1Name);
            Debug.Assert(result.ecode == ErrorCode.ERROR_COURSE_ALREADY_EXISTS);
            result = db.addNewCourse(c2Name);
            Debug.Assert(result.ecode == ErrorCode.ERROR_COURSE_ALREADY_EXISTS);
            result = db.addNewCourse(c3Name);
            Debug.Assert(result.ecode == ErrorCode.ERROR_COURSE_ALREADY_EXISTS);

            /* Check that a course with invalid int cannot be obtained */
            int courseID = -1;
            result = db.getCourseObj(courseID);
            Debug.Assert(result.ecode == ErrorCode.ERROR_COURSE_NOT_EXIST);

            /* Check obtain course objects */
            result = db.getCourseObj(c1ID);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.objectVal != null);
            Course c1 = result.objectVal as Course;
            Debug.Assert(c1.id == c1ID);
            Debug.Assert(c1.name.Equals(c1Name));

            result = db.getCourseObj(c2ID);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.objectVal != null);
            Course c2 = result.objectVal as Course;
            Debug.Assert(c2.id == c2ID);
            Debug.Assert(c2.name.Equals(c2Name));

            result = db.getCourseObj(c3ID);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.objectVal != null);
            Course c3 = result.objectVal as Course;
            Debug.Assert(c3.id == c3ID);
            Debug.Assert(c3.name.Equals(c3Name));

            /* Update some courses */
            string newC1Name = "Geography";
            c1.name = newC1Name;
            result = db.updateCourse(c1);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.intVal == c1ID);    /* Check that the ID's returned are the same */

            /* Check properly updated */
            result = db.getCourseObj(c1ID);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.objectVal != null);
            Course c1New = result.objectVal as Course;
            Debug.Assert(c1New.name.Equals(c1.name));
            Debug.Assert(c1New.id == c1.id);

            /* Clean up */
            this.CleanUp(testDBName, db);

            Console.WriteLine("= Course manipulation testing complete.");
        }


        /**
         * Test function template
         */
        private void TestFunctionTemplate() {
            Console.WriteLine("= Testing Something...");
            DataLayer db = new DataLayer();
            DBResult result;         /* Track operation results */

            Console.WriteLine("= Something testing complete.");
        }

        /**
         * Create a database file with the name
         */
        private void CreateTestDB(string testDBName, DataLayer db) {
            DBResult result = db.dbExists(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            Debug.Assert(result.boolVal == false);

            result = db.createDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);

            result = db.openDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);   /* check DB can be connected */
        }

        /**
         * Cleans up the created test database
         */
        private void CleanUp(string testDBName, DataLayer db) {
            DBResult result = db.closeDB();
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
            result = db.removeDB(testDBName);
            Debug.Assert(result.ecode == ErrorCode.OP_SUCCESS);
        }

    }
}

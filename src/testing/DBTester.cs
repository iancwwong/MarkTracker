using MarkTracker.include.db;
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
            ErrorCode result;         /* Track operation results */

            /* Create test database */
            string testDBName = System.Reflection.Assembly.GetExecutingAssembly().Location + "_testDB";
            string fileExt = DataLayerConstants.DB_FILE_EXTENSION;
            /* NOTE: Assumes the datalayer is file-oriented */
            Console.WriteLine("testDBName: " + testDBName);
            Debug.Assert(File.Exists(testDBName + fileExt) == false);
            Debug.Assert(db.dbExists(testDBName) == false);
            result = db.createDB(testDBName);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            Debug.Assert(File.Exists(testDBName + fileExt) == true);
            Debug.Assert(db.dbExists(testDBName) == true);

            /* Check that it cannot create same db again */
            Debug.Assert(db.createDB(testDBName) == ErrorCode.ERROR_DB_ALREADY_EXISTS);

            /* Open connection and check */
            result = db.openDB(testDBName);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            Debug.Assert(db.hasConnection() == true);

            /* Check a db cannot be opened */
            result = db.openDB(testDBName);
            Debug.Assert(result == ErrorCode.ERROR_DB_CUR_OPENED);
            result = db.openDB("blah_db");
            Debug.Assert(result == ErrorCode.ERROR_DB_OPENED);

            /* Check that the currently opened DB cannot be removed */
            result = db.removeDB(testDBName);
            Debug.Assert(result == ErrorCode.ERROR_DB_CUR_OPENED);
            Debug.Assert(File.Exists(testDBName + fileExt) == true);

            /* Close connection and check */
            result = db.closeDB();
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            Debug.Assert(db.hasConnection() == false);

            /* Check deletion of data source */
            Debug.Assert(File.Exists(testDBName + fileExt) == true);
            result = db.removeDB(testDBName);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            Debug.Assert(File.Exists(testDBName + fileExt) == false);

            /* Check that the same data source cannot be removed */
            result = db.removeDB(testDBName);
            Debug.Assert(result == ErrorCode.ERROR_DB_NOT_EXIST);

            Console.WriteLine("= New Data Source testing complete.");
        }

        /**
         * Test the initialisation of data source
         */
        private void TestInitialiseDataSource() {

            Console.WriteLine("= Testing Initialisation...");
            DataLayer db = new DataLayer();
            ErrorCode result;         /* Track operation results */

            /* Create db specific for this test */
            string testDBName = System.Reflection.Assembly.GetExecutingAssembly().Location + "_initTestDB";
            this.CreateTestDB(testDBName, db);

            /* Check that data source is not yet initialised */
            Debug.Assert(db.dbInitialised() == false);
            result = db.initialiseDB();
            Debug.Assert(db.dbInitialised() == true);

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
            ErrorCode result;         /* Track operation results */

            /* Create db specific for this test */
            string testDBName = System.Reflection.Assembly.GetExecutingAssembly().Location + "_courseTestDB";
            this.CreateTestDB(testDBName, db);

            /* Insert some courses */
            string courseName1 = "History";
            string courseName2 = "Modern History";
            string courseName3 = "Ancient History";
            result = db.addNewCourse(courseName1);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            result = db.addNewCourse(courseName2);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            result = db.addNewCourse(courseName3);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);

            /* Check duplicate course names cannot be added */
            result = db.addNewCourse(courseName1);
            Debug.Assert(result == ErrorCode.ERROR_COURSE_ALREADY_EXISTS);
            result = db.addNewCourse(courseName2);
            Debug.Assert(result == ErrorCode.ERROR_COURSE_ALREADY_EXISTS);
            result = db.addNewCourse(courseName3);
            Debug.Assert(result == ErrorCode.ERROR_COURSE_ALREADY_EXISTS);

            /* Update the course info using course objects */


            /* Check properly updated */

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
            ErrorCode result;         /* Track operation results */

            Console.WriteLine("= Something testing complete.");
        }

        /**
         * Create a database file with the name
         */
        private void CreateTestDB(string testDBName, DataLayer db) {
            Debug.Assert(db.dbExists(testDBName) == false);
            db.createDB(testDBName);
            ErrorCode result = db.openDB(testDBName);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);   /* check DB can be connected */
        }

        /**
         * Cleans up the created test database
         */
        private void CleanUp(string testDBName, DataLayer db) {
            ErrorCode result = db.closeDB();
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
            result = db.removeDB(testDBName);
            Debug.Assert(result == ErrorCode.OP_SUCCESS);
        }

    }
}

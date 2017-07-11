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
         * Test function template
         */
        private void TestFunctionTemplate() {
            Console.WriteLine("= Testing New Data Source...");
            DataLayer db = new DataLayer();
            ErrorCode result;         /* Track operation results */

            Console.WriteLine("= New Data Source testing complete.");
        }

    }
}

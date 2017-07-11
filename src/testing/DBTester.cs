using MarkTracker.include.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;               /* Used for Debug.Assert. To preserve assert statements in "release", use Trace.Assert instead */
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DataLayerConstants.ErrorCode result;         /* Track operation results */

            /* Create test database */
            string testDBName = "_testDB";
            string fileExt = DataLayerConstants.DB_FILE_EXTENSION;
            /* NOTE: Assumes the datalayer is file-oriented */
            Debug.Assert(File.Exists(testDBName + fileExt) == false);
            Debug.Assert(db.dbExists(testDBName) == false);
            result = db.createDB(testDBName);
            Debug.Assert(result == DataLayerConstants.ErrorCode.OP_SUCCESS);
            Debug.Assert(File.Exists(testDBName + fileExt) == true);
            Debug.Assert(db.dbExists(testDBName) == true);

            /* Check that it cannot create same db again */
            Debug.Assert(db.createDB(testDBName) == DataLayerConstants.ErrorCode.ERROR_DB_ALREADY_EXISTS);

            /* Open connection and check */
            result = db.openDB(testDBName);
            Debug.Assert(result == DataLayerConstants.ErrorCode.OP_SUCCESS);
            Debug.Assert(db.hasConnection() == true);

            /* Close connection and check */
            result = db.closeDB();
            Debug.Assert(result == DataLayerConstants.ErrorCode.OP_SUCCESS);
            Debug.Assert(db.hasConnection() == false);

            /* Check deletion of data source */
            Debug.Assert(File.Exists(testDBName + fileExt) == true);
            result = db.removeDB(testDBName);
            Debug.Assert(result == DataLayerConstants.ErrorCode.OP_SUCCESS);
            Debug.Assert(File.Exists(testDBName + fileExt) == false);

            /* Check that the same data source cannot be removed */
            result = db.removeDB(testDBName);
            Debug.Assert(result == DataLayerConstants.ErrorCode.ERROR_DB_NOT_EXIST);

            Console.WriteLine("= New Data Source testing complete.");
        }
        

        /**
         * Test function template
         */
        private void TestFunctionTemplate() {
            Console.WriteLine("= Testing New Data Source...");
            DataLayer db = new DataLayer();
            DataLayerConstants.ErrorCode result;         /* Track operation results */

            Console.WriteLine("= New Data Source testing complete.");
        }

    }
}

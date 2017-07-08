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
     * with the database / data layer
     */
    interface DataLayerInterface {

        // NOTE: By convention, data layer operations that are carried
        //       out successfully should return 0, and something otherwise
        //       (corresponding to a particular error code)

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
         * OTHER USEFUL FUNCTIONS
         * ------------------------------------
         */
        #region Other useful functions

        /**
         * Update only the name field of a particular record.
         */
        int updateName(EntityConstants.EntityType type, int id, string newName);

        #endregion

    }
}

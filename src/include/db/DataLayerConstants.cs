using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.db {

    /**
     * Constants used by data layer
     */
    public class DataLayerConstants {

        /* File extension */
        public const string DB_FILE_EXTENSION = ".mtdb";        /* "Mark Tracker Database" */

        /* Message codes */
        public enum ErrorCode : int {
            OP_SUCCESS = 0,
            ERROR_DB_ALREADY_EXISTS = 1,
            ERROR_DB_NOT_EXIST = 2,

            ERROR_UNKNOWN = 9999
        }
    }
}

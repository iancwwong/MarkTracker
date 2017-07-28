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
            ERROR_DB_OPENED = 3,            /* A database is opened */      
            ERROR_DB_CUR_OPENED = 4,        /* Same database is currently opened */
            ERROR_DB_CLOSED = 5,            /* Connection is closed */

            ERROR_COURSE_ALREADY_EXISTS = 6,
            ERROR_COURSE_NOT_EXIST = 7,

            ERROR_ASSESSMENT_ALREADY_EXISTS = 8,
            ERROR_ASSESSMENT_NOT_EXIST = 9,

            ERROR_UNKNOWN = 9999,
        }

        /* For the sake of no magic values */
        public const int UNUSED_INT = -1;
        public const bool UNUSED_BOOL = false;
        public const object UNUSED_OBJ = null;
    }
}

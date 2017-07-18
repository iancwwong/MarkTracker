using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarkTracker.include.db.DataLayerConstants;

namespace MarkTracker.include.db {

    /* Represents the result from a DB operation,
     * containing some important fields that may be used.
     * 
     * NOTE: Assumes usage involves checking the Error code BEFORE 
     * using the various fields
     */
    public class DBResult {

        public ErrorCode ecode { get; set; }
        public int intVal { get; set; }             /* For when an int value is useful, eg addNewCourse */
        public bool boolVal { get; set; }           /* For when a bool value is useful, eg isConnected */
        public object objectVal { get; set; }       /* For when an object is useful, eg getCourseObj */

        /* Constructors */
        public DBResult() { }
        public DBResult(ErrorCode e, int id, bool b, object o) {
            this.ecode = e;
            this.intVal = id;
            this.boolVal = b;
            this.objectVal = o;
        }
        public DBResult(ErrorCode e, int id) : this(e, id, UNUSED_BOOL, UNUSED_OBJ) { } 
        public DBResult(ErrorCode e, bool b) : this(e, UNUSED_INT, b, UNUSED_OBJ) { }
        public DBResult(ErrorCode e, object o) : this(e, UNUSED_INT, UNUSED_BOOL, o) { }
        public DBResult(int id) : this(ErrorCode.OP_SUCCESS, id) { }                        /* For ease of typing */
        public DBResult(bool b) : this(ErrorCode.OP_SUCCESS, b) { }
        public DBResult(object o) : this(ErrorCode.OP_SUCCESS, o) { }
        public DBResult(ErrorCode e) : this(e, UNUSED_INT, UNUSED_BOOL, UNUSED_OBJ) { }
    }
}

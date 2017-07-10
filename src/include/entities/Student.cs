using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.entities {

    /**
     * Represents a student
     */
    public class Student {
        public int id { get; set; }             /* NOTE: This is the given student ID, rather than the actual database ID */
        public string fname { get; set; }       /* first name */
        public string lname { get; set; }       /* last name */

        /* constructor */
        public Student() { }
    }
}

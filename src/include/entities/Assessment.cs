using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.entities {

    /**
     * Represents an assessment
     */
    public class Assessment {
        public int id { get; set; }                 /* ID of assessment (DB use) */
        public string name { get; set; }            /* Assessment name */
        public DateTime dueDate { get; set; }       /* Due date of assessment */
        public int availableMarks { get; set; }     /* total marks available */
        public int weighting { get; set; }          /* expressed as a percentage */
        public string comments { get; set; }        /* general comments for the assessment */

        /* Constructor */
        public Assessment() { }
    }
}

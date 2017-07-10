using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.entities {

    /**
     * Represents an assessment component
     */
    public class AssessmentComponent {
        public int id { get; set; }
        public string name { get; set; }
        public int totalMark { get; set; }
        public string comments { get; set; }

        /* Constructor */
        public AssessmentComponent() { }
    }
}

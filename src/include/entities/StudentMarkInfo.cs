using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include.entities {
    
    /**
     * Represents a student mark info
     */
    public class StudentMarkInfo {

        /* Attributes */
        public int id { get; set; }
        public int givenMark { get; set; }
        public int componentMark { get; set; }
        public string feedback { get; set; }

        /* Constructor */
        public StudentMarkInfo() { }
    }
}

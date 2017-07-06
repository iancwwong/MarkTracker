using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker.include.nodes {

    /**
     * Wrapper for a course in the form of a tree node
     */
    class CourseNode : TreeNode {
        public Course course { get; set; }

        /**
         * Constructor
         */
        public CourseNode(string courseName, ContextMenuStrip cms) : base(courseName) {
            this.course = new Course();
            this.course.name = courseName;

            /* right click submenu / context menu strip */
            this.ContextMenuStrip = cms;
        }
    }
}

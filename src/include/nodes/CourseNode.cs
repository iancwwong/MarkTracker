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
        public CourseNode(string courseName) : base(courseName) {
            this.course = new Course();
            this.course.name = courseName;
        }
    }
}

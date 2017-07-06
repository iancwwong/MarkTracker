using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker {
    public partial class markTrackerForm : Form {
        public markTrackerForm() {
            InitializeComponent();

            /* Attach context menu strips (ie submenu from right clicks) */
            this.assessmentPanel.ContextMenuStrip = this.apContextMenu;
        }

        private void markTrackerForm_Load(object sender, EventArgs e) {
            /* Read in the course and assessment nodes from data source */
        }


        #region Context Menu Strips Handlers

            #region Right clicking on Assessment Panel (AP)

                #region Right-clicking on nothing

        /**
         * "New -> Course"
         */
        private void courseToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Create a new node that corresponds to a new course */
            CourseNode newCourseNode = new CourseNode("New Course", this.apCourseContextMenu);
            this.assessmentPanel.Nodes.Add(newCourseNode);
        }

        /**
         * "Sort By -> Name"
         */
        private void nameToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Sort the courses by Name */
        }

        /**
         * "Sort By -> Number of Participants"
         */
        private void numberOfParticipantsToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Sort the courses by number of participants */
        }


        #endregion

                #region Right-clicking on a course

        /**
         * "New -> Assessment"
         */
        private void assessmentToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Create a new assessment node for the associated course */

        }

        /**
         * "Rename course"
         */
        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Get the course node object */

            /* change the text value */
        }

        /**
         * Edit course - NOTE: SAME AS RENAME
         */
        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Get the course node object */

            /* change the text value */
        }

        /**
         * Remove course
         */
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        #endregion

        #endregion

        #endregion
    }
}

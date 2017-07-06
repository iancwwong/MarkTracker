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
            CourseNode newCourseNode = new CourseNode("New Course");
            this.assessmentPanel.Nodes.Add(newCourseNode);
        }


        #endregion

        #endregion

        #endregion
    }
}

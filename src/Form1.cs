using MarkTracker.include;
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

        /**
         * -----------------------------------
         * ATTRIBUTES
         * -----------------------------------
         */
        private AssessmentPanelNode curRCNode;         /* The node that is right-clicked on */

        public markTrackerForm() {
            InitializeComponent();

            /* Attach context menu strips (ie submenu from right clicks).
             * By default, it will show when the AP is right-clicked on*/
            this.assessmentPanel.ContextMenuStrip = this.apContextMenu;
        }

        private void markTrackerForm_Load(object sender, EventArgs e) {
            /* TODO: Read in the course and assessment nodes from data source */
        }

        /**
         * -----------------------------------
         * GENERAL FORM HANDLERS
         * -----------------------------------
         */
        #region General Form Handlers

        /**
        * -----------------------------------
        * ASSESSMENT PANEL (TREE VIEW)
        * -----------------------------------
        */
        #region Assessment Panel Handlers

        /**
        * Updates reference of selected node that is right-clicked on.
        */
        private void getAPNodeFromClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) {
                // Select the clicked node
                this.curRCNode = assessmentPanel.GetNodeAt(e.X, e.Y) as AssessmentPanelNode;
            }
        }

        /**
         * Handler for when the label for an APNode is changed
         */
        private void afterAPLabelEdit_handler(object sender, NodeLabelEditEventArgs e) {
            if (e.Label != null) {
                /* New name should have a length > 0 */
                if (e.Label.Length == 0) {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("New name cannot be blank");
                    e.Node.BeginEdit();
                }

                /* Update the name of the node in UI and DB */
                AssessmentPanelNode apNode = e.Node as AssessmentPanelNode;
                apNode.Text = e.Label.ToString();
                // this.db.updateName(apNode.type, apNode.id, apNode.text);
                //System.Diagnostics.Debug.WriteLine("Changed name to: " + e.Label.ToString());
            }
        }

        #endregion

        #endregion

        /**
         * -----------------------------------
         * CONTEXT MENU STRIP HANDLERS
         * -----------------------------------
         */
        #region Context Menu Strips Handlers - occurs when a right click is made

        #region Right clicking on Assessment Panel (AP)

        #region Right-clicking on nothing

        /**
         * "New -> Course"
         */
        private void courseToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Create a new node that corresponds to a new course */
            string newCourseName = "New Course";        /* default */

            /* TODO: Update DB with the new course */
            // int result = this.db.addNewCourse(newCourseName);
            AssessmentPanelNode newCourseNode =
                new AssessmentPanelNode(AssessmentPanelNode.apNodeType.Course,
                                        newCourseName,   /* default name of new course */
                                        this.apCourseContextMenu);
            // newCourseNode.id = result
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
            if (this.curRCNode != null) {
                /* Create a new assessment node for the associated course */
                string newAssessmentName = "New Assessment";        /* default */

                /* TODO: Update DB with the new course */
                // int result = this.db.addNewCourse(newCourseName);
                AssessmentPanelNode newAssessmentNode =
                    new AssessmentPanelNode(AssessmentPanelNode.apNodeType.Assessment,
                                            newAssessmentName,   /* default name of new course */
                                            this.apAssessmentContextMenu);
                // newAssessmentNode.id = result
                this.curRCNode.Nodes.Add(newAssessmentNode);
            }
        }

        /**
         * "Rename course"
         */
        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.curRCNode != null) {
                /* Get the course node object */
                AssessmentPanelNode cn = this.curRCNode;

                /* change the text value */
                cn.BeginEdit();
            }
        }

        /**
         * Edit course - NOTE: SAME AS RENAME
         */
        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.curRCNode != null) {
                /* Get the course node object */
                AssessmentPanelNode cn = this.curRCNode;

                /* change the text value */
                cn.BeginEdit();
            }
        }

        /**
         * Remove selected course
         */
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {

            /* Prompt user to confirm */
            if (MessageBox.Show(DialogueMessages.COURSE_REMOVE_CONFIRMATION, "", MessageBoxButtons.OKCancel)
                == DialogResult.OK) {
                this.assessmentPanel.Nodes.Remove(this.curRCNode);
                this.curRCNode = null;
            }
        }

        #endregion

        #endregion

        #endregion
    }
}

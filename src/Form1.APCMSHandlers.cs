using MarkTracker.include;
using MarkTracker.include.forms;
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
		 * CONTEXT MENU STRIP HANDLERS FOR AP
		 * -----------------------------------
		 */
        #region Context Menu Strips Handlers - occurs when a right click is made

        #region Right-clicking on nothing

        /**
         * "New -> Course"
         */
        private void apCM_new_course_Click(object sender, EventArgs e) {
            /* Create a new node that corresponds to a new course */
            string newCourseName = "New Course";        /* default */

            /* TODO: Update DB with the new course */
            // int result = this.db.addNewCourse(newCourseName);
            AssessmentPanelNode newCourseNode =
                new AssessmentPanelNode(AssessmentPanelNode.apNodeType.Course,
                                        newCourseName,   /* default name of new course */
                                        null,            /* courses have no parent nodes */
                                        this.apCourseContextMenu);
            // newCourseNode.id = result
            this.assessmentPanel.Nodes.Add(newCourseNode);
        }

        /**
         * "Sort By -> Name"
         */
        private void apCM_sort_name_Click(object sender, EventArgs e) {
            /* Sort the courses by Name */
        }

        /**
         * "Sort By -> Number of Participants"
         */
        private void apCM_sort_numParticipants_Click(object sender, EventArgs e) {
            /* Sort the courses by number of participants */
        }


        #endregion

        #region Right-clicking on a course

        /**
         * "New -> Assessment"
         */
        private void apCourseCM_new_assessment_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {
                /* Create a new assessment node for the associated course */
                string newAssessmentName = "New Assessment";        /* default */

                /* TODO: Update DB with the new course */
                // int result = this.db.addNewCourse(newCourseName);
                AssessmentPanelNode newAssessmentNode =
                    new AssessmentPanelNode(AssessmentPanelNode.apNodeType.Assessment,
                                            newAssessmentName,   /* default name of new course */
                                            this.curAPNode,
                                            this.apAssessmentContextMenu);
                // newAssessmentNode.id = result
                this.curAPNode.Nodes.Add(newAssessmentNode);
                this.curAPNode.Expand();        /* Keep course node expanded */
            }
        }

        /**
         * "Rename course"
         */
        private void apCourseCM_rename_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {
                /* Get the course node object */
                AssessmentPanelNode cn = this.curAPNode;

                /* change the text value */
                cn.BeginEdit();

                /* NOTE: The update in the DB is handled by the 
                 * afterAPLabelEdit_handler function
                 */
            }
        }

        /**
         * Edit course
         */
        private void apCourseCM_edit_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {
                /* Bring up edit course window */
                EditCourseForm ecf = new EditCourseForm(null);
                ecf.Show();
            }
        }

        /**
         * Remove selected course
         */
        private void apCourseCM_delete_Click(object sender, EventArgs e) {
            /* Prompt user to confirm */
            if (MessageBox.Show(DialogueMessages.COURSE_REMOVE_CONFIRMATION, "", MessageBoxButtons.OKCancel)
                == DialogResult.OK) {

                /* Reflect change in DB */
                // int result = this.db.deleteCourse(this.curAPNode.id);

                this.assessmentPanel.Nodes.Remove(this.curAPNode);
                this.curAPNode = null;
            }
        }

        #endregion

        #region Right-clicking on an assessement

        /**
         * New -> Component
         */
        private void apAssessmentCM_new_component_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {
                /* Create a new component node for the associated course */
                string newComponentName = "New Component";        /* default */

                /* TODO: Update DB with the new course */
                // int result = this.db.addNewCourse(newCourseName);
                AssessmentPanelNode newComponentNode =
                    new AssessmentPanelNode(AssessmentPanelNode.apNodeType.Component,
                                            newComponentName,   /* default name of new course */
                                            this.curAPNode,
                                            this.apComponentContextMenu);
                // newAssessmentNode.id = result
                this.curAPNode.Nodes.Add(newComponentNode);
                this.curAPNode.Expand();        /* Keep assessment node expanded */
            }
        }

        /**
         * Rename assessment node
         */
        private void apAssessmentCM_rename_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {
                /* Get the assessment node object */
                AssessmentPanelNode cn = this.curAPNode;

                /* change the text value */
                cn.BeginEdit();

                /* NOTE: The update in the DB is handled by the 
                 * afterAPLabelEdit_handler function
                 */
            }
        }

        /**
         * Edit assessment node
         */
        private void apAssessmentCM_edit_Click(object sender, EventArgs e) {

            /* Create the assessment edit form */
            //Assessment assessment = this.db.getAssessment(this.curAPNode.id);
            EditAssessmentForm eaf = new EditAssessmentForm(null);
            eaf.Show();

        }

        /**
         * View statistics of assessment
         */
        private void apAssessmentCM_view_statistics_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {
                /* TODO: Implement view statistics for an assessment */

            }
        }

        /**
         * Remove the selected assessment
         */
        private void apAssessmentCM_delete_Click(object sender, EventArgs e) {
            if (this.curAPNode != null) {

                /* Prompt user to confirm */
                if (MessageBox.Show(DialogueMessages.ASSESSMENT_REMOVE_CONFIRMATION, "", MessageBoxButtons.OKCancel)
                    == DialogResult.OK) {

                    /* Reflect change in DB */
                    // int result = this.db.deleteAssessment(this.curAPNode.id);

                    /* Remove this node from the parent course in UI */
                    AssessmentPanelNode parentCourse = this.curAPNode.parentNode;
                    parentCourse.Nodes.Remove(this.curAPNode);

                    /* Dereference current node */
                    this.curAPNode = null;
                }
            }
        }

        #endregion

        #endregion
    }
}

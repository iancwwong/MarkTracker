using MarkTracker.include;
using MarkTracker.include.entities;
using MarkTracker.include.forms;
using MarkTracker.include.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker {

    public partial class markTrackerForm : Form {

        /**
         * -----------------------------------
         * CONTEXT MENU STRIP HANDLERS FOR PP
         * -----------------------------------
         */

        #region Right-clicking on nothing

        /**
         * New -> Group
         */
        private void ppCM_new_group_Click(object sender, EventArgs e) {
            /* Create a new node that corresponds to a new group */
            string newGroupName = "New Group";        /* default */

            /* TODO: Update DB with the new group */
            // int result = this.db.addNewGroup(newGroupName, this.curSelCourseID)
            UITreeViewNode newGroupNode =
                new UITreeViewNode(EntityConstants.EntityType.Group,
                                        newGroupName,   
                                        null,            /* groups have no parent nodes */
                                        this.ppGroupContextMenu);
            // newGroupNode.id = result
            this.participantPanel.Nodes.Add(newGroupNode);
        }

        /**
         * Sort by -> Name
         */
        private void ppCM_sort_name_Click(object sender, EventArgs e) {
            this.participantPanel.Sort();
        }

        #endregion

        #region Right-Click on group

        /**
         * New -> Student
         */
        private void ppGroupCM_new_student_Click(object sender, EventArgs e) {
            if (this.curPPNode != null) {
                /* Create a new student node for the associated group */
                string newStudentName = "New Student";        /* default */

                /* TODO: Update DB with the new student */
                // int result = this.db.addNewStudent(...);
                UITreeViewNode newStudentNode =
                    new UITreeViewNode(EntityConstants.EntityType.Student,
                                            newStudentName,   /* default name of new course */
                                            this.curPPNode,
                                            this.ppStudentContextMenu);
                // newAssessmentNode.id = result
                this.curPPNode.Nodes.Add(newStudentNode);
                this.curPPNode.Expand();        /* Keep group node expanded */
            }

        }

        /**
         * Rename group
         */
        private void ppGroupCM_rename_Click(object sender, EventArgs e) {   
            if (this.curPPNode != null) {
                /* Get the group node object */
                UITreeViewNode cn = this.curPPNode;

                /* change the text value */
                cn.BeginEdit();

                /* NOTE: The update in the DB is handled by the 
                 * afterPPLabelEdit_handler function
                 */
            }
        }

        /**
         * Edit group
         */
        private void ppGroupCM_edit_Click(object sender, EventArgs e) {
            if (this.curPPNode != null) {
                /* Bring up group edit window */
                // Group g = this.db.getGroupObj(this.curPPNode.id);
                EditGroupForm egf = new EditGroupForm(null);
                egf.Show();
            }
        }

        /**
         * Remove group
         */
        private void ppGroupCM_delete_Click(object sender, EventArgs e) {

            /* Prompt user to confirm */
            if (MessageBox.Show(DialogueMessages.GROUP_REMOVE_CONFIRMATION, "", MessageBoxButtons.OKCancel)
                == DialogResult.OK) {

                /* Reflect change in DB */
                // int result = this.db.deleteGroup(this.curPPNode.id);

                this.participantPanel.Nodes.Remove(this.curPPNode);
                this.curPPNode = null;
            }
        }

        #endregion

        #region Right-click on student

        /**
         * Add or edit mark for selected component associated with selected student
         */ 
        private void ppStudentCM_addEditMark_Click(object sender, EventArgs e) {
            /* Check to see if a leaf assessment component is selected */
            if (this.curAPNode != null) {

                /* A component was not selected */
                if (this.curAPNode.type != EntityConstants.EntityType.Component) {
                    MessageBox.Show(ErrorMessages.COMPONENT_NOT_SELECTED);
                }

                /* Leaf component wasn't selected */
                else if (!this.curAPNode.isLeaf()) {
                    MessageBox.Show(ErrorMessages.LEAF_COMPONENT_NOT_SELECTED);
                }

                /* all is good */
                else {
                    /* Try to obtain the mark of the selected student and component */
                    // int studID = this.curPPNode.id;
                    // int componentID = this.curAPNode.id;
                    // StudentMark sm = this.db.getStudentMark(studID, componentID);
                    EditStudentMarkForm emf = new EditStudentMarkForm(null);
                    emf.Show();
                }

            }

            /* No assessment panel node was selected
            * SHOULD NOT REACH HERE */
        }

        /**
         * Rename the student
         */
        private void ppStudentCM_rename_Click(object sender, EventArgs e) {
            if (this.curPPNode != null) {
                /* Get the student node object */
                UITreeViewNode cn = this.curPPNode;

                /* change the text value */
                cn.BeginEdit();

                /* NOTE: The update in the DB is handled by the 
                 * afterPPLabelEdit_handler function
                 */
            }
        }

        /**
         * Edit the student information
         */
        private void ppStudentCM_edit_Click(object sender, EventArgs e) {
            if (this.curPPNode != null) {
                /* Obtain the student object */
                // Student s = this.db.getStudentObj(this.curPPNode.id);
                EditStudentForm esf = new EditStudentForm(null);
                esf.Show();
            }
        }


        /**
         * Remove the selected student
         */
        private void ppStudentCM_delete_Click(object sender, EventArgs e) {
            /* Prompt user to confirm */
            if (MessageBox.Show(DialogueMessages.STUDENT_REMOVE_CONFIRMATION, "", MessageBoxButtons.OKCancel)
                == DialogResult.OK) {

                /* Reflect change in DB */
                // int result = this.db.deleteStudent(this.curPPNode.id, this.curSelCourseID);

                /* Remove this node from the parent group in UI */
                UITreeViewNode parentGroup = this.curPPNode.parentNode;
                parentGroup.Nodes.Remove(this.curPPNode);

                /* Dereference current node */
                this.curPPNode = null;
            }
        }

        #endregion

    }
}

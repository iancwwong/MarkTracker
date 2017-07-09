using MarkTracker.include;
using MarkTracker.include.entities;
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
            // int result = this.db.addNewGroup(newGroupName);
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

        }

        /**
         * Rename group
         */
        private void ppGroupCM_rename_Click(object sender, EventArgs e) {   
            if (this.curPPNode != null) {
                /* Get the course node object */
                UITreeViewNode cn = this.curPPNode;

                /* change the text value */
                cn.BeginEdit();

                /* NOTE: The update in the DB is handled by the 
                 * afterAPLabelEdit_handler function
                 */
            }
        }

        /**
         * Edit group
         */
        private void ppGroupCM_edit_Click(object sender, EventArgs e) {

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

    }
}

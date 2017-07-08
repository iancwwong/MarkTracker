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
         * ATTRIBUTES
         * -----------------------------------
         */

        /* The node that is right-clicked on from the assessment panel */
        private UITreeViewNode curAPNode;

        /* The node that is right-clicked on from the assessment panel */
        // private UITreeViewNode curPPNode;

        /**
         * -----------------------------------
         * METHODS
         * -----------------------------------
         */
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

        /**curAPNode
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
                this.curAPNode = assessmentPanel.GetNodeAt(e.X, e.Y) as UITreeViewNode;
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
                UITreeViewNode apNode = e.Node as UITreeViewNode;
                apNode.Text = e.Label.ToString();
                // this.db.updateName(apNode.type, apNode.id, apNode.text);
                //System.Diagnostics.Debug.WriteLine("Changed name to: " + e.Label.ToString());
            }
        }

        #endregion

        #endregion
    }
}

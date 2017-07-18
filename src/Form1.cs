using MarkTracker.include;
using MarkTracker.include.db;
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

        /* ID of currently selected course */
        private int curSelCourseID = -1;        /* uninitialised value */

        /* The node that is right-clicked on from the assessment panel */
        private UITreeViewNode curAPNode;

        /* The node that is right-clicked on from the assessment panel */
        private UITreeViewNode curPPNode;

        /* Data layer handler */
        private DataLayer db = null;

        /**
         * -----------------------------------
         * METHODS
         * -----------------------------------
         */
        public markTrackerForm() {
            InitializeComponent();
            
            /* Attach UI components together */
            HookUIComponents();

            /* Initialise database connection */
            InitialiseDataConnection();

            /* Load the course and assessment data */
            LoadAPContent();
        }

        /**
         * Attaches various UI components together
         */
        private void HookUIComponents() {

            /* Attach context menu strips (ie submenu from right clicks).
             * By default, it will show when the AP is right-clicked on*/
            this.assessmentPanel.ContextMenuStrip = this.apContextMenu;

            /* Attach ap tooltip */
            this.apTooltip.SetToolTip(this.assessmentPanel, TooltipMessages.ASSESSMENT_PANEL_INFO);

            /* Attach pp tooltip */
            this.ppTooltip.SetToolTip(this.participantPanel, TooltipMessages.PARTICIPANT_PANEL_INFO);
        }

        /**
         * Opens connection to data source
         */
        private void InitialiseDataConnection() {

            this.db = new DataLayer();

            /* Create a new database if none exists */
            string dbName = "data.mtdb";        /* default name; mtdb is default extension ("MarkTracker Database") */

            DBResult result = this.db.dbExists(dbName);
            if (result.ecode == DataLayerConstants.ErrorCode.OP_SUCCESS) {
                result = this.db.createDB(dbName);
                if (result.ecode == DataLayerConstants.ErrorCode.OP_SUCCESS) {
                    /* Open data source connection */
                    this.db.openDB(dbName);
                    return;
                }
            }

            /* A db operation could not be done */
            MessageBox.Show("Error: " + result.ecode.ToString());
        }

        /**
         * Load course and assessment data from data source,
         * and populate the assessment panel treeview with
         * appropriate nodes
         */
        private void LoadAPContent() {
            List<UITreeViewNode> allAPNodes = this.db.getAllAPNodes();
            this.assessmentPanel.Nodes.AddRange(allAPNodes.ToArray());
        }

        /**
         * -----------------------------------
         * GENERAL FORM HANDLERS
         * -----------------------------------
         */
        #region General Form Handlers

        /**
         * When the user closes the form
         */
        private void markTrackerForm_FormClosing(object sender, FormClosingEventArgs e) {
            /* Close data source handler */
            this.db.closeDB();
        }

        #endregion


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

        /**
         * When a node in the assessment panel is double clicked.
         * NOTE: This node is either a: course, assessment, or component
         */
        private void assessmentPanel_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            /* Initiate the participant panel contents appropriately */
            /* We ONLY need to view the groups and students related
             * to the COURSE associated with the selected assessment 
             * panel node */

            /* Check if the course associated to the selected AP node
             * is already selected */
            int newSelCourseID = this.curAPNode.getRootNode().id;
            if (newSelCourseID != this.curSelCourseID) {
                /* Initiate the participant panel nodes */
                this.curSelCourseID = newSelCourseID;
                // TODO: parse data into nodes for pp
                // this.participantPanel.Nodes.add(this.db.getAllParticipantNodes(this.curSelCourseID));

                /* Attach context menu strip */
                this.participantPanel.ContextMenuStrip = this.ppContextMenu;

                /* Collapse all for better UI aesthetics */
                this.participantPanel.CollapseAll();
            }

            /* Keep the double-clicked node expanded */
            this.curAPNode.Expand();

        }

        #endregion

        /**
       * -----------------------------------
       * PARTICIPANT PANEL (TREE VIEW)
       * -----------------------------------
       */
        #region Participant Panel handlers

        /** 
         * Updates the reference participant node that was
         * clicked on
         */
        private void getPPNodeFromClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) {
                // Select the clicked node
                this.curPPNode = this.participantPanel.GetNodeAt(e.X, e.Y) as UITreeViewNode;
            }
        }

        /**
         * Handler for when the label for a PPNode is changed
         */
        private void participantPanel_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            if (e.Label != null) {
                /* New name should have a length > 0 */
                if (e.Label.Length == 0) {
                    /* Prompt user to re-enter a new name */
                    e.CancelEdit = true;
                    MessageBox.Show("New name cannot be blank");
                    e.Node.BeginEdit();
                }

                /* Update the name of the node in UI and DB */
                UITreeViewNode ppNode = e.Node as UITreeViewNode;
                ppNode.Text = e.Label.ToString();
                // this.db.updateName(ppNode.type, ppNode.id, ppNode.text);
                //System.Diagnostics.Debug.WriteLine("PPNode Changed name to: " + e.Label.ToString());
            }
        }

        #endregion

    }
}

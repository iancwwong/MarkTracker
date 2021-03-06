﻿using MarkTracker.include;
using MarkTracker.include.db;
using MarkTracker.include.entities;
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
using static MarkTracker.include.db.DataLayerConstants;

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
            string dbName = "testDB";        /* default name */
            InitialiseDataConnection(dbName);

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
        private void InitialiseDataConnection(string dbName) {

            /* Create data layer */
            this.db = new DataLayer();

            /* Create a new database if none exists */
            DBResult result = this.db.dbExists(dbName);
            if (result.ecode == ErrorCode.OP_SUCCESS) {

                /* Database doesn't exist - create */
                bool needToInit = false;
                if (result.boolVal == false) {
                    this.db.createDB(dbName);
                    needToInit = true;
                }

                /* Open data source connection */
                result = this.db.openDB(dbName);

                if (needToInit) {
                    this.db.initialiseDB();
                }
            }

            if (result.ecode != ErrorCode.OP_SUCCESS) {
                this.showDBError(result);
                this.Close();
            }
        }

        /**
         * Load course and assessment data from data source,
         * and populate the assessment panel treeview with
         * appropriate nodes
         */
        private void LoadAPContent() {

            /* Prepare all the AP nodes */
            List<UITreeViewNode> allAPNodes = this.db.getAllAPNodes(this.apCourseContextMenu,
                                                                    this.apAssessmentContextMenu,
                                                                    this.apComponentContextMenu);

            /* Finally, add the nodes to the UI tree view */
            this.assessmentPanel.Nodes.AddRange(allAPNodes.ToArray());
            this.assessmentPanel.CollapseAll();
            this.assessmentPanel.SelectedNode = null;
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

                /* Update the name of the node in DB an UI */
                UITreeViewNode apNode = e.Node as UITreeViewNode;
                DBResult res = this.db.updateName(apNode.type, apNode.id, e.Label.ToString());
                if (res.ecode == ErrorCode.OP_SUCCESS) {
                    apNode.Text = e.Label.ToString();
                } else {
                    e.CancelEdit = true;
                    this.showDBError(res);
                }
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

                /* Obtain all PP Nodes, and add them to this treeview */
                List<UITreeViewNode> allPPNodes = this.db.getAllPPNodes(this.curSelCourseID,
                                                                        this.ppGroupContextMenu,
                                                                        this.ppStudentContextMenu);
                this.participantPanel.Nodes.Clear();
                this.participantPanel.Nodes.AddRange(allPPNodes.ToArray());

                /* Attach context menu strip to treeview panel */
                this.participantPanel.ContextMenuStrip = this.ppContextMenu;

                /* aesthetics */
                this.participantPanel.CollapseAll();
                this.participantPanel.SelectedNode = null;
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

                /* Update the name of the node in DB an UI */
                UITreeViewNode ppNode = e.Node as UITreeViewNode;
                DBResult res = this.db.updateName(ppNode.type, ppNode.id, e.Label.ToString());
                if (res.ecode == ErrorCode.OP_SUCCESS) {
                    ppNode.Text = e.Label.ToString();
                } else {
                    e.CancelEdit = true;
                    this.showDBError(res);
                }
            }
        }

        /**
         * Showing an error response from DB
         */
        private void showDBError(DBResult result) {
            MessageBox.Show(result.ecode.ToString(), "", MessageBoxButtons.OKCancel);
        }

        #endregion
    }
}

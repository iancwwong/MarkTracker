namespace MarkTracker {
    partial class markTrackerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(markTrackerForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.assessmentPanel = new System.Windows.Forms.TreeView();
            this.apContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberOfParticipantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apCourseContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.apCourseCM_new_assessment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.apCourseCM_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.apCourse_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.apCourseCM_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_new_component = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.apAssessmentCM_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_view_statistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.apAssessmentCM_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.apComponentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.componentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.apContextMenu.SuspendLayout();
            this.apCourseContextMenu.SuspendLayout();
            this.apAssessmentContextMenu.SuspendLayout();
            this.apComponentContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.assessmentPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 511F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // assessmentPanel
            // 
            this.assessmentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assessmentPanel.LabelEdit = true;
            this.assessmentPanel.Location = new System.Drawing.Point(3, 3);
            this.assessmentPanel.Name = "assessmentPanel";
            this.assessmentPanel.Size = new System.Drawing.Size(259, 505);
            this.assessmentPanel.TabIndex = 0;
            this.assessmentPanel.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.afterAPLabelEdit_handler);
            this.assessmentPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getAPNodeFromClick);
            // 
            // apContextMenu
            // 
            this.apContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator3,
            this.sortByToolStripMenuItem});
            this.apContextMenu.Name = "apContextMenu";
            this.apContextMenu.Size = new System.Drawing.Size(112, 54);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.courseToolStripMenuItem.Text = "Course";
            this.courseToolStripMenuItem.Click += new System.EventHandler(this.courseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(108, 6);
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.numberOfParticipantsToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.sortByToolStripMenuItem.Text = "Sort By";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // numberOfParticipantsToolStripMenuItem
            // 
            this.numberOfParticipantsToolStripMenuItem.Name = "numberOfParticipantsToolStripMenuItem";
            this.numberOfParticipantsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.numberOfParticipantsToolStripMenuItem.Text = "Number of participants";
            this.numberOfParticipantsToolStripMenuItem.Click += new System.EventHandler(this.numberOfParticipantsToolStripMenuItem_Click);
            // 
            // apCourseContextMenu
            // 
            this.apCourseContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.toolStripSeparator2,
            this.apCourseCM_rename,
            this.apCourse_edit,
            this.toolStripSeparator1,
            this.apCourseCM_delete});
            this.apCourseContextMenu.Name = "apCourseContextMenu";
            this.apCourseContextMenu.Size = new System.Drawing.Size(118, 104);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apCourseCM_new_assessment});
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // apCourseCM_new_assessment
            // 
            this.apCourseCM_new_assessment.Name = "apCourseCM_new_assessment";
            this.apCourseCM_new_assessment.Size = new System.Drawing.Size(152, 22);
            this.apCourseCM_new_assessment.Text = "Assessment";
            this.apCourseCM_new_assessment.Click += new System.EventHandler(this.apCourseCM_new_assessment_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
            // 
            // apCourseCM_rename
            // 
            this.apCourseCM_rename.Name = "apCourseCM_rename";
            this.apCourseCM_rename.Size = new System.Drawing.Size(117, 22);
            this.apCourseCM_rename.Text = "Rename";
            this.apCourseCM_rename.Click += new System.EventHandler(this.apCourseCM_rename_Click);
            // 
            // apCourse_edit
            // 
            this.apCourse_edit.Name = "apCourse_edit";
            this.apCourse_edit.Size = new System.Drawing.Size(117, 22);
            this.apCourse_edit.Text = "Edit";
            this.apCourse_edit.Click += new System.EventHandler(this.apCourseCM_edit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // apCourseCM_delete
            // 
            this.apCourseCM_delete.Name = "apCourseCM_delete";
            this.apCourseCM_delete.Size = new System.Drawing.Size(117, 22);
            this.apCourseCM_delete.Text = "Delete";
            this.apCourseCM_delete.Click += new System.EventHandler(this.apCourseCM_delete_Click);
            // 
            // apAssessmentContextMenu
            // 
            this.apAssessmentContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem2,
            this.toolStripSeparator5,
            this.apAssessmentCM_rename,
            this.apAssessmentCM_edit,
            this.viewToolStripMenuItem,
            this.toolStripSeparator4,
            this.apAssessmentCM_delete});
            this.apAssessmentContextMenu.Name = "apAssessmentContextMenu";
            this.apAssessmentContextMenu.Size = new System.Drawing.Size(118, 126);
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apAssessmentCM_new_component});
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.newToolStripMenuItem2.Text = "New";
            // 
            // apAssessmentCM_new_component
            // 
            this.apAssessmentCM_new_component.Name = "apAssessmentCM_new_component";
            this.apAssessmentCM_new_component.Size = new System.Drawing.Size(152, 22);
            this.apAssessmentCM_new_component.Text = "Component";
            this.apAssessmentCM_new_component.Click += new System.EventHandler(this.apAssessmentCM_new_component_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(114, 6);
            // 
            // apAssessmentCM_rename
            // 
            this.apAssessmentCM_rename.Name = "apAssessmentCM_rename";
            this.apAssessmentCM_rename.Size = new System.Drawing.Size(117, 22);
            this.apAssessmentCM_rename.Text = "Rename";
            this.apAssessmentCM_rename.Click += new System.EventHandler(this.apAssessmentCM_rename_Click);
            // 
            // apAssessmentCM_edit
            // 
            this.apAssessmentCM_edit.Name = "apAssessmentCM_edit";
            this.apAssessmentCM_edit.Size = new System.Drawing.Size(117, 22);
            this.apAssessmentCM_edit.Text = "Edit";
            this.apAssessmentCM_edit.Click += new System.EventHandler(this.apAssessmentCM_edit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apAssessmentCM_view_statistics});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // apAssessmentCM_view_statistics
            // 
            this.apAssessmentCM_view_statistics.Name = "apAssessmentCM_view_statistics";
            this.apAssessmentCM_view_statistics.Size = new System.Drawing.Size(152, 22);
            this.apAssessmentCM_view_statistics.Text = "Statistics";
            this.apAssessmentCM_view_statistics.Click += new System.EventHandler(this.apAssessmentCM_view_statistics_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(114, 6);
            // 
            // apAssessmentCM_delete
            // 
            this.apAssessmentCM_delete.Name = "apAssessmentCM_delete";
            this.apAssessmentCM_delete.Size = new System.Drawing.Size(117, 22);
            this.apAssessmentCM_delete.Text = "Delete";
            this.apAssessmentCM_delete.Click += new System.EventHandler(this.apAssessmentCM_delete_Click);
            // 
            // apComponentContextMenu
            // 
            this.apComponentContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem3,
            this.renameToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.apComponentContextMenu.Name = "apComponentContextMenu";
            this.apComponentContextMenu.Size = new System.Drawing.Size(153, 136);
            // 
            // newToolStripMenuItem3
            // 
            this.newToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentToolStripMenuItem});
            this.newToolStripMenuItem3.Name = "newToolStripMenuItem3";
            this.newToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem3.Text = "New";
            // 
            // componentToolStripMenuItem
            // 
            this.componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            this.componentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.componentToolStripMenuItem.Text = "Component";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsToolStripMenuItem});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // markTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "markTrackerForm";
            this.Text = "MarkTracker";
            this.Load += new System.EventHandler(this.markTrackerForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.apContextMenu.ResumeLayout(false);
            this.apCourseContextMenu.ResumeLayout(false);
            this.apAssessmentContextMenu.ResumeLayout(false);
            this.apComponentContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView assessmentPanel;
        private System.Windows.Forms.ContextMenuStrip apContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberOfParticipantsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip apCourseContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_new_assessment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_rename;
        private System.Windows.Forms.ToolStripMenuItem apCourse_edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip apAssessmentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_new_component;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_rename;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_edit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_view_statistics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_delete;
        private System.Windows.Forms.ContextMenuStrip apComponentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem componentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}


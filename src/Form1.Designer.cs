﻿namespace MarkTracker {
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
            this.apCM_new = new System.Windows.Forms.ToolStripMenuItem();
            this.apCM_new_course = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.apCM_sort = new System.Windows.Forms.ToolStripMenuItem();
            this.apCM_sort_name = new System.Windows.Forms.ToolStripMenuItem();
            this.apCM_sort_numParticipants = new System.Windows.Forms.ToolStripMenuItem();
            this.apCourseContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apCourseCM_new = new System.Windows.Forms.ToolStripMenuItem();
            this.apCourseCM_new_assessment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.apCourseCM_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.apCourse_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.apCourseCM_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apAssessmentCM_new = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_new_component = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.apAssessmentCM_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_view = new System.Windows.Forms.ToolStripMenuItem();
            this.apAssessmentCM_view_statistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.apAssessmentCM_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.apComponentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apComponentCM_new = new System.Windows.Forms.ToolStripMenuItem();
            this.apComponentCM_new_component = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.apComponentCM_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.apComponentCM_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.apComponentCM_view = new System.Windows.Forms.ToolStripMenuItem();
            this.apComponentCM_view_statistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.apComponentCM_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.apTooltip = new System.Windows.Forms.ToolTip(this.components);
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
            this.apCM_new,
            this.toolStripSeparator3,
            this.apCM_sort});
            this.apContextMenu.Name = "apContextMenu";
            this.apContextMenu.Size = new System.Drawing.Size(112, 54);
            // 
            // apCM_new
            // 
            this.apCM_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apCM_new_course});
            this.apCM_new.Name = "apCM_new";
            this.apCM_new.Size = new System.Drawing.Size(111, 22);
            this.apCM_new.Text = "New";
            // 
            // apCM_new_course
            // 
            this.apCM_new_course.Name = "apCM_new_course";
            this.apCM_new_course.Size = new System.Drawing.Size(111, 22);
            this.apCM_new_course.Text = "Course";
            this.apCM_new_course.Click += new System.EventHandler(this.apCM_new_course_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(108, 6);
            // 
            // apCM_sort
            // 
            this.apCM_sort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apCM_sort_name,
            this.apCM_sort_numParticipants});
            this.apCM_sort.Name = "apCM_sort";
            this.apCM_sort.Size = new System.Drawing.Size(111, 22);
            this.apCM_sort.Text = "Sort By";
            // 
            // apCM_sort_name
            // 
            this.apCM_sort_name.Name = "apCM_sort_name";
            this.apCM_sort_name.Size = new System.Drawing.Size(197, 22);
            this.apCM_sort_name.Text = "Name";
            this.apCM_sort_name.Click += new System.EventHandler(this.apCM_sort_name_Click);
            // 
            // apCM_sort_numParticipants
            // 
            this.apCM_sort_numParticipants.Name = "apCM_sort_numParticipants";
            this.apCM_sort_numParticipants.Size = new System.Drawing.Size(197, 22);
            this.apCM_sort_numParticipants.Text = "Number of participants";
            this.apCM_sort_numParticipants.Click += new System.EventHandler(this.apCM_sort_numParticipants_Click);
            // 
            // apCourseContextMenu
            // 
            this.apCourseContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apCourseCM_new,
            this.toolStripSeparator2,
            this.apCourseCM_rename,
            this.apCourse_edit,
            this.toolStripSeparator1,
            this.apCourseCM_delete});
            this.apCourseContextMenu.Name = "apCourseContextMenu";
            this.apCourseContextMenu.Size = new System.Drawing.Size(118, 104);
            // 
            // apCourseCM_new
            // 
            this.apCourseCM_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apCourseCM_new_assessment});
            this.apCourseCM_new.Name = "apCourseCM_new";
            this.apCourseCM_new.Size = new System.Drawing.Size(117, 22);
            this.apCourseCM_new.Text = "New";
            // 
            // apCourseCM_new_assessment
            // 
            this.apCourseCM_new_assessment.Name = "apCourseCM_new_assessment";
            this.apCourseCM_new_assessment.Size = new System.Drawing.Size(136, 22);
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
            this.apAssessmentCM_new,
            this.toolStripSeparator5,
            this.apAssessmentCM_rename,
            this.apAssessmentCM_edit,
            this.apAssessmentCM_view,
            this.toolStripSeparator4,
            this.apAssessmentCM_delete});
            this.apAssessmentContextMenu.Name = "apAssessmentContextMenu";
            this.apAssessmentContextMenu.Size = new System.Drawing.Size(118, 126);
            // 
            // apAssessmentCM_new
            // 
            this.apAssessmentCM_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apAssessmentCM_new_component});
            this.apAssessmentCM_new.Name = "apAssessmentCM_new";
            this.apAssessmentCM_new.Size = new System.Drawing.Size(117, 22);
            this.apAssessmentCM_new.Text = "New";
            // 
            // apAssessmentCM_new_component
            // 
            this.apAssessmentCM_new_component.Name = "apAssessmentCM_new_component";
            this.apAssessmentCM_new_component.Size = new System.Drawing.Size(138, 22);
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
            // apAssessmentCM_view
            // 
            this.apAssessmentCM_view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apAssessmentCM_view_statistics});
            this.apAssessmentCM_view.Name = "apAssessmentCM_view";
            this.apAssessmentCM_view.Size = new System.Drawing.Size(117, 22);
            this.apAssessmentCM_view.Text = "View";
            // 
            // apAssessmentCM_view_statistics
            // 
            this.apAssessmentCM_view_statistics.Name = "apAssessmentCM_view_statistics";
            this.apAssessmentCM_view_statistics.Size = new System.Drawing.Size(120, 22);
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
            this.apComponentCM_new,
            this.toolStripSeparator6,
            this.apComponentCM_rename,
            this.apComponentCM_edit,
            this.apComponentCM_view,
            this.toolStripSeparator7,
            this.apComponentCM_delete});
            this.apComponentContextMenu.Name = "apComponentContextMenu";
            this.apComponentContextMenu.Size = new System.Drawing.Size(118, 126);
            // 
            // apComponentCM_new
            // 
            this.apComponentCM_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apComponentCM_new_component});
            this.apComponentCM_new.Name = "apComponentCM_new";
            this.apComponentCM_new.Size = new System.Drawing.Size(117, 22);
            this.apComponentCM_new.Text = "New";
            // 
            // apComponentCM_new_component
            // 
            this.apComponentCM_new_component.Name = "apComponentCM_new_component";
            this.apComponentCM_new_component.Size = new System.Drawing.Size(138, 22);
            this.apComponentCM_new_component.Text = "Component";
            this.apComponentCM_new_component.Click += new System.EventHandler(this.apComponentCM_new_component_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(114, 6);
            // 
            // apComponentCM_rename
            // 
            this.apComponentCM_rename.Name = "apComponentCM_rename";
            this.apComponentCM_rename.Size = new System.Drawing.Size(117, 22);
            this.apComponentCM_rename.Text = "Rename";
            this.apComponentCM_rename.Click += new System.EventHandler(this.apComponentCM_rename_Click);
            // 
            // apComponentCM_edit
            // 
            this.apComponentCM_edit.Name = "apComponentCM_edit";
            this.apComponentCM_edit.Size = new System.Drawing.Size(117, 22);
            this.apComponentCM_edit.Text = "Edit";
            this.apComponentCM_edit.Click += new System.EventHandler(this.apComponentCM_edit_Click);
            // 
            // apComponentCM_view
            // 
            this.apComponentCM_view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apComponentCM_view_statistics});
            this.apComponentCM_view.Name = "apComponentCM_view";
            this.apComponentCM_view.Size = new System.Drawing.Size(117, 22);
            this.apComponentCM_view.Text = "View";
            // 
            // apComponentCM_view_statistics
            // 
            this.apComponentCM_view_statistics.Name = "apComponentCM_view_statistics";
            this.apComponentCM_view_statistics.Size = new System.Drawing.Size(120, 22);
            this.apComponentCM_view_statistics.Text = "Statistics";
            this.apComponentCM_view_statistics.Click += new System.EventHandler(this.apComponentCM_view_statistics_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(114, 6);
            // 
            // apComponentCM_delete
            // 
            this.apComponentCM_delete.Name = "apComponentCM_delete";
            this.apComponentCM_delete.Size = new System.Drawing.Size(117, 22);
            this.apComponentCM_delete.Text = "Delete";
            this.apComponentCM_delete.Click += new System.EventHandler(this.apComponentCM_delete_Click);
            // 
            // apTooltip
            // 
            this.apTooltip.AutoPopDelay = 5000;
            this.apTooltip.InitialDelay = 800;
            this.apTooltip.ReshowDelay = 500;
            this.apTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.apTooltip.ToolTipTitle = "Assessment Panel";
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
        private System.Windows.Forms.ToolStripMenuItem apCM_new;
        private System.Windows.Forms.ToolStripMenuItem apCM_new_course;
        private System.Windows.Forms.ToolStripMenuItem apCM_sort;
        private System.Windows.Forms.ToolStripMenuItem apCM_sort_name;
        private System.Windows.Forms.ToolStripMenuItem apCM_sort_numParticipants;
        private System.Windows.Forms.ContextMenuStrip apCourseContextMenu;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_new;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_new_assessment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_rename;
        private System.Windows.Forms.ToolStripMenuItem apCourse_edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem apCourseCM_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip apAssessmentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_new;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_new_component;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_rename;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_edit;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_view;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_view_statistics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem apAssessmentCM_delete;
        private System.Windows.Forms.ContextMenuStrip apComponentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_new;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_new_component;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_rename;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_edit;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_view;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_view_statistics;
        private System.Windows.Forms.ToolStripMenuItem apComponentCM_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolTip apTooltip;
    }
}


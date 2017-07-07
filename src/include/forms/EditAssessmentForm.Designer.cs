namespace MarkTracker.include.forms {
    partial class EditAssessmentForm {
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
            this.saveButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.assessmentNameEditBox = new System.Windows.Forms.TextBox();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.totalMarkLabel = new System.Windows.Forms.Label();
            this.totalMarkNumeric = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(67, 226);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(37, 38);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // assessmentNameEditBox
            // 
            this.assessmentNameEditBox.Location = new System.Drawing.Point(111, 35);
            this.assessmentNameEditBox.Name = "assessmentNameEditBox";
            this.assessmentNameEditBox.Size = new System.Drawing.Size(146, 20);
            this.assessmentNameEditBox.TabIndex = 3;
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Location = new System.Drawing.Point(111, 61);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(146, 20);
            this.dueDatePicker.TabIndex = 4;
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.AutoSize = true;
            this.dueDateLabel.Location = new System.Drawing.Point(37, 63);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(56, 13);
            this.dueDateLabel.TabIndex = 5;
            this.dueDateLabel.Text = "Due Date:";
            // 
            // totalMarkLabel
            // 
            this.totalMarkLabel.AutoSize = true;
            this.totalMarkLabel.Location = new System.Drawing.Point(37, 90);
            this.totalMarkLabel.Name = "totalMarkLabel";
            this.totalMarkLabel.Size = new System.Drawing.Size(66, 13);
            this.totalMarkLabel.TabIndex = 6;
            this.totalMarkLabel.Text = "Total Marks:";
            // 
            // totalMarkNumeric
            // 
            this.totalMarkNumeric.Location = new System.Drawing.Point(111, 87);
            this.totalMarkNumeric.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.totalMarkNumeric.Name = "totalMarkNumeric";
            this.totalMarkNumeric.Size = new System.Drawing.Size(58, 20);
            this.totalMarkNumeric.TabIndex = 7;
            this.totalMarkNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalMarkNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(148, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // EditAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.totalMarkNumeric);
            this.Controls.Add(this.totalMarkLabel);
            this.Controls.Add(this.dueDateLabel);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.assessmentNameEditBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EditAssessmentForm";
            this.ShowIcon = false;
            this.Text = "Edit Assessment";
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox assessmentNameEditBox;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.Label totalMarkLabel;
        private System.Windows.Forms.NumericUpDown totalMarkNumeric;
        private System.Windows.Forms.Button cancelButton;
    }
}
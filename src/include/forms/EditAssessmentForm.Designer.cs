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
            this.weightingNumeric = new System.Windows.Forms.NumericUpDown();
            this.weightingLabel = new System.Windows.Forms.Label();
            this.percentageSign = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsEditBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightingNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(67, 226);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(38, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // assessmentNameEditBox
            // 
            this.assessmentNameEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assessmentNameEditBox.Location = new System.Drawing.Point(112, 25);
            this.assessmentNameEditBox.Name = "assessmentNameEditBox";
            this.assessmentNameEditBox.Size = new System.Drawing.Size(146, 20);
            this.assessmentNameEditBox.TabIndex = 3;
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDatePicker.Location = new System.Drawing.Point(112, 51);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(146, 20);
            this.dueDatePicker.TabIndex = 4;
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dueDateLabel.AutoSize = true;
            this.dueDateLabel.Location = new System.Drawing.Point(38, 53);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(56, 13);
            this.dueDateLabel.TabIndex = 5;
            this.dueDateLabel.Text = "Due Date:";
            // 
            // totalMarkLabel
            // 
            this.totalMarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalMarkLabel.AutoSize = true;
            this.totalMarkLabel.Location = new System.Drawing.Point(38, 80);
            this.totalMarkLabel.Name = "totalMarkLabel";
            this.totalMarkLabel.Size = new System.Drawing.Size(66, 13);
            this.totalMarkLabel.TabIndex = 6;
            this.totalMarkLabel.Text = "Total Marks:";
            // 
            // totalMarkNumeric
            // 
            this.totalMarkNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.totalMarkNumeric.Location = new System.Drawing.Point(112, 77);
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
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.Location = new System.Drawing.Point(148, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // weightingNumeric
            // 
            this.weightingNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.weightingNumeric.Location = new System.Drawing.Point(112, 104);
            this.weightingNumeric.Name = "weightingNumeric";
            this.weightingNumeric.Size = new System.Drawing.Size(58, 20);
            this.weightingNumeric.TabIndex = 10;
            this.weightingNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.weightingNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // weightingLabel
            // 
            this.weightingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weightingLabel.AutoSize = true;
            this.weightingLabel.Location = new System.Drawing.Point(38, 107);
            this.weightingLabel.Name = "weightingLabel";
            this.weightingLabel.Size = new System.Drawing.Size(58, 13);
            this.weightingLabel.TabIndex = 9;
            this.weightingLabel.Text = "Weighting:";
            // 
            // percentageSign
            // 
            this.percentageSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.percentageSign.AutoSize = true;
            this.percentageSign.Location = new System.Drawing.Point(176, 107);
            this.percentageSign.Name = "percentageSign";
            this.percentageSign.Size = new System.Drawing.Size(15, 13);
            this.percentageSign.TabIndex = 11;
            this.percentageSign.Text = "%";
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(38, 133);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(59, 13);
            this.commentsLabel.TabIndex = 12;
            this.commentsLabel.Text = "Comments:";
            // 
            // commentsEditBox
            // 
            this.commentsEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsEditBox.Location = new System.Drawing.Point(112, 133);
            this.commentsEditBox.Name = "commentsEditBox";
            this.commentsEditBox.Size = new System.Drawing.Size(146, 77);
            this.commentsEditBox.TabIndex = 13;
            this.commentsEditBox.Text = "";
            // 
            // EditAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.commentsEditBox);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.percentageSign);
            this.Controls.Add(this.weightingNumeric);
            this.Controls.Add(this.weightingLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.totalMarkNumeric);
            this.Controls.Add(this.totalMarkLabel);
            this.Controls.Add(this.dueDateLabel);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.assessmentNameEditBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.saveButton);
            this.Name = "EditAssessmentForm";
            this.ShowIcon = false;
            this.Text = "Edit Assessment";
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightingNumeric)).EndInit();
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
        private System.Windows.Forms.NumericUpDown weightingNumeric;
        private System.Windows.Forms.Label weightingLabel;
        private System.Windows.Forms.Label percentageSign;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.RichTextBox commentsEditBox;
    }
}
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
            this.nameEditBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.weightingLabel = new System.Windows.Forms.Label();
            this.totalMarkLabel = new System.Windows.Forms.Label();
            this.dueDateLabel = new System.Windows.Forms.Label();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.totalMarkNumeric = new System.Windows.Forms.NumericUpDown();
            this.weightingNumeric = new System.Windows.Forms.NumericUpDown();
            this.commentsEditBox = new System.Windows.Forms.RichTextBox();
            this.dueTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dueTimeLabel = new System.Windows.Forms.Label();
            this.percentageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightingNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(90, 292);
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(171, 292);
            // 
            // nameEditBox
            // 
            this.nameEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameEditBox.Location = new System.Drawing.Point(124, 32);
            this.nameEditBox.Name = "nameEditBox";
            this.nameEditBox.Size = new System.Drawing.Size(178, 20);
            this.nameEditBox.TabIndex = 14;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(43, 35);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Name:";
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(43, 162);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(59, 13);
            this.commentsLabel.TabIndex = 15;
            this.commentsLabel.Text = "Comments:";
            // 
            // weightingLabel
            // 
            this.weightingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weightingLabel.AutoSize = true;
            this.weightingLabel.Location = new System.Drawing.Point(43, 138);
            this.weightingLabel.Name = "weightingLabel";
            this.weightingLabel.Size = new System.Drawing.Size(58, 13);
            this.weightingLabel.TabIndex = 16;
            this.weightingLabel.Text = "Weighting:";
            // 
            // totalMarkLabel
            // 
            this.totalMarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalMarkLabel.AutoSize = true;
            this.totalMarkLabel.Location = new System.Drawing.Point(43, 113);
            this.totalMarkLabel.Name = "totalMarkLabel";
            this.totalMarkLabel.Size = new System.Drawing.Size(66, 13);
            this.totalMarkLabel.TabIndex = 17;
            this.totalMarkLabel.Text = "Total Marks:";
            // 
            // dueDateLabel
            // 
            this.dueDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dueDateLabel.AutoSize = true;
            this.dueDateLabel.Location = new System.Drawing.Point(43, 61);
            this.dueDateLabel.Name = "dueDateLabel";
            this.dueDateLabel.Size = new System.Drawing.Size(56, 13);
            this.dueDateLabel.TabIndex = 18;
            this.dueDateLabel.Text = "Due Date:";
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dueDatePicker.Location = new System.Drawing.Point(124, 58);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(110, 20);
            this.dueDatePicker.TabIndex = 19;
            // 
            // totalMarkNumeric
            // 
            this.totalMarkNumeric.Location = new System.Drawing.Point(124, 110);
            this.totalMarkNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.totalMarkNumeric.Name = "totalMarkNumeric";
            this.totalMarkNumeric.Size = new System.Drawing.Size(55, 20);
            this.totalMarkNumeric.TabIndex = 20;
            this.totalMarkNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalMarkNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // weightingNumeric
            // 
            this.weightingNumeric.Location = new System.Drawing.Point(124, 136);
            this.weightingNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.weightingNumeric.Name = "weightingNumeric";
            this.weightingNumeric.Size = new System.Drawing.Size(55, 20);
            this.weightingNumeric.TabIndex = 21;
            this.weightingNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.weightingNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // commentsEditBox
            // 
            this.commentsEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsEditBox.Location = new System.Drawing.Point(124, 162);
            this.commentsEditBox.Name = "commentsEditBox";
            this.commentsEditBox.Size = new System.Drawing.Size(178, 108);
            this.commentsEditBox.TabIndex = 22;
            this.commentsEditBox.Text = "";
            this.commentsEditBox.WordWrap = false;
            // 
            // dueTimePicker
            // 
            this.dueTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dueTimePicker.Location = new System.Drawing.Point(124, 84);
            this.dueTimePicker.Name = "dueTimePicker";
            this.dueTimePicker.ShowUpDown = true;
            this.dueTimePicker.Size = new System.Drawing.Size(110, 20);
            this.dueTimePicker.TabIndex = 24;
            // 
            // dueTimeLabel
            // 
            this.dueTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dueTimeLabel.AutoSize = true;
            this.dueTimeLabel.Location = new System.Drawing.Point(43, 87);
            this.dueTimeLabel.Name = "dueTimeLabel";
            this.dueTimeLabel.Size = new System.Drawing.Size(56, 13);
            this.dueTimeLabel.TabIndex = 23;
            this.dueTimeLabel.Text = "Due Time:";
            // 
            // percentageLabel
            // 
            this.percentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(193, 139);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(15, 13);
            this.percentageLabel.TabIndex = 25;
            this.percentageLabel.Text = "%";
            // 
            // EditAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(335, 331);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.dueTimePicker);
            this.Controls.Add(this.dueTimeLabel);
            this.Controls.Add(this.commentsEditBox);
            this.Controls.Add(this.weightingNumeric);
            this.Controls.Add(this.totalMarkNumeric);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.dueDateLabel);
            this.Controls.Add(this.totalMarkLabel);
            this.Controls.Add(this.weightingLabel);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.nameEditBox);
            this.Controls.Add(this.nameLabel);
            this.MinimumSize = new System.Drawing.Size(351, 370);
            this.Name = "EditAssessmentForm";
            this.Text = "Edit Assessment";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.nameLabel, 0);
            this.Controls.SetChildIndex(this.nameEditBox, 0);
            this.Controls.SetChildIndex(this.commentsLabel, 0);
            this.Controls.SetChildIndex(this.weightingLabel, 0);
            this.Controls.SetChildIndex(this.totalMarkLabel, 0);
            this.Controls.SetChildIndex(this.dueDateLabel, 0);
            this.Controls.SetChildIndex(this.dueDatePicker, 0);
            this.Controls.SetChildIndex(this.totalMarkNumeric, 0);
            this.Controls.SetChildIndex(this.weightingNumeric, 0);
            this.Controls.SetChildIndex(this.commentsEditBox, 0);
            this.Controls.SetChildIndex(this.dueTimeLabel, 0);
            this.Controls.SetChildIndex(this.dueTimePicker, 0);
            this.Controls.SetChildIndex(this.percentageLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightingNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameEditBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.Label weightingLabel;
        private System.Windows.Forms.Label totalMarkLabel;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.NumericUpDown totalMarkNumeric;
        private System.Windows.Forms.NumericUpDown weightingNumeric;
        private System.Windows.Forms.RichTextBox commentsEditBox;
        private System.Windows.Forms.DateTimePicker dueTimePicker;
        private System.Windows.Forms.Label dueTimeLabel;
        private System.Windows.Forms.Label percentageLabel;
    }
}

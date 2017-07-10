namespace MarkTracker.include.forms {
    partial class EditStudentForm {
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
            this.studIDEditBox = new System.Windows.Forms.TextBox();
            this.studIDLabel = new System.Windows.Forms.Label();
            this.firstNameEditBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameEditBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(65, 125);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(146, 125);
            // 
            // studIDEditBox
            // 
            this.studIDEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studIDEditBox.Location = new System.Drawing.Point(93, 28);
            this.studIDEditBox.Name = "studIDEditBox";
            this.studIDEditBox.Size = new System.Drawing.Size(146, 20);
            this.studIDEditBox.TabIndex = 14;
            // 
            // studIDLabel
            // 
            this.studIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studIDLabel.AutoSize = true;
            this.studIDLabel.Location = new System.Drawing.Point(31, 31);
            this.studIDLabel.Name = "studIDLabel";
            this.studIDLabel.Size = new System.Drawing.Size(21, 13);
            this.studIDLabel.TabIndex = 13;
            this.studIDLabel.Text = "ID:";
            // 
            // firstNameEditBox
            // 
            this.firstNameEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameEditBox.Location = new System.Drawing.Point(93, 54);
            this.firstNameEditBox.Name = "firstNameEditBox";
            this.firstNameEditBox.Size = new System.Drawing.Size(146, 20);
            this.firstNameEditBox.TabIndex = 16;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(31, 57);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.firstNameLabel.TabIndex = 15;
            this.firstNameLabel.Text = "First Name:";
            // 
            // lastNameEditBox
            // 
            this.lastNameEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameEditBox.Location = new System.Drawing.Point(93, 80);
            this.lastNameEditBox.Name = "lastNameEditBox";
            this.lastNameEditBox.Size = new System.Drawing.Size(146, 20);
            this.lastNameEditBox.TabIndex = 18;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(31, 83);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 17;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // EditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.lastNameEditBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameEditBox);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.studIDEditBox);
            this.Controls.Add(this.studIDLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditStudentForm";
            this.Text = "Edit Student";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.studIDLabel, 0);
            this.Controls.SetChildIndex(this.studIDEditBox, 0);
            this.Controls.SetChildIndex(this.firstNameLabel, 0);
            this.Controls.SetChildIndex(this.firstNameEditBox, 0);
            this.Controls.SetChildIndex(this.lastNameLabel, 0);
            this.Controls.SetChildIndex(this.lastNameEditBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studIDEditBox;
        private System.Windows.Forms.Label studIDLabel;
        private System.Windows.Forms.TextBox firstNameEditBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox lastNameEditBox;
        private System.Windows.Forms.Label lastNameLabel;
    }
}

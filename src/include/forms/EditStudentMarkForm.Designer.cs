namespace MarkTracker.include.forms {
    partial class EditStudentMarkForm {
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
            this.givenMarkNumeric = new System.Windows.Forms.NumericUpDown();
            this.givenMarkLabel = new System.Windows.Forms.Label();
            this.commentsEditBox = new System.Windows.Forms.RichTextBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.fractionSign = new System.Windows.Forms.Label();
            this.componentMarkLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.givenMarkNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(71, 202);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(152, 202);
            // 
            // givenMarkNumeric
            // 
            this.givenMarkNumeric.Location = new System.Drawing.Point(91, 26);
            this.givenMarkNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.givenMarkNumeric.Name = "givenMarkNumeric";
            this.givenMarkNumeric.Size = new System.Drawing.Size(55, 20);
            this.givenMarkNumeric.TabIndex = 22;
            this.givenMarkNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.givenMarkNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // givenMarkLabel
            // 
            this.givenMarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.givenMarkLabel.AutoSize = true;
            this.givenMarkLabel.Location = new System.Drawing.Point(26, 28);
            this.givenMarkLabel.Name = "givenMarkLabel";
            this.givenMarkLabel.Size = new System.Drawing.Size(34, 13);
            this.givenMarkLabel.TabIndex = 21;
            this.givenMarkLabel.Text = "Mark:";
            // 
            // commentsEditBox
            // 
            this.commentsEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsEditBox.Location = new System.Drawing.Point(91, 59);
            this.commentsEditBox.Name = "commentsEditBox";
            this.commentsEditBox.Size = new System.Drawing.Size(174, 124);
            this.commentsEditBox.TabIndex = 24;
            this.commentsEditBox.Text = "";
            this.commentsEditBox.WordWrap = false;
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(26, 59);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(59, 13);
            this.commentsLabel.TabIndex = 23;
            this.commentsLabel.Text = "Comments:";
            // 
            // fractionSign
            // 
            this.fractionSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fractionSign.AutoSize = true;
            this.fractionSign.Location = new System.Drawing.Point(152, 28);
            this.fractionSign.Name = "fractionSign";
            this.fractionSign.Size = new System.Drawing.Size(12, 13);
            this.fractionSign.TabIndex = 25;
            this.fractionSign.Text = "/";
            // 
            // componentMarkLabel
            // 
            this.componentMarkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.componentMarkLabel.AutoSize = true;
            this.componentMarkLabel.Location = new System.Drawing.Point(163, 28);
            this.componentMarkLabel.Name = "componentMarkLabel";
            this.componentMarkLabel.Size = new System.Drawing.Size(25, 13);
            this.componentMarkLabel.TabIndex = 26;
            this.componentMarkLabel.Text = "100";
            // 
            // EditStudentMarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(296, 241);
            this.Controls.Add(this.componentMarkLabel);
            this.Controls.Add(this.fractionSign);
            this.Controls.Add(this.commentsEditBox);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.givenMarkNumeric);
            this.Controls.Add(this.givenMarkLabel);
            this.MinimumSize = new System.Drawing.Size(312, 280);
            this.Name = "EditStudentMarkForm";
            this.Text = "Edit Mark";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.givenMarkLabel, 0);
            this.Controls.SetChildIndex(this.givenMarkNumeric, 0);
            this.Controls.SetChildIndex(this.commentsLabel, 0);
            this.Controls.SetChildIndex(this.commentsEditBox, 0);
            this.Controls.SetChildIndex(this.fractionSign, 0);
            this.Controls.SetChildIndex(this.componentMarkLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.givenMarkNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown givenMarkNumeric;
        private System.Windows.Forms.Label givenMarkLabel;
        private System.Windows.Forms.RichTextBox commentsEditBox;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.Label fractionSign;
        private System.Windows.Forms.Label componentMarkLabel;
    }
}

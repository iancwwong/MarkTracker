namespace MarkTracker.include.forms {
    partial class EditComponentForm {
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
            this.commentsEditBox = new System.Windows.Forms.RichTextBox();
            this.totalMarkNumeric = new System.Windows.Forms.NumericUpDown();
            this.totalMarksLabel = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.nameEditBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(76, 201);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(157, 201);
            // 
            // commentsEditBox
            // 
            this.commentsEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsEditBox.Location = new System.Drawing.Point(114, 82);
            this.commentsEditBox.Name = "commentsEditBox";
            this.commentsEditBox.Size = new System.Drawing.Size(166, 102);
            this.commentsEditBox.TabIndex = 28;
            this.commentsEditBox.Text = "";
            this.commentsEditBox.WordWrap = false;
            // 
            // totalMarkNumeric
            // 
            this.totalMarkNumeric.Location = new System.Drawing.Point(114, 56);
            this.totalMarkNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.totalMarkNumeric.Name = "totalMarkNumeric";
            this.totalMarkNumeric.Size = new System.Drawing.Size(55, 20);
            this.totalMarkNumeric.TabIndex = 27;
            this.totalMarkNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalMarkNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // totalMarksLabel
            // 
            this.totalMarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalMarksLabel.AutoSize = true;
            this.totalMarksLabel.Location = new System.Drawing.Point(33, 59);
            this.totalMarksLabel.Name = "totalMarksLabel";
            this.totalMarksLabel.Size = new System.Drawing.Size(66, 13);
            this.totalMarksLabel.TabIndex = 26;
            this.totalMarksLabel.Text = "Total Marks:";
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(33, 82);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(59, 13);
            this.commentsLabel.TabIndex = 25;
            this.commentsLabel.Text = "Comments:";
            // 
            // nameEditBox
            // 
            this.nameEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameEditBox.Location = new System.Drawing.Point(114, 30);
            this.nameEditBox.Name = "nameEditBox";
            this.nameEditBox.Size = new System.Drawing.Size(166, 20);
            this.nameEditBox.TabIndex = 24;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(33, 33);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 23;
            this.nameLabel.Text = "Name:";
            // 
            // EditComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(307, 249);
            this.Controls.Add(this.commentsEditBox);
            this.Controls.Add(this.totalMarkNumeric);
            this.Controls.Add(this.totalMarksLabel);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.nameEditBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "EditComponentForm";
            this.Text = "Edit Component";
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.nameLabel, 0);
            this.Controls.SetChildIndex(this.nameEditBox, 0);
            this.Controls.SetChildIndex(this.commentsLabel, 0);
            this.Controls.SetChildIndex(this.totalMarksLabel, 0);
            this.Controls.SetChildIndex(this.totalMarkNumeric, 0);
            this.Controls.SetChildIndex(this.commentsEditBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.totalMarkNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox commentsEditBox;
        private System.Windows.Forms.NumericUpDown totalMarkNumeric;
        private System.Windows.Forms.Label totalMarksLabel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox nameEditBox;
        private System.Windows.Forms.Label nameLabel;
    }
}

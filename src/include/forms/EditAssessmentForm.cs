using MarkTracker.include.entities;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkTracker.include.forms {
    public partial class EditAssessmentForm : MarkTracker.include.forms.EditForm {

        /* Assessment object */
        private Assessment assessment;

        /* Constructor */
        public EditAssessmentForm(Assessment a) {
            InitializeComponent();
            this.assessment = a;

            /* TODO: Populate the UI components with assessment object */
        }

        /**
         * Save the edited info to database
         */
        private void saveButton_Click(object sender, EventArgs e) {

            /* Obtain info from UI components */
            string newAssName = this.nameEditBox.Text;
            string newAssDateTimeStr = this.dueDatePicker.Text 
                                        + " " + this.dueTimePicker.Text;
            DateTime newAssDueDateTime = Convert.ToDateTime(newAssDateTimeStr);
            int newAssMarks = Convert.ToInt32(this.totalMarkNumeric.Value);
            int newAssWeighting = Convert.ToInt32(this.weightingNumeric.Value);
            string newAssComments = this.commentsEditBox.Text;

            /* Save to database */
            Debug.WriteLine("Saving entered information...");
            Debug.WriteLine("New name: " + newAssName);
            Debug.WriteLine("New Date: " + newAssDueDateTime);
            Debug.WriteLine("New total mark: " + newAssMarks);
            Debug.WriteLine("New weighting: " + newAssWeighting);
            Debug.WriteLine("New comments: " + newAssComments);
        }
    }
}

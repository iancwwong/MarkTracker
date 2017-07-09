using MarkTracker.include.entities;
using System;
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
    }
}

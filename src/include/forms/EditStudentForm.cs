using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkTracker.include.forms {
    public partial class EditStudentForm : MarkTracker.include.forms.EditForm {

        /* Student attribute */
        Student student { get; set; }

        /* Constructor */
        public EditStudentForm(Student s) {
            InitializeComponent();

            this.student = s;
            /* TODO: Populate UI components with student info */
        }
    }
}

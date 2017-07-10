using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkTracker.include.forms {
    public partial class EditStudentMarkForm : MarkTracker.include.forms.EditForm {

        /* Student Mark Info attribute */
        private StudentMarkInfo studentMarkInfo { get; set; }

        /* Constructor */
        public EditStudentMarkForm(StudentMarkInfo smi) {
            InitializeComponent();
            this.studentMarkInfo = smi;

            /* TODO: Populate UI with data */
        }
    }
}

using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkTracker.include.forms {
    public partial class EditCourseForm : MarkTracker.include.forms.EditForm {

        /* Course attribute */
        private Course course { get; set; }

        /**
         * Constructor
         * TODO: Need to pass in database layer
         */
        public EditCourseForm(Course c) : base() {
            InitializeComponent();
            this.course = c;
        }

    }
}

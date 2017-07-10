using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkTracker.include.forms {
    public partial class EditComponentForm : MarkTracker.include.forms.EditForm {

        /* Component attribute */
        private AssessmentComponent component;

        /* Constructor */
        public EditComponentForm(AssessmentComponent c) {
            InitializeComponent();
            this.component = c;

            /* TODO: Populate UI components with c attributes */
        }
    }
}

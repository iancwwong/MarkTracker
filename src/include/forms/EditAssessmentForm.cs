using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker.include.forms {
    public partial class EditAssessmentForm : Form {

        public Assessment assessment { get; set; }

        public EditAssessmentForm(Assessment ass) {
            InitializeComponent();
            this.assessment = ass;
        }
    }
}

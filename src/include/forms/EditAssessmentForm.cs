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
        
        /**
         * Constructor. Given an "Assessmment" and "Database"
         * from first form
         */
        public EditAssessmentForm(Assessment ass) {
            InitializeComponent();
            this.assessment = ass;
            this.initialiseUIComponents();
        }

        /* Initialises the UI components */
        private void initialiseUIComponents() {
            /* TODO: Take assessment properties,
             * populate UI with the original data
             */
        }

        /**
         * Close the form
         */
        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

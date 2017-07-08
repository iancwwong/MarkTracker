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
    public partial class EditForm : Form {

        /* Data layer communication attribute */
        // private DataLayer db = null;

        public EditForm() {
            InitializeComponent();
        }

        /**
         * Close the edit form
         */
        protected void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

﻿using MarkTracker.include.entities;
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
        private entities.Component component;

        /* Constructor */
        public EditComponentForm(entities.Component c) {
            InitializeComponent();
            this.component = c;

            /* TODO: Populate UI components with c attributes */
        }
    }
}

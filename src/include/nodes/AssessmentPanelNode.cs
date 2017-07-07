using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker.include.nodes {
    class AssessmentPanelNode : TreeNode {

        public enum apNodeType { Course, Assessment, Component };   /* possible types of assessment panel nodes */

        /* These two work together in order to obtain the reference from the data source */
        public apNodeType type { get; set; }
        public uint id { get; set; }             
        

        public AssessmentPanelNode(apNodeType apType, string name, ContextMenuStrip cms) : base(name) {
            this.type = apType;
            this.ContextMenuStrip = cms;
        }
    }
}

using MarkTracker.include.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkTracker.include.nodes {
    class UITreeViewNode : TreeNode {

        /* These two work together in order to obtain the reference from the data source */
        public EntityConstants.EntityType type { get; set; }
        public int id { get; set; }

        /* Parent node */
        public UITreeViewNode parentNode { get; set; }
        
        /* Constructor */
        public UITreeViewNode(EntityConstants.EntityType eType, string name, UITreeViewNode parent, ContextMenuStrip cms) : base(name) {
            this.type = eType;
            this.parentNode = parent;
            this.ContextMenuStrip = cms;
        }

        /* Obtain the reference of the absolute root node */
        public UITreeViewNode getRootNode() {
            UITreeViewNode curNode = this;
            while (curNode.parentNode != null) {
                curNode = curNode.parentNode;
            }
            return curNode;
        }
    }
}

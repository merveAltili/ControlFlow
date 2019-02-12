using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlWorkFlowApp
{
    public partial class Page
    {
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.DeleteNode();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                this.SelectAllNodes();
            }
        }

        private void DeleteNode()
        {
            foreach (var selectedNode in this.SelectedNodes)
            {
                if (selectedNode == this.currentNode)
                {
                    this.currentNode = null;
                }
                this.RemoveNode(selectedNode);
            }
            this.SelectedNodes.Clear();
            this.Canvas.Invalidate();
        }

        private void SelectAllNodes()
        {
            this.SelectedNodes.Clear();
            foreach (var node in this.Nodes)
            {
                this.SelectedNodes.Add(node);
            }
            this.Canvas.Invalidate();
        }
    }
}

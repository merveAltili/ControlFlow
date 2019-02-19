using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlWorkFlowApp
{
    public sealed class GhostTextBoxColumn : DataGridViewTextBoxColumn
    {
        public override bool ReadOnly
        {
            get => base.ReadOnly;
            set
            {
                if (!value) this.HeaderCell.Style.ForeColor = System.Drawing.Color.Blue;
                base.ReadOnly = value;
            }
        }

        public GhostTextBoxColumn()
        {
            this.CellTemplate = new GhostTextBoxCell();
            this.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}

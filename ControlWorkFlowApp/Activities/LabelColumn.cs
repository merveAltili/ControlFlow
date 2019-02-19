using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlWorkFlowApp
{
    public sealed class LabelColumn : DataGridViewTextBoxColumn
    {
        public override bool ReadOnly => true;

        public LabelColumn()
        {
            this.CellTemplate = new LabelCell();
            this.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}

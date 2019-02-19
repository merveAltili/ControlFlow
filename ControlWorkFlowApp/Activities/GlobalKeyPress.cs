using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlFlow.Activities.Apps
{
    public sealed class GlobalKeyPress : ProcessNodeActivity
    {
        public Input<ElementQuery> Element { get; set; }

        public Input<Text> Text { get; set; }

        public override void Execute(ActivityContext context)
        {
            var e = context.GetElement(this.Element);

            var text = context.Get(this.Text, string.Empty);

            e.Focus();

            SendKeys.SendWait(text);
        }
    }
}

using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Apps
{
    public sealed class GlobalMouseClick : ProcessNodeActivity
    {
        public Input<ElementQuery> Element { get; set; }

        public override void Execute(ActivityContext context)
        {
            var e = context.GetElement(this.Element);

            using (var input = new InputDriver())
            {
                e.Focus();
                var p = e.Bounds.Center;
                input.MouseMove(p.X, p.Y);
                input.Click(MouseButton.Left);
            }
        }
    }
}

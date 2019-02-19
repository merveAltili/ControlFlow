using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Apps
{
    public sealed class ElementValueGet : ProcessNodeActivity
    {
        public Input<ElementQuery> Element { get; set; }

        public Output<Text> Value { get; set; }

        public override void Execute(ActivityContext context)
        {
            var e = context.GetElement(this.Element);

            e.Focus();

            context.Set(this.Value, e.Value);

        }
    }
}

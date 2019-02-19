using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Apps
{
    public sealed class ElementValueSet : ProcessNodeActivity
    {
        public Input<ElementQuery> Element { get; set; }

        public Input<Text> Value { get; set; }

        public override void Execute(ActivityContext context)
        {
            var value = context.Get(this.Value, string.Empty);

            var e = context.GetElement(this.Element);

            e.Focus();

            e.Value = value;
        }
    }
}

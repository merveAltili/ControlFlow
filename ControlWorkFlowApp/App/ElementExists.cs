using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Apps
{
    public sealed class ElementExists : DecisionNodeActivity
    {
        public Input<ElementQuery> Element { get; set; }

        public override bool Execute(ActivityContext context)
        {
            return context.CountElements(this.Element) == 1;
        }
    }
}

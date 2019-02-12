using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkFlowApp
{
    public abstract class DecisionNodeActivity : Activity
    {
        public abstract bool Execute(ActivityContext context);
    }
}

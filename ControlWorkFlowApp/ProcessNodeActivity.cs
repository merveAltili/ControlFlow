using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkFlowApp
{
    public abstract class ProcessNodeActivity : Activity
    {
        public abstract void Execute(ActivityContext context);
    }
}



namespace ControlWorkFlowApp
{
    public abstract class ProcessNodeActivity : Activity
    {
        public abstract void Execute(ActivityContext context);
    }
}

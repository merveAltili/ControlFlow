using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Files
{
    public class FileExists : DecisionNodeActivity
    {
        public Input<Text> FilePath { get; set; }

        public override bool Execute(ActivityContext context)
        {
            var filePath = context.Get(this.FilePath);
            return File.Exists(filePath);
        }
    }
}

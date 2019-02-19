using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Files
{
    public class FileCopy : ProcessNodeActivity
    {
        public Input<Text> FromFilePath { get; set; }

        public Input<Text> ToFilePath { get; set; }

        public override void Execute(ActivityContext context)
        {
            var fromFilePath = context.Get(this.FromFilePath);

            var toFilePath = context.Get(this.ToFilePath);

            File.Copy(fromFilePath, toFilePath, true);
        }
    }
}

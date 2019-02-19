using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Files
{
    public class FileWriteText : ProcessNodeActivity
    {
        public Input<Text> FilePath { get; set; }

        public Input<Text> Text { get; set; }

        public override void Execute(ActivityContext context)
        {
            var filePath = context.Get(this.FilePath);
            var text = context.Get(this.Text);

            File.WriteAllText(filePath, text);
        }
    }
}

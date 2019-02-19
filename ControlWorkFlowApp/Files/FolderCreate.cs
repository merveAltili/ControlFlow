using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Files
{
    public class FolderCreate : ProcessNodeActivity
    {
        public Input<Text> FolderPath { get; set; }

        public override void Execute(ActivityContext context)
        {
            var folderPath = context.Get(this.FolderPath);
            Directory.CreateDirectory(folderPath);
        }
    }
}

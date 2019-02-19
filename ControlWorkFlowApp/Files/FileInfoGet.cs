﻿using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow.Activities.Files
{
    public class FileInfoGet : ProcessNodeActivity
    {
        public Input<Text> FilePath { get; set; }

        public Output<Text> FileName { get; set; }

        public Output<Text> FileExtension { get; set; }

        public Output<Number> FileSize { get; set; }

        public Output<ControlWorkFlowApp.DateTime> CreationTime { get; set; }

        public Output<ControlWorkFlowApp.DateTime> LastAccessTime { get; set; }

        public Output<ControlWorkFlowApp.DateTime> LastWriteTime { get; set; }

        public override void Execute(ActivityContext context)
        {
            var filePath = context.Get(this.FilePath);

            var fileInfo = new FileInfo(filePath);

            context.Set(this.FileName, fileInfo.Name);
            context.Set(this.FileExtension, fileInfo.Extension);
            context.Set(this.FileSize, fileInfo.Length);
            context.Set(this.CreationTime, fileInfo.CreationTime);
            context.Set(this.LastAccessTime, fileInfo.LastAccessTime);
            context.Set(this.LastWriteTime, fileInfo.LastWriteTime);
        }
    }
}
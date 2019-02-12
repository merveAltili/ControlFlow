using ControlWorkFlowApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.CreateWorkflow();
        }
        private const string FileDialogFilter = "Roro Workflow (*.xml)|*.xml";
        private void CreateWorkflow()
        {
            var form = new PageForm(string.Empty);
            form.OnBeforeSave += (ss, ee) =>
            {
                if (form.FileName == string.Empty)
                {
                    using (var file = new SaveFileDialog())
                    {
                        file.Filter = FileDialogFilter;
                        if (file.ShowDialog() == DialogResult.OK)
                        {
                            form.FileName = file.FileName;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                File.WriteAllText(form.FileName, form.FileContent);
            };
            form.Show();
        }
    }
}

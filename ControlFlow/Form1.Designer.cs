namespace ControlFlow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // createLinkLabel
            // 
            this.createLinkLabel.AutoSize = true;
            this.createLinkLabel.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.createLinkLabel.Location = new System.Drawing.Point(52, 43);
            this.createLinkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.createLinkLabel.Name = "createLinkLabel";
            this.createLinkLabel.Size = new System.Drawing.Size(99, 41);
            this.createLinkLabel.TabIndex = 1;
            this.createLinkLabel.TabStop = true;
            this.createLinkLabel.Text = "create";
            this.createLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateLinkLabel_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 232);
            this.Controls.Add(this.createLinkLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel createLinkLabel;
    }
}


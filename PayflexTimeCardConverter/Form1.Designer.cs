
namespace PayflexTimeCardConverter
{
    partial class frm_Main
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
            this.txt_Source = new System.Windows.Forms.TextBox();
            this.fbd_picker = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ofd_SourceFile = new System.Windows.Forms.OpenFileDialog();
            this.txt_SourceFile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.cmd_Convert = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Source
            // 
            this.txt_Source.Location = new System.Drawing.Point(5, 18);
            this.txt_Source.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Source.Name = "txt_Source";
            this.txt_Source.Size = new System.Drawing.Size(359, 20);
            this.txt_Source.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmd_Source_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Timeclock File";
            // 
            // txt_SourceFile
            // 
            this.txt_SourceFile.Location = new System.Drawing.Point(5, 56);
            this.txt_SourceFile.Name = "txt_SourceFile";
            this.txt_SourceFile.Size = new System.Drawing.Size(359, 20);
            this.txt_SourceFile.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Source);
            this.groupBox1.Controls.Add(this.txt_SourceFile);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 93);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_Status);
            this.groupBox2.Controls.Add(this.pb_Status);
            this.groupBox2.Controls.Add(this.cmd_Convert);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txt_Output);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 128);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Filder";
            // 
            // pb_Status
            // 
            this.pb_Status.Location = new System.Drawing.Point(113, 49);
            this.pb_Status.Margin = new System.Windows.Forms.Padding(2);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(305, 26);
            this.pb_Status.TabIndex = 15;
            // 
            // cmd_Convert
            // 
            this.cmd_Convert.Enabled = false;
            this.cmd_Convert.Location = new System.Drawing.Point(5, 49);
            this.cmd_Convert.Margin = new System.Windows.Forms.Padding(2);
            this.cmd_Convert.Name = "cmd_Convert";
            this.cmd_Convert.Size = new System.Drawing.Size(95, 26);
            this.cmd_Convert.TabIndex = 13;
            this.cmd_Convert.Text = "Convert";
            this.cmd_Convert.UseVisualStyleBackColor = true;
            this.cmd_Convert.Click += new System.EventHandler(this.cmd_Convert_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(377, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 20);
            this.button2.TabIndex = 12;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cmd_Output_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(5, 18);
            this.txt_Output.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(359, 20);
            this.txt_Output.TabIndex = 11;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(9, 87);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 13);
            this.lbl_Status.TabIndex = 16;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 252);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_Main";
            this.Text = "Payflex File Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Source;
        private System.Windows.Forms.FolderBrowserDialog fbd_picker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofd_SourceFile;
        private System.Windows.Forms.TextBox txt_SourceFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pb_Status;
        private System.Windows.Forms.Button cmd_Convert;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Label lbl_Status;
    }
}


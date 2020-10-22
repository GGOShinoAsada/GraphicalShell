using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicalShell.Resourses;

namespace GraphicalShell
{
    public partial class Form5 : Form
    {
        public string FilePath { get; set; }
        public bool IsInputToFile { get; set; }
        public bool IsChangePath { get; set; }
        public Form5(Settings settings)
        {
            FilePath = settings.FilePath;
            IsInputToFile = settings.IsInputToFile;
            InitializeComponent();
        }
        private void btn_savechanges(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Text += FilePath;
            if (!IsInputToFile)
                radioButton2.Checked = true;
            else
                radioButton1.Checked = true;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            IsInputToFile = true;
            groupBox1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            IsInputToFile = false;
            FilePath = "";
            
            groupBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files (*.txt)|*.txt|all files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;
                IsChangePath = true;
                label2.Text = "This path is " + FilePath;
            }

        }

    
    }
}

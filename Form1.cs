using System;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using GraphicalShell.Interface;
using GraphicalShell.Resourses;

namespace GraphicalShell
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }
        static Settings Settings = new Settings();
        private static void start()
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //arglvl0.Items.Clear();
            label2.Visible = (param.SelectedIndex >= 0) ? true : false;
            btnGetQuery.Visible = (param.SelectedIndex >= 0) ? true : false;
            //arglvl0.Visible = GraphInterface.SetVisible(arglvl0, param.SelectedIndex);
            //arglvl0.Items.AddRange(GraphInterface.GetArgumentsLvl0(param.SelectedIndex).Cast<object>().ToArray());


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textQuery.Visible = (checkBox1.Checked) ? true : false;

        }

        private void arglvl0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            param.SelectedIndex = -1;
            //arglvl0.Items.Clear();
            //arglvl0.Visible = false;
            //listQueryOutput.Items.Clear();
            textQuery.Text = "";
            label2.Visible = false;
            checkBox1.Checked = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Width = 350;
            size.Height = 310;
            this.MaximizeBox = false;
            #region Settings
            Settings.FilePath = "output.txt";
            Settings.IsInputToFile = false;
            #endregion
            this.Text = "Work With CMD";
            this.MinimumSize = size;
            this.Size = size;
            param.Items.AddRange(GraphInterface.GetParams().Cast<object>().ToArray());

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();

            about.ShowDialog();
        }

        private void btnGetQuery_Click(object sender, EventArgs e)
        {
            if (param.SelectedIndex < 0)
            {
                MessageBox.Show("Please select parametr", "ERROR", MessageBoxButtons.OK);
                return;
            }
            Form2 form = new Form2(param.SelectedIndex,1, Settings);
            form.ShowDialog();
            textQuery.Text = form.arguments;



        }
        public delegate void InvokeDelegate();
        private async void BtnExecute_Click(object sender, EventArgs e)
        {
            await Task.Delay(100).ConfigureAwait(false);
            string t1="", t2="";
            object state = new object();
         
          
           
             param.Invoke((MethodInvoker) delegate
             {
                 t1 = GetParameter();
             });
            textQuery.Invoke((MethodInvoker)delegate
            {
                t2 = GetArguments();
            });
            #region Parse string arguments

       
            #endregion
            //Set TimeOut
            WorkWithCMD.TimeOut = 10;
           
            Task<string> task = Task.Factory.StartNew(() => WorkWithCMD.ExecuteCommandCMD(t1, t2));
            Task<string> task1 = Task.Factory.StartNew(() => WorkWithCMD.ExecuteCommandCMD(t1, t2));

           
            Task.WaitAll(task);
         
            bool b = ((task.Result == null) ) ? true : false;
            if (!b)
            {
               
                GetOutput(task.Result);
            }
            else
            {
                GetOutput("ERROR");
            }
           

        }

   

        string GetParameter()
        {
            try
            {
                return param.SelectedItem.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        string GetArguments()
        {
            string data = textQuery.Text;
             if (Settings.IsInputToFile)
             {

             }
            return textQuery.Text;
        }
        void GetOutput(string message)
        {
            if (!Settings.IsInputToFile)
            {
                Form3 form3 = new Form3();
                form3.richTextBox1.Text = message;

                form3.ShowDialog();
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(Settings.FilePath))
                    {
                        sw.WriteLine(message);
                    }
                    MessageBox.Show("Done");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void UseMethodsInThread()
        {
            param.SelectedItem.ToString();
        }
       
  
        private void openBATFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = WorkWithCMD.OpenFile();
            if (path != "")
            {
                Task<string> task = Task.Run(() => WorkWithCMD.GetStartAsync(path));
                task.Wait();
                Form3 form3 = new Form3();
                form3.richTextBox1.Text = task.Result;
                form3.ShowDialog();
            }
           

            //MessageBox.Show(task.Result);
         
            
           
           
            //string output = WorkWithCMD.GetStartAsync(path);

        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = 0;
            Form5 set = new Form5(Settings);
         

            set.ShowDialog();
            Settings settings = new Settings();
            settings.FilePath = set.FilePath;
            settings.IsInputToFile = set.IsInputToFile;

            Settings = new Settings();
            Settings = settings;
         
           
          
        }
    }
}

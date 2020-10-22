using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicalShell.Interface;
using System.Threading;
using GraphicalShell.Resourses;

namespace GraphicalShell
{
    public partial class Form2 : Form
    {
        //private static object myobject = new object();
        private List<string> args = new List<string>();
        private List<string> selectedars = new List<string>();
        private List<Element<string>> resourses = new List<Element<string>>();
        private Settings Settings = new Settings();
        public string arguments = "";
        private static int parametr { get; set; }
        private static int count;
        private static bool differentarguments { get; set; } = false;
        public Form2(int parm, int countags, Settings settings, bool differentargs=false)
        {
            parametr = parm;
            count = countags;
            differentarguments = differentargs;
            Settings = settings;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //parameter {0,1,2} count 1
            InicializeArgsElems(count, differentarguments);
            resourses = GraphInterface.LoadResourses(parametr+1);
            label1.Text += $" {GraphInterface.GetParametr(parametr+1)}";
            args = GraphInterface.LoadAruments(parametr+1).Cast<string>().ToList();
            ArgsLvl0.Items.AddRange(GraphInterface.GetArgumentsLvl0(parametr+1).Cast<string>().ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            arguments = "";
            int cout = 0;
            bool flag = true;
            bool err = false;
            foreach (string arg in args)
            {
                if (flag)
                {
                    foreach (string selectedarg in selectedars)
                    {
                        count++;
                        if (string.Equals(arg, selectedarg, StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                Element<string> element = resourses.Find(x => x.Description == $"{arg}");
                                if (element.Visible)
                                {
                                    Form4 form = new Form4(element);

                                    form.ShowDialog();
                                    if (form.Argument != "")
                                    {
                                        arguments += arg + " " + form.textBox1.Text + " ";

                                        //MessageBox.Show(form.textBox1.Text);
                                    }
                                    else
                                    {
                                        err = true;
                                    }
                                }
                                //else if (element.IsFinalVaue)
                                //{
                                   
                                //}
                                else
                                {
                                    arguments += arg + " ";
                                }

                                break;
                            }
                            catch (ArgumentNullException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        if (count == selectedars.Count)
                            flag = false;
                    }
                }
               
            }
            if (resourses.Last().IsFinalVaue)
            {
                Form4 form = new Form4(resourses.Last());
                form.ShowDialog();
                if (form.Argument != "")
                {
                    arguments += " " + form.Argument;
                }
                else
                {
                    err = true;
                }
            }
            if (Settings.IsInputToFile)
            {
                arguments += $" > \"{Settings.FilePath}\"";
            }
           
            if (err)
                arguments = "";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arguments = "";
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SetVisibleCommand(true);
            }
            else
            {
                SetVisibleCommand(false);
            }
        }
        private void SetVisibleCommand(bool arg)
        {
            label2.Visible = arg;
            textBox1.Visible = arg;
        }
        private void InicializeArgsElems(int arg, bool diff)
        {
           
                switch (arg)
                {
                    case 1:
                        Visible(true, false, false, diff);

                        break;
                    case 2:
                        Visible(true, true, false, diff);

                        break;
                    case 3:
                        Visible(true, true, true, diff);
                        break;
                }
          
         
          
            void Visible(bool p1, bool p2, bool p3, bool d)
            {

                if (d)
                {
                    radioButton1.Visible = p1;
                    Inicialize();
                    radioButton2.Visible = p2;
                    radioButton3.Visible = p3;
                }
                ArgsLvl0.Visible = p1;
                ArgsLvl1.Visible = p2;
                ArgsLvl2.Visible = p3;
            }
            void Inicialize()
            {
                ArgsLvl0.Enabled = true;
                ArgsLvl1.Enabled = false;
                ArgsLvl2.Enabled = false;
                radioButton1.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledArgumetsInLvl0(true);
          
        }
        void SetEnabledArgumetsInLvl0(bool p)
        {
            ArgsLvl0.Enabled = p;
            ArgsLvl1.Enabled = !p;
            ArgsLvl2.Enabled = !p;
        }
        void SetEnabledArgumentsInLvl1(bool p)
        {
            ArgsLvl0.Enabled = !p;
            ArgsLvl1.Enabled = p;
            ArgsLvl2.Enabled = !p;
        }
        void SetEnabledArgumensIntLvl2(bool p)
        {
            ArgsLvl0.Enabled = !p;
            ArgsLvl1.Enabled = !p;
            ArgsLvl2.Enabled = p;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledArgumentsInLvl1(true);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledArgumensIntLvl2(true);
        }

        private void ArgsLvl0_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            selectedars = new List<string>();
            List<int> data = new List<int>();
            Task task = Task.Run(() => InicializeAsync());

            task.Wait();




            textBox1.Text = DrawAsync(selectedars).Result;

            // textBox1.Text = await Task.Factory.StartNew(() => draw(selectedars).Result, TaskCreationOptions.AttachedToParent);


            async Task InicializeAsync()
            {
                await Task.Delay(100).ConfigureAwait(false);
                foreach (string i in ArgsLvl0.CheckedItems.Cast<string>().ToList())
                {
                    int index = ArgsLvl0.Items.IndexOf(i);
                    data.Add(index);

                }
                data.ForEach(l => selectedars.Add(args.ElementAt(l)));



            }

        }

        private async Task<string> DrawAsync(IList selectedarg)
        {
            await Task.Delay(100).ConfigureAwait(false);
            string data = await Task.Run(() => Draw(selectedars));

            return data;

        }
        string Draw(IList selectedarg)
        {
            string data = "";
            foreach (string t in selectedars)
            {
                data += " " + t;
            }
            return data;
        }
        private void msgprint(CheckedListBox d)
        {
            string output = "";
            foreach (string s in d.CheckedItems.Cast<string>().ToList())
            {
                output += s + " ";
            }
            MessageBox.Show(output,"COUNT: "+ d.CheckedItems.Cast<string>().ToList().Count.ToString());
        }
        private void ArgsLvl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

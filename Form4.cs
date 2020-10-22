using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicalShell.Interface;
using GraphicalShell.Resourses;


namespace GraphicalShell
{
    public partial class Form4 : Form
    {
        private Element<string> Element { get; set; }
        public string Argument { get; set;  }

        public Form4(Element<string> arg)
        {
            Element = arg;
            InitializeComponent();
        }
     
        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text += !Element.IsFinalVaue ? " " + Element.Description : Element.Description + Element.Parent;
            //label1.Text += " " + Element.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Argument = "";
            if (Element.Visible)
            {
                var tmp = Element;
                tmp.Value = textBox1.Text;
               if  (GraphInterface.Validate(tmp))
               {
                    Argument += textBox1.Text;
                   
                    this.Close();
               }
              
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Please try again", "Input Error", MessageBoxButtons.OK);
                   
                }
            }
            else
            {
                this.Close();
            }

        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}

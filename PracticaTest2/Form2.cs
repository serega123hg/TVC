using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaTest2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            tbPost.Text = Properties.Settings.Default.email;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.email = tbPost.Text;
            Properties.Settings.Default.Save();
        }
    }
}

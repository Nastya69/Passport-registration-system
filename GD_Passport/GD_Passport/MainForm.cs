using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Passport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#798d9c");
            Addbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            Editbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            Deletebutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            Printbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            Searchbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            Exitbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            textBox1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#9eb6c7");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm s = new AddForm();
            s.Show();
        }
    }
}

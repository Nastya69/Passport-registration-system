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
    public partial class СonfirmForm : Form
    {
        public СonfirmForm(bool color)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (color == true)
            {
                this.BackColor = ColorTranslator.FromHtml("#c0e2f9");
                button1.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                button2.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            }
            else
            {
                this.BackColor = ColorTranslator.FromHtml("#798d9c");
                button1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                button2.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

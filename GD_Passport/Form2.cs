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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PINtextBox.Text == "2305")
            {
                MainForm s = new MainForm(false);
                s.Show();
                this.Hide();
            }
            else
            {
                PINtextBox.Text = "";
                MessageBox.Show("Неправильный PIN-код");
            }
        }

        private void PINtextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == ColorTranslator.FromHtml("#9eb6c7"))
            {
                this.BackColor = ColorTranslator.FromHtml("#798d9c");
                AddFotobutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Savebutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Cancelbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox2.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox3.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox4.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox5.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox6.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox8.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox9.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBox10.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                dateTimePicker1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                dateTimePicker2.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBox1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBox2.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBox3.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                button7.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            }
            else
            {
                this.BackColor = ColorTranslator.FromHtml("#c0e2f9");
                AddFotobutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Savebutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Cancelbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox1.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox2.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox3.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox4.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox5.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox6.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox7.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox8.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox9.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBox10.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                dateTimePicker1.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                dateTimePicker2.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBox1.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBox2.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBox3.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

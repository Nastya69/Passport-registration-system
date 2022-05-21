using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            button1.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            button7.Visible = true;
            button1.Visible = false;
            loadData("");
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
            button1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            textBoxSearch.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#9eb6c7");
            button7.Visible = false;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#c0e2f9");
            Addbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            Editbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            Deletebutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            Printbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            Searchbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            Exitbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            button7.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            textBoxSearch.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#f0f0f0");
            button1.Visible = false;
            button7.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm s = new AddForm();
            s.Show();
        }

        private void loadData(string keyword)
        {
            DBConnection.sql = "SELECT * FROM passport_select('" + keyword + "%')";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            DataTable dt = DBConnection.getDataTable(DBConnection.cmd);

            dataGridView1.MultiSelect = true;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Пол";
            dataGridView1.Columns[5].HeaderText = "Дата рождения";
            dataGridView1.Columns[6].HeaderText = "Фото";
            dataGridView1.Columns[7].HeaderText = "Серия";
            dataGridView1.Columns[8].HeaderText = "Номер";
            dataGridView1.Columns[9].HeaderText = "Кем выдан";
            dataGridView1.Columns[10].HeaderText = "Страна рождения";
            dataGridView1.Columns[11].HeaderText = "Город рождения";
            dataGridView1.Columns[12].HeaderText = "Адрес прописки";
            dataGridView1.Columns[13].HeaderText = "Адрес проживания";
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                System.IO.MemoryStream myMemStream = new System.IO.MemoryStream((byte[])dataGridView1[6, dataGridViewRow.Index].Value);
                System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
                System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                System.IO.MemoryStream myResult = new System.IO.MemoryStream();
                newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);
                dataGridView1[6, dataGridViewRow.Index].Value = myResult.ToArray();
            }

        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            loadData(textBoxSearch.Text.Trim());
        }
    }
}

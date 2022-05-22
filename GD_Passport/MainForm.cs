using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Passport
{
    public partial class MainForm : Form
    {
        private string result = "";
        public MainForm(bool user)
        {
            InitializeComponent();
            button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            //loadData("");
            if (user == true)
            {
                Addbutton.Enabled = false;
                Editbutton.Enabled = false;
                Deletebutton.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            СonfirmForm s = new СonfirmForm();
            s.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == ColorTranslator.FromHtml("#9eb6c7"))
            {
                this.BackColor = ColorTranslator.FromHtml("#798d9c");
                Addbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Editbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Deletebutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Printbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Searchbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Exitbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxSearch.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#9eb6c7");
                button7.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            }
            else
            {
                this.BackColor = ColorTranslator.FromHtml("#c0e2f9");
                Addbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Editbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Deletebutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Printbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Searchbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Exitbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxSearch.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#f0f0f0");
                button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            }
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
        
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(result, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void Printbutton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                result += dataGridView1[1, dataGridViewRow.Index].Value.ToString()+"\t";
                result += dataGridView1[2, dataGridViewRow.Index].Value.ToString() + "\t";
                result += dataGridView1[3, dataGridViewRow.Index].Value.ToString() + "\n";
                result += dataGridView1[4, dataGridViewRow.Index].Value.ToString() + "  ";
                result += dataGridView1[5, dataGridViewRow.Index].Value.ToString() + "  ";
                result += dataGridView1[11, dataGridViewRow.Index].Value.ToString() + "\n\n";
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

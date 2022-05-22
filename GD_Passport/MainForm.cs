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
        public bool whites = true;
        //столбцы таблицы
        int passportID;
        string sur;
        string name;
        string patr;
        string sex;
        DateTime dateBirth;
        Bitmap image;
        Dictionary<int, Bitmap> images;
        bool isImage;
        int series;
        int num;
        string dep;
        string country;
        string city;
        string adr1;
        string adr2;
        DateTime dateExtr;
        int personId;
        //для поиска
        bool isAged = false;
        public MainForm(bool user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            //loadData("","");
            if (user == true)
            {
                Addbutton.Enabled = false;
                Editbutton.Enabled = false;
                Deletebutton.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            СonfirmForm s = new СonfirmForm(whites);
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
                textBoxSearch.BackColor = ColorTranslator.FromHtml("#ccdbe5");
                dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#9eb6c7");
                checkBoxAged.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxAdr2.BackColor = ColorTranslator.FromHtml("#ccdbe5");
                button7.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                whites = false;
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
                textBoxSearch.BackColor = ColorTranslator.FromHtml("#ffffff");
                dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#f0f0f0");
                checkBoxAged.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxAdr2.BackColor = ColorTranslator.FromHtml("#ffffff");
                button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                whites = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm s = new AddForm();
            s.Show();
        }

        private void loadData(string keywordSur, string keywordAdr)
        {
            if (isAged)
            {
                DBConnection.sql = "SELECT * FROM passport_aged_select('" + keywordSur + "%', '" + keywordAdr + "%')";
            }
            else
            {
                DBConnection.sql = "SELECT * FROM passport_select('" + keywordSur + "%', '" + keywordAdr + "%')";
            }

            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            DataTable dt = DBConnection.getDataTable(DBConnection.cmd);

            dataGridView1.MultiSelect = true;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
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
            dataGridView1.Columns[14].HeaderText = "Дата получения";

            labelRows.Text = dataGridView1.RowCount + " строк";

            images = new Dictionary<int, Bitmap>();
            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                if (dataGridViewRow.Index != -1)
                {
                    System.IO.MemoryStream myMemStream = new System.IO.MemoryStream((byte[])dataGridView1[6, dataGridViewRow.Index].Value);
                    images[Int32.Parse(dataGridView1[0, dataGridViewRow.Index].Value.ToString())] = new Bitmap(myMemStream);
                    System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
                    System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                    System.IO.MemoryStream myResult = new System.IO.MemoryStream();
                    newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);
                    dataGridView1[6, dataGridViewRow.Index].Value = myResult.ToArray();
                    myMemStream.Close();
                    myResult.Close();
                }
            }

            if (dataGridView1.RowCount > 0)
            {
                passportID = Int32.Parse(dataGridView1[0, 0].Value.ToString());
                sur = dataGridView1[1, 0].Value.ToString();
                name = dataGridView1[2, 0].Value.ToString();
                patr = dataGridView1[3, 0].Value.ToString();
                sex = dataGridView1[4, 0].Value.ToString();
                dateBirth = Convert.ToDateTime(dataGridView1[5, 0].Value);
                image = images[passportID];
                isImage = true;
                series = Int32.Parse(dataGridView1[7, 0].Value.ToString());
                num = Int32.Parse(dataGridView1[8, 0].Value.ToString());
                dep = dataGridView1[9, 0].Value.ToString();
                country = dataGridView1[10, 0].Value.ToString();
                city = dataGridView1[11, 0].Value.ToString();
                adr1 = dataGridView1[12, 0].Value.ToString();
                adr2 = dataGridView1[13, 0].Value.ToString();
                dateExtr = Convert.ToDateTime(dataGridView1[14, 0].Value);

                DBConnection.con.Open();
                DBConnection.sql = "SELECT person_id FROM passport WHERE passport_id =" + passportID;
                DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                NpgsqlDataReader dataReader = DBConnection.cmd.ExecuteReader();
                int id = -1;
                if (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                }
                dataReader.Close();
                personId = id;
                DBConnection.con.Close();
            }
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            if (checkBoxAged.Checked)
            {
                isAged = true;
            }
            else
            {
                isAged = false;
            }
            loadData(textBoxSearch.Text.Trim(), textBoxAdr2.Text.Trim());
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                passportID = Int32.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
                sur = dataGridView1[1, e.RowIndex].Value.ToString();
                name = dataGridView1[2, e.RowIndex].Value.ToString();
                patr = dataGridView1[3, e.RowIndex].Value.ToString();
                sex = dataGridView1[4, e.RowIndex].Value.ToString();
                dateBirth = Convert.ToDateTime(dataGridView1[5, e.RowIndex].Value);
                image = images[passportID];
                isImage = true;
                series = Int32.Parse(dataGridView1[7, e.RowIndex].Value.ToString());
                num = Int32.Parse(dataGridView1[8, e.RowIndex].Value.ToString());
                dep = dataGridView1[9, e.RowIndex].Value.ToString();
                country = dataGridView1[10, e.RowIndex].Value.ToString();
                city = dataGridView1[11, e.RowIndex].Value.ToString();
                adr1 = dataGridView1[12, e.RowIndex].Value.ToString();
                adr2 = dataGridView1[13, e.RowIndex].Value.ToString();
                dateExtr = Convert.ToDateTime(dataGridView1[14, e.RowIndex].Value);

                DBConnection.con.Open();
                DBConnection.sql = "SELECT person_id FROM passport WHERE passport_id = " + passportID;
                DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                NpgsqlDataReader dataReader = DBConnection.cmd.ExecuteReader();
                int id = -1;
                if (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                }
                dataReader.Close();
                personId = id;
                DBConnection.con.Close();
            }
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            EditForm s = new EditForm(passportID, sur, name, patr, sex, dateBirth, image, isImage, series, num, dep, country, city, adr1, adr2, dateExtr, personId);
            s.ShowDialog();
            loadData("", "");
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удаление выполнено успешно!");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(Deletebutton, "Проверьте выбранные данные\nперед удалением");
            t.SetToolTip(button7 , "Сменить \nцвет фона");
            t.SetToolTip(checkBoxAged, "Граждане только\nпенсионного возраста");
            t.SetToolTip(Printbutton, "Печать таблицы\nпо заданному фильтру");
        }
    }
}

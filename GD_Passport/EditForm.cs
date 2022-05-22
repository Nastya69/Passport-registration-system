using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Passport
{
    public partial class EditForm : Form
    {
        Bitmap image;
        bool isImage;
        byte[] bytes;
        int id;
        string series;
        string num;
        int personId;

        public EditForm(int passportID, string sur, string name, string patr, string sex, DateTime dateBirth, Bitmap photo, bool isPhoto, int series, int num, string dep,
            string country, string city, string adr1, string adr2, DateTime dateExtr, int personId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");

            DBConnection.sql = "SELECT sex_title FROM sex";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            DataTable dt = DBConnection.getDataTable(DBConnection.cmd);
            comboBoxSex.DataSource = dt;
            comboBoxSex.DisplayMember = "Sex_title";
            comboBoxSex.SelectedIndex = -1;

            DBConnection.sql = "SELECT department_title FROM department";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            dt = DBConnection.getDataTable(DBConnection.cmd);
            comboBoxDep.DataSource = dt;
            comboBoxDep.DisplayMember = "department_title";
            comboBoxDep.SelectedIndex = -1;

            DBConnection.sql = "SELECT country_title FROM country";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            dt = DBConnection.getDataTable(DBConnection.cmd);
            comboBoxCountry.DataSource = dt;
            comboBoxCountry.DisplayMember = "country_title";
            comboBoxCountry.SelectedIndex = -1;

            DBConnection.sql = "SELECT city_title FROM city";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            dt = DBConnection.getDataTable(DBConnection.cmd);
            comboBoxCity.DataSource = dt;
            comboBoxCity.DisplayMember = "city_title";
            comboBoxCity.SelectedIndex = -1;

            comboBoxCity.Enabled = false;

            id = passportID;
            textBoxSurname.Text = sur;
            textBoxName.Text = name;
            textBoxPatr.Text = patr;
            dateTimePickerBirth.Value = dateBirth;
            textBoxSeries.Text = series.ToString();
            textBoxNum.Text = num.ToString();
            textBoxAdr1.Text = adr1;
            textBoxAdr2.Text = adr2;
            dateTimePickerExtr.Value = dateExtr;
            isImage = isPhoto;
            if (isImage)
            {
                image = new Bitmap(photo);
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    bytes = ms.ToArray();
                }
                /*ImageConverter converter = new ImageConverter();
                bytes = (byte[])converter.ConvertTo(image, typeof(byte[]));*/
                pictureBoxPhoto.Image = image;
            }


            this.series = series.ToString();
            this.num = num.ToString();
            this.personId = personId;

            DBConnection.con.Open();
            DBConnection.sql = "SELECT sex_id FROM sex WHERE sex_title LIKE '" + sex + "';";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            NpgsqlDataReader dataReader = DBConnection.cmd.ExecuteReader();
            int sexId = -1;
            if (dataReader.Read())
            {
                sexId = dataReader.GetInt32(0);
            }
            dataReader.Close();
            comboBoxSex.SelectedIndex = sexId - 1;

            DBConnection.sql = "SELECT department_id FROM department WHERE department_title LIKE '" + dep + "';";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            dataReader = DBConnection.cmd.ExecuteReader();
            int depId = -1;
            if (dataReader.Read())
            {
                depId = dataReader.GetInt32(0);
            }
            dataReader.Close();
            comboBoxDep.SelectedIndex = depId - 1;

            DBConnection.sql = "SELECT country_id FROM country WHERE country_title LIKE '" + country + "';";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            dataReader = DBConnection.cmd.ExecuteReader();
            int countryId = -1;
            if (dataReader.Read())
            {
                countryId = dataReader.GetInt32(0);
            }
            dataReader.Close();
            comboBoxCountry.SelectedIndex = countryId - 1;

            DBConnection.sql = "SELECT city_id FROM city WHERE city_title LIKE '" + city + "';";
            DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
            dataReader = DBConnection.cmd.ExecuteReader();
            int cityId = -1;
            if (dataReader.Read())
            {
                cityId = dataReader.GetInt32(0);
            }
            dataReader.Close();
            if (country == "ЛНР")
            {
                cityId -= 7;
            }
            if (country == "РОССИЯ")
            {
                cityId -= 12;
            }
            comboBoxCity.SelectedIndex = cityId - 1;

            DBConnection.con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == ColorTranslator.FromHtml("#9eb6c7"))
            {
                this.BackColor = ColorTranslator.FromHtml("#798d9c");
                buttonAdd.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                buttonDelete.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Savebutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                Cancelbutton.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxSurname.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxName.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxPatr.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxSeries.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxNum.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBoxDep.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxAdr1.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                textBoxAdr2.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                dateTimePickerBirth.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                dateTimePickerExtr.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBoxSex.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBoxCountry.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                comboBoxCity.BackColor = ColorTranslator.FromHtml("#9eb6c7");
                button7.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            }
            else
            {
                this.BackColor = ColorTranslator.FromHtml("#c0e2f9");
                buttonAdd.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                buttonDelete.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Savebutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                Cancelbutton.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxSurname.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxName.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxPatr.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxSeries.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxNum.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBoxDep.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxAdr1.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                textBoxAdr2.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                dateTimePickerBirth.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                dateTimePickerExtr.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBoxSex.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBoxCountry.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                comboBoxCity.BackColor = ColorTranslator.FromHtml("#f0f0f0");
                button7.BackColor = ColorTranslator.FromHtml("#9eb6c7");
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button7, "Сменить \nцвет фона");
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                string Symbol = e.KeyChar.ToString();

                if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                string Symbol = e.KeyChar.ToString();

                if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBoxPatr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                string Symbol = e.KeyChar.ToString();

                if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                char num = e.KeyChar;
                if (!Char.IsDigit(num) || textBoxSeries.Text.Length == 4)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
            {
                char num = e.KeyChar;
                if (!Char.IsDigit(num) || textBoxNum.Text.Length == 6)
                {
                    e.Handled = true;
                }
            }
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCountry.SelectedIndex != -1)
            {
                DBConnection.sql = "SELECT city_title FROM city WHERE country_id = " + (comboBoxCountry.SelectedIndex + 1);
                DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                DataTable dt = DBConnection.getDataTable(DBConnection.cmd);
                comboBoxCity.DataSource = dt;
                comboBoxCity.DisplayMember = "city_title";
                comboBoxCity.SelectedIndex = -1;
                comboBoxCity.Enabled = true;
            }
            else
            {
                comboBoxCity.Enabled = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(openDialog.FileName);
                    isImage = true;
                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, ImageFormat.Jpeg);
                        bytes = ms.ToArray();
                    }
                    /* ImageConverter converter = new ImageConverter();
                     bytes = (byte[])converter.ConvertTo(image, typeof(byte[]));*/
                    pictureBoxPhoto.Image = image;
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            image = null;
            isImage = false;
            pictureBoxPhoto.Image = Properties.Resources.No_Image;
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            bool isOk2 = true;
            string error = "";
            if (textBoxSurname.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "Поле 'фамилия' не может быть пустым.";
            }
            if (textBoxName.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "\nПоле 'фамилия' не может быть пустым.";
            }
            if (textBoxPatr.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "\nПоле 'отчество' не может быть пустым.";
            }
            if (comboBoxSex.SelectedIndex == -1)
            {
                isOk = false;
                isOk2 = false;
                error += "\nНе выбран пол";
            }
            if (textBoxSeries.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "\nПоле 'серия' не может быть пустым.";
            }
            if (textBoxNum.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "\nПоле 'номер' не может быть пустым.";
            }
            if (comboBoxDep.SelectedIndex == -1)
            {
                isOk = false;
                isOk2 = false;
                error += "\nНе выбрано поле 'Кем выдан'";
            }
            if (comboBoxCity.SelectedIndex == -1)
            {
                isOk = false;
                isOk2 = false;
                error += "\nНе выбран город";
            }
            if (comboBoxCountry.SelectedIndex == -1)
            {
                isOk = false;
                isOk2 = false;
                error += "\nНе выбрано государство";
            }
            if (textBoxAdr1.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "\nПоле 'адрес прописки' не может быть пустым.";
            }
            if (textBoxAdr2.Text == "")
            {
                isOk = false;
                isOk2 = false;
                error += "\nПоле 'адрес проживания' не может быть пустым.";
            }
            if (!isImage)
            {
                isOk = false;
                isOk2 = false;
                error += "\nНе загружена фотография.";
            }
            if (dateTimePickerBirth.Value > dateTimePickerExtr.Value)
            {
                isOk = false;
                isOk2 = false;
                error += "\nДата выдачи не может быть раньше даты рождения";
            }
            if (isOk2 && (textBoxSeries.Text != series || textBoxNum.Text != num))
            {
                DBConnection.con.Open();
                DBConnection.sql = "SELECT COUNT(*) FROM passport WHERE series = @series AND num = @num";
                DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                DBConnection.cmd.Parameters.AddWithValue("series", Int32.Parse(textBoxSeries.Text));
                DBConnection.cmd.Parameters.AddWithValue("num", Int32.Parse(textBoxNum.Text));
                NpgsqlDataReader dataReader = DBConnection.cmd.ExecuteReader();
                int count = 0;
                if (dataReader.Read())
                {
                    count = dataReader.GetInt32(0);
                }
                dataReader.Close();
                DBConnection.con.Close();
                if (count != 0)
                {
                    isOk = false;
                    error += "\nТакая комбинация 'серия+номер' уже существует.";

                }
            }
            if (isOk)
            {
                try
                {
                    DBConnection.con.Open();

                    DBConnection.sql = "UPDATE public.person SET surname=@surname, name=@name, patronym=@patronym, date_birth=@date_birth, sex_id=@sex_id, photo=@photo WHERE person_id = @person_id ";
                    DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                    DBConnection.cmd.Parameters.AddWithValue("surname", textBoxSurname.Text);
                    DBConnection.cmd.Parameters.AddWithValue("name", textBoxName.Text);
                    DBConnection.cmd.Parameters.AddWithValue("patronym", textBoxPatr.Text);
                    DBConnection.cmd.Parameters.AddWithValue("date_birth", NpgsqlTypes.NpgsqlDbType.Date, dateTimePickerBirth.Value);
                    DBConnection.cmd.Parameters.AddWithValue("sex_id", comboBoxSex.SelectedIndex + 1);
                    DBConnection.cmd.Parameters.AddWithValue("photo", NpgsqlTypes.NpgsqlDbType.Bytea, bytes);
                    DBConnection.cmd.Parameters.AddWithValue("person_id", personId);
                    DBConnection.cmd.ExecuteNonQuery();



                    DBConnection.sql = "UPDATE public.passport SET series=@series, num=@num, person_id=@person_id, department_id=@department_id, city_id=@city_id, " +
                        "address1=@address1, adress2=@adress2, date=@date WHERE passport_id = @passport_id";
                    DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                    DBConnection.cmd.Parameters.AddWithValue("series", Int32.Parse(textBoxSeries.Text));
                    DBConnection.cmd.Parameters.AddWithValue("num", Int32.Parse(textBoxNum.Text));
                    DBConnection.cmd.Parameters.AddWithValue("person_id", personId);
                    DBConnection.cmd.Parameters.AddWithValue("department_id", comboBoxDep.SelectedIndex + 1);
                    int cityId = comboBoxCity.SelectedIndex + 1;
                    if (comboBoxCountry.SelectedIndex == 1)
                    {
                        cityId += 7;
                    }
                    if (comboBoxCountry.SelectedIndex == 2)
                    {
                        cityId += 12;
                    }
                    DBConnection.cmd.Parameters.AddWithValue("city_id", cityId);
                    DBConnection.cmd.Parameters.AddWithValue("address1", textBoxAdr1.Text);
                    DBConnection.cmd.Parameters.AddWithValue("adress2", textBoxAdr1.Text);
                    DBConnection.cmd.Parameters.AddWithValue("date", NpgsqlTypes.NpgsqlDbType.Date, dateTimePickerBirth.Value);
                    DBConnection.cmd.Parameters.AddWithValue("passport_id", id);
                    DBConnection.cmd.ExecuteNonQuery();

                    MessageBox.Show("Изменено!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBConnection.con.Close();
                    this.Close();
                }
                catch (NpgsqlException ne)
                {
                    MessageBox.Show(ne.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DBConnection.con.Close();
                }

            }
            else
            {
                MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

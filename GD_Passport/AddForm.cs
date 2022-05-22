using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Passport
{
    public partial class AddForm : Form
    {
        Bitmap image;
        bool isImage;

        public AddForm()
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
            if (isOk2)
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

                    DBConnection.sql = "INSERT INTO public.person(surname, name, patronym, date_birth, sex_id, photo) " +
                            "VALUES(@surname, @name, @patronym, @date_birth, @sex_id, @photo); ";
                    DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                    DBConnection.cmd.Parameters.AddWithValue("surname", textBoxSurname.Text);
                    DBConnection.cmd.Parameters.AddWithValue("name", textBoxName.Text);
                    DBConnection.cmd.Parameters.AddWithValue("patronym", textBoxPatr.Text);
                    DBConnection.cmd.Parameters.AddWithValue("date_birth", NpgsqlTypes.NpgsqlDbType.Date, dateTimePickerBirth.Value);
                    DBConnection.cmd.Parameters.AddWithValue("sex_id", comboBoxSex.SelectedIndex + 1);
                    ImageConverter converter = new ImageConverter();
                    DBConnection.cmd.Parameters.AddWithValue("photo", NpgsqlTypes.NpgsqlDbType.Bytea, (byte[])converter.ConvertTo(image, typeof(byte[])));
                    DBConnection.cmd.ExecuteNonQuery();

                    DBConnection.sql = "SELECT person_id FROM person ORDER BY person_id DESC LIMIT 1;";
                    DBConnection.cmd = new NpgsqlCommand(DBConnection.sql, DBConnection.con);
                    NpgsqlDataReader dataReader = DBConnection.cmd.ExecuteReader();
                    int personId = 0;
                    if (dataReader.Read())
                    {
                        personId = dataReader.GetInt32(0);
                    }
                    dataReader.Close();


                    DBConnection.sql = "INSERT INTO public.passport(series, num, person_id, department_id, city_id, address1, adress2, date)" +
                            "VALUES(@series, @num, @person_id, @department_id, @city_id, @address1, @adress2, @date); ";
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
                    DBConnection.cmd.ExecuteNonQuery();

                    MessageBox.Show("Добавлено!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

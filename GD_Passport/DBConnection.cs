using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD_Passport
{
    class DBConnection
    {
        private static string conString = "Host=localhost; Port=5432; Database=passportdb; Username=postgres; Password=Xsd3bgh6;";
        public static NpgsqlConnection con = new NpgsqlConnection(conString);
        public static NpgsqlCommand cmd = default(NpgsqlCommand);
        public static string sql = string.Empty;

        public static DataTable getDataTable(NpgsqlCommand com)
        {
            NpgsqlDataAdapter da = default(NpgsqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                da = new NpgsqlDataAdapter();
                da.SelectCommand = com;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }
            return dt;
        }
    }
}

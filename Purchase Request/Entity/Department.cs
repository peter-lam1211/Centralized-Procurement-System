using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Request
{
    public class Department
    {
        private static Dictionary<string, Department> dict = new Dictionary<string, Department>();

        public string id, name;

        public Department(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static Department get(string id)
        {
            return dict[id];
        }

        public static void Reload(MySqlConnection conn)
        {
            dict.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM department;", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            foreach (DataRow row in table.Rows)
            {

                dict.Add((string)row[0], new Department((string)row[0], (string)row[1]));
            }
        }

        public static void Reload()
        {
            var conn = Db.GetConnection();
            Reload(conn);
            conn.Close();
        }

        public static IEnumerable<Department> GetDepartments()
        {
            foreach (Department department in dict.Values)
            {
                yield return department;
            }
        }

        public static void UploadComboBox(ComboBox comboBox, Object defaultItem)
        {
            int selectedIndex = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            if (defaultItem != null)
            {
                comboBox.Items.Add(defaultItem);
            }
            foreach (Department department in GetDepartments())
            {
                comboBox.Items.Add(department);
            }
            StockListForm.comboBoxEventBlock = true;
            comboBox.SelectedIndex = selectedIndex;
            StockListForm.comboBoxEventBlock = false;
        }

        public override string ToString()
        {
            return name;
        }
    }
}

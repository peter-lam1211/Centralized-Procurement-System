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
    public class Supplier
    {
        private static Dictionary<string, Supplier> stringDict = new Dictionary<string, Supplier>();

        private static Dictionary<int, Supplier> dict = new Dictionary<int, Supplier>();

        public int id;

        public String stringId, name, address, contactPerson, phone;
        private Supplier(int id, String name, String address, String contactPerson, String phone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.contactPerson = contactPerson;
            this.phone = phone;
        }

        public Supplier(String stringId, String name, String address, String contactPerson, String phone) : this(ConvertStringId(stringId), name, address, contactPerson, phone)
        {
            this.stringId = stringId;
        }

        public static int ConvertStringId(String stringId)
        {
            if (stringId.Length < 6)
                return -1;
            int id = 0;
            for (int i = 3; i < stringId.Length; i++)
            {
                id *= 10;
                id += (int)(stringId[i] - '0');
            }
            return id;
        }

        public static void Reload(MySqlConnection conn)
        {
            stringDict.Clear();
            dict.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM supplier;", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                Supplier supplier = new Supplier((string)row[0], (string)row[1], (string)row[2], (string)row[3], (string)row[4]);
                stringDict.Add((string)row[0], supplier);
                dict.Add(supplier.id, supplier);
            }
        }

        public static bool Contain(Supplier supplier)
        {
            return supplier != null && dict.ContainsKey(supplier.id) && dict[supplier.id].name == supplier.name;
        }

        public static Supplier Get(String stringId)
        {
            return stringDict[stringId];
        }

        public static Supplier Get(int id)
        {
            return dict[id];
        }

        public static void Reload()
        {
            var conn = Db.GetConnection();
            Reload(conn);
            conn.Close();
        }

        public static int GetAllowID()
        {
            MySqlConnection conn = Db.GetConnection();
            String sql = "SELECT COALESCE(MAX(supplierID), 'SUP000') FROM supplier;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var dr = cmd.ExecuteReader();
            int id = -1;
            if (dr.HasRows)
            {
                dr.Read();
                String stringId = dr.GetString(0);
                id = ConvertStringId(stringId) + 1;

            }
            conn.Close();
            return id;
        }

        public static String ConvertId(int id)
        {
            if (id == 0)
                return "SUP000";
            var count = Math.Log10(id) + 1;
            String stringId = "SUP";
            for (int i = 0; i < 3 - count; i++)
            {
                stringId += '0';
            }
            stringId += id;
            return stringId;
        }

        public String getStringId()
        {
            return stringId;
        }

        public static IEnumerable<Supplier> GetSuppliers()
        {
            foreach (Supplier supplier in dict.Values)
            {
                yield return supplier;
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
            foreach (Supplier supplier in GetSuppliers())
            {
                comboBox.Items.Add(supplier);
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

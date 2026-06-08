using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Request
{
    public class Warehouse
    {
        public static Dictionary<string, Warehouse> dict = new Dictionary<string, Warehouse>();

        public string warehouseID, address;

        public Warehouse(string warehouseID, string address)
        {
            this.warehouseID = warehouseID;
            this.address = address;
        }

        public static void UploadComboBox(ComboBox comboBox, Object defaultItem)
        {
            int selectedIndex = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            if (defaultItem != null)
            {
                comboBox.Items.Add(defaultItem);
            }
            foreach (Warehouse warehouse in GetWarehouses())
            {
                comboBox.Items.Add(warehouse);
            }
            WarehouseItemForm.comboBoxEventBlock = true;
            comboBox.SelectedIndex = selectedIndex;
            WarehouseItemForm.comboBoxEventBlock = false;
        }

        public static IEnumerable<Warehouse> GetWarehouses()
        {
            foreach (Warehouse wh in dict.Values)
            {
                yield return wh;
            }
        }

        public static void Reload(MySqlConnection conn)
        {
            dict.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT warehouseID, address FROM `warehouse`", conn);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string warehouseID = dr.GetString(0), address = dr.GetString(1);
                dict.Add(warehouseID, new Warehouse(warehouseID, address));
            }
            dr.Close();
        }

        public string GetName()
        {
            string name = "";
            for(int i = 0; i < warehouseID.Length; i++)
            {
                if (warehouseID[i] == 'W' || warehouseID[i] == 'H' || warehouseID[i] == '0')
                    continue;
                name += warehouseID[i];
            }
            return "Warehouse " + name;
        }

        public static void Reload()
        {
            var conn = Db.GetConnection();
            Reload(conn);
            conn.Close();
        }

        public static Warehouse Get(string warehouseID)
        {
            return dict.ContainsKey(warehouseID) ? dict[warehouseID] : null;
        }

        override
        public string ToString()
        {
            return GetName();
        }
    }
}

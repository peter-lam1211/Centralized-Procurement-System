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
    public class WarehouseItem
    {
        public enum EditMode {Add, Remove, Modify};

        public static Dictionary<string, Dictionary<string, WarehouseItem>> dict = new Dictionary<string, Dictionary<string, WarehouseItem>>();

        public string warehouseID, itemID;

        public int quantity;
        public WarehouseItem(string warehouseID, string itemID, int quantity)
        {
            this.warehouseID = warehouseID;
            this.itemID = itemID;
            this.quantity = quantity;
        }

        public static void Reload(MySqlConnection conn)
        {
            dict.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT warehouseID, itemID, quantity FROM `warehouse_item`", conn);
            var dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string warehouseID = dr.GetString(0), itemID = dr.GetString(1);
                int quantity = dr.GetInt32(2);
                if(!dict.ContainsKey(itemID))
                {
                    dict.Add(itemID, new Dictionary<string, WarehouseItem>());
                }
                if(!dict[itemID].ContainsKey(warehouseID))
                    dict[itemID].Add(warehouseID, new WarehouseItem(warehouseID, itemID, quantity));
            }
            dr.Close();
        }

        public static IEnumerable<WarehouseItem> GetWarehouseItems()
        {
            foreach (Dictionary<string, WarehouseItem> dict1 in dict.Values)
                foreach (WarehouseItem i in dict1.Values)
                    yield return i;
        }

        public static void Reload()
        {
            var conn = Db.GetConnection();
            Reload(conn);
            conn.Close();
        }

        public static int GetItemQuantity(Item item)
        {
            if (!dict.ContainsKey(item.id))
                return 0;
            int quantity = 0;
            foreach (WarehouseItem warehouseItem in dict[item.id].Values)
            {
                quantity += warehouseItem.quantity;
            }
            return quantity;
        }

        public static WarehouseItem GetWarehouseItem(Warehouse warehouse, Item item)
        {
            if(dict.ContainsKey(item.id) && dict[item.id].ContainsKey(warehouse.warehouseID))
                return dict[item.id][warehouse.warehouseID];
            return new WarehouseItem(warehouse.warehouseID, item.id, 0);
        }

        public static bool IsCreated(WarehouseItem warehouseItem, MySqlConnection conn)
        {
            String sql = "SELECT warehouseID FROM `warehouse_item` WHERE warehouseID = @warehouseID AND itemID = @itemID;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@warehouseID", MySqlDbType.VarChar).Value = warehouseItem.warehouseID;
            cmd.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = warehouseItem.itemID;
            var dr = cmd.ExecuteReader();
            bool result = dr.HasRows;
            dr.Close();
            return result;
        }

        public static bool IsCreated(WarehouseItem warehouseItem)
        {
            MySqlConnection conn = Db.GetConnection();
            bool result = IsCreated(warehouseItem);
            conn.Close();
            return result;
        }

        public static void DeleteWithItem(string itemID)
        {
            MySqlConnection conn = Db.GetConnection();
            DeleteWithItem(itemID, conn);
            conn.Close();
        }

        public static void DeleteWithItem(string itemID, MySqlConnection conn)
        {
            string sql = "DELETE FROM warehouse_item WHERE itemID = @itemID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ItemID", MySqlDbType.VarChar).Value = itemID;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item quantity not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Update(WarehouseItem warehouseItem, EditMode mode, int value)
        {
            MySqlConnection conn = Db.GetConnection();
            if (mode == EditMode.Remove)
                value *= -1;
            if (!IsCreated(warehouseItem, conn))
            {
                warehouseItem.quantity = value;
                Create(warehouseItem, conn);
            }
            else
            {
                String sql;
                if(mode == EditMode.Add || mode == EditMode.Remove)
                    sql = "UPDATE warehouse_item SET quantity = quantity + @value WHERE warehouseID = @warehouseID AND itemID = @itemID;";
                else
                    sql = "UPDATE warehouse_item SET quantity = @value WHERE warehouseID = @warehouseID AND itemID = @itemID;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 200;
                cmd.Parameters.Add("@warehouseID", MySqlDbType.VarChar).Value = warehouseItem.warehouseID;
                cmd.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = warehouseItem.itemID;
                cmd.Parameters.Add("@value", MySqlDbType.Int32).Value = value;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Item quantity not Update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();
        }

        public static void Create(WarehouseItem warehouseItem, MySqlConnection conn)
        {
            String sql = "INSERT INTO warehouse_item VALUES (@warehouseID, @itemID, @quantity);";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@warehouseID", MySqlDbType.VarChar).Value = warehouseItem.warehouseID;
            cmd.Parameters.Add("@itemID", MySqlDbType.VarChar).Value = warehouseItem.itemID;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = warehouseItem.quantity;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Created Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item Category Create not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Create(WarehouseItem warehouseItem)
        {
            MySqlConnection conn = Db.GetConnection();
            Create(warehouseItem, conn);
            conn.Close();
        }
    }
}

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
    public class Item
    {

        public String id, name, unit, description, virtualItemID;

        public ItemCategory itemCategory;

        public Supplier supplier;

        public static String selectParam = "`itemID`, `itemName`, `unit`, `itemCategoryID`, `itemDescription`, `supplierID`, `virtualItemID`";

        public Item(string id, String name, String unit, String itemCategoryID, String description, String supplierID, string virtualItemID)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
            this.itemCategory = ItemCategory.Get(itemCategoryID);
            this.description = description;
            supplier = Supplier.Get(supplierID);
            this.virtualItemID = virtualItemID;
        }

        public Item(string id, String name, String unit, String itemCategoryID, String description, String supplierID) : this(id, name, unit, itemCategoryID, description, supplierID, "V" + id) { }
        public String GetStringId()
        {
            /*
            if (this.id == 0)
                return "IT-000";
            var count = Math.Log10(this.id) + 1;
            String stringId = "IT-";
            for(int i = 0; i < 3 - count; i++)
            {
                stringId += '0';
            }
            stringId += id;
            */
            return id;
        }

        public String GetStringQuantity()
        {
            return "" + WarehouseItem.GetItemQuantity(this) + ((this.unit != "") ? " " + this.unit : "");
        }

        public int GetQuantity(Warehouse warehouse)
        {
            WarehouseItem.Reload();
            if(!WarehouseItem.dict.ContainsKey(this.id))
                return 0;
            if(!WarehouseItem.dict[id].ContainsKey(warehouse.warehouseID))
                return 0;
            return WarehouseItem.dict[id][warehouse.warehouseID].quantity;
        }

        public static IEnumerable<Item> SearchItems(String query, ItemCategory itemCategory, Supplier supplier)
        {
            MySqlConnection conn = Db.GetConnection();
            ItemCategory.Reload(conn);
            MySqlCommand cmd;
            if (ItemCategory.Contain(itemCategory) && Supplier.Contain(supplier))
            {
                cmd = new MySqlCommand("SELECT " + selectParam + " FROM item WHERE itemName LIKE @name AND itemCategoryID = @itemCategoryID AND supplierID = @supplierID;", conn);
                cmd.Parameters.Add("@itemCategoryID", MySqlDbType.VarChar).Value = itemCategory.id;
                cmd.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = supplier.getStringId();
            }
            else if(ItemCategory.Contain(itemCategory))
            {
                cmd = new MySqlCommand("SELECT " + selectParam + " FROM item WHERE itemName LIKE @name AND itemCategoryID = @itemCategoryID;", conn);
                cmd.Parameters.Add("@itemCategoryID", MySqlDbType.VarChar).Value = itemCategory.id;
            }
            else if(Supplier.Contain(supplier))
            {
                cmd = new MySqlCommand("SELECT " + selectParam + " FROM item WHERE itemName LIKE @name AND supplierID = @supplierID;", conn);
                cmd.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = supplier.getStringId();
            }
            else
            {
                cmd = new MySqlCommand("SELECT " + selectParam + " FROM item WHERE itemName LIKE @name;", conn);
            }
            cmd.Parameters.AddWithValue("@name", '%' + query + '%');
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                yield return new Item(Db.ConvertString(row[0]), Db.ConvertString(row[1]), Db.ConvertString(row[2]), Db.ConvertString(row[3]), Db.ConvertString(row[4]), Db.ConvertString(row[5]), Db.ConvertString(row[6]));
            }
            conn.Close();
        }
        public bool IsEquals(Item item)
        {

            if (item == null)
            {
                return false;
            }
            return id == item.id && name == item.name;
        }

        public static IEnumerable<Item> GetItems()
        {
            MySqlConnection conn = Db.GetConnection();
            Warehouse.Reload();
            WarehouseItem.Reload(conn);
            ItemCategory.Reload(conn);
            Supplier.Reload(conn);

            MySqlCommand cmd = new MySqlCommand("SELECT " + selectParam + " FROM item;", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                yield return new Item(Db.ConvertString(row[0]), Db.ConvertString(row[1]), Db.ConvertString(row[2]), Db.ConvertString(row[3]), Db.ConvertString(row[4]), Db.ConvertString(row[5]), Db.ConvertString(row[6]));
            }
            /*
            var dr = cmd.ExecuteReader();
            while(dr.HasRows)
            {
                dr.Read();
                yield return new Item(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetString(3), dr.GetInt32(4), dr.GetString(5));
            }
            */
            conn.Close();
        }

        public static Item GetItem(string id)
        {
            foreach (Item item in GetItems())
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static string GetAllowID(string itemCategoryId)
        {
            MySqlConnection conn = Db.GetConnection();
            String sql = "SELECT COALESCE(MAX(itemID), \"None\") FROM item WHERE itemID LIKE @itemCategoryParam;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@itemCategoryParam", MySqlDbType.VarChar).Value = itemCategoryId + "-%";
            var dr = cmd.ExecuteReader();
            string id = "";
            if (dr.HasRows)
            {
                dr.Read();
                id = dr.GetString(0);
            }
            if (id == "None" || id == "")
                return itemCategoryId + "-01";
            int startPoint = id.IndexOf('-') + 1;
            if (startPoint == id.Length || startPoint == -1)
                throw new FormatException("itemID of database is incorrect");
            int intId = 0;
            for(int i = startPoint; i < id.Length; i++)
            {
                intId *= 10;
                intId += (int)(id[i] - '0');
            }
            intId += 1;
            return string.Format("{0}-{1:D2}", itemCategoryId, intId);
            /*
            MySqlConnection conn = Db.GetConnection();
            String sql = "SELECT COALESCE(MAX(itemID), 0) + 1 FROM item;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var dr = cmd.ExecuteReader();
            int id = -1;
            if(dr.HasRows)
            {
                dr.Read();
                id = dr.GetInt32(0);
            }
            conn.Close();
            */
        }

        public static void Create(Item item)
        {
            String sql = "INSERT INTO item (" + selectParam + ") VALUES (@id, @name, @unit, @itemCategoryID, @description, @supplierID, @virtualItemID);";
            MySqlConnection conn = Db.GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = item.id;
            cmd.Parameters.Add("@virtualItemID", MySqlDbType.VarChar).Value = item.virtualItemID;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.name;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = item.unit;
            cmd.Parameters.Add("@itemCategoryID", MySqlDbType.VarChar).Value = item.itemCategory.id;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = item.description;
            cmd.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = item.supplier.getStringId();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public static void Update(Item item)
        {
            String sql = "UPDATE item SET itemName = @name, unit = @unit, itemCategoryID  = @itemCategoryID, itemDescription = @description, supplierID = @supplierID WHERE itemID = @id;";
            MySqlConnection conn = Db.GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = item.id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.name;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = item.unit;
            cmd.Parameters.Add("@itemCategoryID", MySqlDbType.VarChar).Value = item.itemCategory.id;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = item.description;
            cmd.Parameters.Add("@supplierID", MySqlDbType.VarChar).Value = item.supplier.getStringId();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edit Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item not Edit. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
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

        public static void DeleteWithCategory(string itemCategoryID)
        {
            MySqlConnection conn = Db.GetConnection();
            string sql = "DELETE item, warehouse_item FROM warehouse_item LEFT JOIN item ON item.itemID = warehouse_item.itemID WHERE item.itemCategoryID = @itemCategoryID;DELETE FROM item WHERE itemCategoryID = @itemCategoryID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@itemCategoryID", MySqlDbType.VarChar).Value = itemCategoryID;

            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public static void Delete(string id)
        {
            MySqlConnection conn = Db.GetConnection();

            WarehouseItem.DeleteWithItem(id, conn);

            string sql = "DELETE FROM item WHERE itemID = @ItemID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ItemID", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }
    }
}

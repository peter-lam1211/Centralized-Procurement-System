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
    public class ItemCategory
    {
        private static Dictionary<string, ItemCategory> dict = new Dictionary<string, ItemCategory>();

        public string id;

        public String name, description;

        public ItemCategory(string id, String name, String description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }


        public static void Reload(MySqlConnection conn)
        {
            dict.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM itemcategory;", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                string id = (string)row[0];
                dict.Add(id, new ItemCategory(id, Db.ConvertString(row[1]), Db.ConvertString(row[2])));
            }
        }
        public static void Reload()
        {
            var conn = Db.GetConnection();
            Reload(conn);
            conn.Close();
        }

        public static ItemCategory Get(String id)
        {
            return dict.ContainsKey(id) ? dict[id] : null;
        }

        public static ItemCategory GetName(String name)
        {
            foreach(ItemCategory itemCategory in GetItemCategorys())
            {
                if (itemCategory.name == name)
                    return itemCategory;
            }
            return null;
        }

        public static IEnumerable<ItemCategory> GetItemCategorys()
        {
            foreach(ItemCategory c in dict.Values)
            {
                yield return c;
            }
        }

        public IEnumerable<Item> GetItems()
        {
            return Item.SearchItems("", this, null);
        }

        public static void UploadComboBox(ComboBox comboBox, Object defaultItem)
        {
            int selectedIndex = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            if (defaultItem != null)
            {
                comboBox.Items.Add(defaultItem);
            }
            foreach (ItemCategory itemCategory in Purchase_Request.ItemCategory.GetItemCategorys())
            {
                comboBox.Items.Add(itemCategory);
            }
            StockListForm.comboBoxEventBlock = true;
            comboBox.SelectedIndex = selectedIndex;
            StockListForm.comboBoxEventBlock = false;
        }

        public static bool Contain(ItemCategory itemCategory)
        {
            return itemCategory != null && dict.ContainsKey(itemCategory.id) && dict[itemCategory.id].name == itemCategory.name;
        }

        public static string GetAllowID(string name)
        {
            name = name.ToUpper();
            string id = "";
            for(int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                    continue;
                id += name[i];
                if (ItemCategory.Get(id) == null)
                    return id;
            }
            int j = 0;
            while (true)
            {
                j++;
                if (ItemCategory.Get(id + j) == null)
                    return id + j;
            }
            /*
            MySqlConnection conn = Db.GetConnection();
            String sql = "SELECT COALESCE(MAX(itemCategoryID), 0) + 1 FROM itemcategory;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var dr = cmd.ExecuteReader();
            int id = -1;
            if (dr.HasRows)
            {
                dr.Read();
                id = dr.GetInt32(0);
            }
            conn.Close();
            */
        }

        public static void Create(ItemCategory itemCategory)
        {
            String sql = "INSERT INTO itemcategory VALUES (@id, @name, @description);";
            MySqlConnection conn = Db.GetConnection();
            
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = itemCategory.id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = itemCategory.name;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = itemCategory.description;

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

            conn.Close();
        }

        public static void Delete(string id)
        {
            Item.DeleteWithCategory(id);

            MySqlConnection conn = Db.GetConnection();
            string sql = "DELETE FROM itemcategory WHERE itemCategoryID = @ItemCategoryID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ItemCategoryID", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item Category not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
            
        }

        public static void Update(ItemCategory itemCategory)
        {
            String sql = "UPDATE itemcategory SET itemCategoryName = @name, description = @description WHERE itemCategoryID = @id;";
            MySqlConnection conn = Db.GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = itemCategory.id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = itemCategory.name;
            cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = itemCategory.description;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edit Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item Category Create not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public bool IsEquals(ItemCategory itemCategory)
        {

            if (itemCategory == null)
            {
                return false;
            }
            return id == itemCategory.id && name == itemCategory.name;
        }

        public static ItemCategory GetItemCategory(string id)
        {
            foreach (ItemCategory itemCategory in GetItemCategorys())
            {
                if (itemCategory.id == id)
                {
                    return itemCategory;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}

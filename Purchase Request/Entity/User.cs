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
    public class User
    {
        public string id, name, position, password, email;

        public DateTime birthday, createDate;

        public Department department;

        public User(string id, string name, DateTime birthday, string departmentID, string position, string password, string email, DateTime createDate)
        {
            this.id = id;
            this.name = name;
            this.position = position;
            this.password = password;
            this.email = email;
            this.birthday = birthday;
            this.createDate = createDate;
            department = Department.get(departmentID);
        }

        public static User Login(string email, string password)
        {
            MySqlConnection conn = Db.GetConnection();
            Department.Reload(conn);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE email = @email AND password = @password;", conn);
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            var dr = cmd.ExecuteReader();
            User user;
            if (dr.HasRows)
            {
                dr.Read();
                user = new User(dr.GetString(0), dr.GetString(1), dr.GetDateTime(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetDateTime(7));
            }
            else
            {
                user = null;
            }
            conn.Close();
            return user;
        }

        public static IEnumerable<User> GetUsers()
        {
            MySqlConnection conn = Db.GetConnection();
            Department.Reload(conn);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user;", conn);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new User(dr.GetString(0), dr.GetString(1), dr.GetDateTime(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetDateTime(7));
            }
            conn.Close();
        }

        public static User GetUser(string id)
        {
            foreach (User user in GetUsers())
            {
                if (user.id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public static string ToStringID(int year, int id)
        {
            return string.Format("{0}{1:D3}", year, id);
        }

        public static int ToID(string stringId)
        {
            return Convert.ToInt32(stringId.Substring(4));
        }

        public static string GetAllowID()
        {
            MySqlConnection conn = Db.GetConnection();
            string sql = "SELECT COALESCE(MAX(userID), 'None') FROM `user` WHERE userID LIKE @year";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@year", MySqlDbType.VarChar).Value = DateTime.Now.Year.ToString() + '%';
            var dr = cmd.ExecuteReader();
            string stringId = "";
            if (dr.HasRows)
            {
                dr.Read();
                stringId = dr.GetString(0);
                int id = ToID(stringId) + 1;
                stringId = ToStringID(DateTime.Now.Year, id);
            }
            conn.Close();
            return stringId;
        }

        public static void Create(User user)
        {
            string sql = "INSERT INTO `user` (`userID`, `userName`, `dateOfBirth`, `departmentID`, `position`, `password`, `email`) VALUES (@userID, @userName, @dateOfBirth, @departmentID, @position, @password, @email);";
            MySqlConnection conn = Db.GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@userID", MySqlDbType.VarChar).Value = user.id;
            cmd.Parameters.Add("@userName", MySqlDbType.VarChar).Value = user.name;
            cmd.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = user.birthday;
            cmd.Parameters.Add("@departmentID", MySqlDbType.VarChar).Value = user.department.id;
            cmd.Parameters.Add("@position", MySqlDbType.VarChar).Value = user.position;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Created Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Staff Create not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public static void Delete(string id)
        {
            MySqlConnection conn = Db.GetConnection();
            string sql = "DELETE FROM user WHERE userID = @userID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@userID", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("User not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public static void Update(User user)
        {
            string sql = "UPDATE user SET userName = @userName, dateOfBirth = @birthday, departmentID = @departmentID, position = @position, password = @password, email = @email WHERE userID = @userID;";
            MySqlConnection conn = Db.GetConnection();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200;
            cmd.Parameters.Add("@userID", MySqlDbType.VarChar).Value = user.id;
            cmd.Parameters.Add("@userName", MySqlDbType.VarChar).Value = user.name;
            cmd.Parameters.Add("@birthday", MySqlDbType.Date).Value = user.birthday;
            cmd.Parameters.Add("@departmentID", MySqlDbType.VarChar).Value = user.department.id;
            cmd.Parameters.Add("@position", MySqlDbType.VarChar).Value = user.position;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            //cmd.Parameters.Add("@createDate", MySqlDbType.Date).Value = user.createDate;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Created Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Staff not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(cmd.CommandText, "Sql cmd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        /**
        public static bool Contain(User user)
        {
            return user != null && dict.ContainsKey(itemCategory.id) && dict[itemCategory.id].name == itemCategory.name;
        }
        **/

        public static IEnumerable<User> SearchUsers(String query, Department department)
        {
            MySqlConnection conn = Db.GetConnection();
            ItemCategory.Reload(conn);
            MySqlCommand cmd;
            if (department != null)
            {
                cmd = new MySqlCommand("SELECT * FROM user WHERE userName LIKE @name AND departmentID = @departmentID;", conn);
                cmd.Parameters.Add("@departmentID", MySqlDbType.VarChar).Value = department.id;
            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM user WHERE userName LIKE @name;", conn);
            }
            cmd.Parameters.AddWithValue("@name", '%' + query + '%');
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new User(dr.GetString(0), dr.GetString(1), dr.GetDateTime(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetDateTime(7));
            }
            conn.Close();
        }

        override
        public string ToString()
        {
            return id;
        }

        public static void UploadComboBox(ComboBox comboBox, Object defaultItem)
        {
            int selectedIndex = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            if (defaultItem != null)
            {
                comboBox.Items.Add(defaultItem);
            }
            foreach (User user in GetUsers())
            {
                comboBox.Items.Add(user);
            }
            comboBox.SelectedIndex = selectedIndex;
        }
    }
}

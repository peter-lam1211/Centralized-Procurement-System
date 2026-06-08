using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Purchase_Request
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            reloadData();
        }

        public void reloadData()
        {
            GraphicUtil.DrawSquare(square1);
            GraphicUtil.DrawSquare(square2);
            GraphicUtil.DrawSquare(square3);
            GraphicUtil.DrawSquare(square4);
            GraphicUtil.DrawSquare(square5);
            GraphicUtil.DrawSquare(square6);
            GraphicUtil.DrawSquare(square7);
            MySqlConnection conn = Db.GetConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT COALESCE(SUM(quantity), 0) FROM purchaseorder_item;", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                totalItem.Text = "" + dr.GetInt32(0);
            }
            dr.Close();
            cmd = new MySqlCommand("SELECT COALESCE(SUM(purchaseorder_item.quantity * item.price), 0) FROM purchaseorder_item LEFT JOIN item ON item.itemID = purchaseorder_item.itemID;", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                totalSpending.Text = "$" + dr.GetInt32(0);
            }
            dr.Close();
            cmd = new MySqlCommand("SELECT COALESCE(SUM(purchaseorder_item.quantity), 0) FROM purchaseorder_item LEFT JOIN item ON item.itemID = purchaseorder_item.itemID LEFT JOIN purchaseorder ON purchaseorder.purchaseOrderID = purchaseorder_item.purchaseOrderID WHERE MONTH(STR_TO_DATE(purchaseorder.createDate, '%W, %M %d, %Y')) = MONTH(CURRENT_DATE());", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                monthlyItemRequest.Text = "" + dr.GetInt32(0);
            }
            dr.Close();
            cmd = new MySqlCommand("SELECT COALESCE(SUM(purchaseorder_item.quantity * item.price), 0) FROM purchaseorder_item LEFT JOIN item ON item.itemID = purchaseorder_item.itemID LEFT JOIN purchaseorder ON purchaseorder.purchaseOrderID = purchaseorder_item.purchaseOrderID WHERE MONTH(STR_TO_DATE(purchaseorder.createDate, '%W, %M %d, %Y')) = MONTH(CURRENT_DATE());", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                monthiySpending.Text = "$" + dr.GetInt32(0);
            }
            dr.Close();
            cmd = new MySqlCommand("SELECT COALESCE(COUNT(*), 0) FROM purchaserequest", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                prTotal.Text = "Total: " + dr.GetInt32(0);
            }
            dr.Close();
            cmd = new MySqlCommand("SELECT COALESCE(COUNT(*), 0) FROM deliveryrequest", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                drTotal.Text = "Total: " + dr.GetInt32(0);
            }
            dr.Close();
            cmd = new MySqlCommand("SELECT COALESCE(COUNT(*), 0) FROM blanketrelease", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                brTotal.Text = "Total: " + dr.GetInt32(0);
            }
            dr.Close();
            GraphicUtil.DrawDbStatusBar(bar1, conn, "purchaserequest", new string[] { "waiting", "mapping", "finished" }, new Color[] { Color.Red, Color.Gold, Color.Green }, new Label[] { pr_1, pr_2, pr_3 });
            GraphicUtil.DrawDbStatusBar(bar2, conn, "deliveryrequest", new string[] { "waiting", "finish" }, new Color[] { Color.Gold, Color.Green }, new Label[] { dr_1, dr_2 });
            GraphicUtil.DrawDbStatusBar(bar3, conn, "blanketrelease", new string[] { "deliverying", "finished" }, new Color[] { Color.Gold, Color.Green }, new Label[] { br_1, br_2 });

            purchaseOrderChart.Series["Count"].Points.Clear();
            purchaseOrderChart.Titles.Clear();
            purchaseOrderChart.Titles.Add("Purchase Order Type");
            purchaseAgreementChart.Series["Count"].Points.Clear();
            purchaseAgreementChart.Titles.Clear();
            purchaseAgreementChart.Titles.Add("Purchase Agreement Type");


            cmd = new MySqlCommand("SELECT purchaseOrderType, COUNT(*) FROM `purchaseorder` GROUP BY purchaseOrderType;", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    purchaseOrderChart.Series["Count"].Points.AddXY(dr.GetString(0), dr.GetString(1));
                }
            }
            dr.Close();

            cmd = new MySqlCommand("SELECT agreementType, COUNT(*) FROM purchaseagreement GROUP BY agreementType;", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    purchaseAgreementChart.Series["Count"].Points.AddXY(dr.GetString(0), dr.GetString(1));
                }
            }
            dr.Close();
        }
    }

    static class GraphicUtil
    {
        public static void DrawDbStatusBar(PictureBox pictureBox, MySqlConnection conn, string tableName, string[] status, Color[] colors, Label[] labels)
        {
            MySqlCommand cmd;
            MySqlDataReader dr;
            int[] values = new int[status.Length];
            int count = 0;
            for (int i = 0; i < status.Length; i++)
            {
                cmd = new MySqlCommand("SELECT COUNT(*) FROM " + tableName + " WHERE status = \"" + status[i] + '"', conn);
                dr = cmd.ExecuteReader();
                values[i] = 0;
                if (dr.HasRows)
                {
                    dr.Read();
                    count += values[i] = dr.GetInt32(0);
                }
                dr.Close();
            }
            DrawPercentageBar(pictureBox, values, colors);
            if (labels != null)
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Text = "" + values[i] + "(" + ((float)values[i] / count).ToString("P2") + ")";
                }
            }
        }

        public static void DrawSquare(PictureBox pictureBox)
        {
            DrawSquare(pictureBox, 5);
        }

        public static void DrawSquare(PictureBox pictureBox, int border)
        {
            float x = pictureBox.Width - border, y = pictureBox.Height - border;
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            //graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            graphics.DrawLine(pen, border, border, border, y);
            graphics.DrawLine(pen, border, y, x, y);
            graphics.DrawLine(pen, border, border, x, border);
            graphics.DrawLine(pen, x, border, x, y);
            //graphics.FillRectangle(new SolidBrush(Color.Tomato), 10, 10, 100, 100);
            pictureBox.Image = bitmap;
        }

        public static void DrawPercentageBar(PictureBox pictureBox, int[] intArray, Color[] colors)
        {
            if (intArray.Length != colors.Length)
                return;
            int total = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                total += intArray[i];
            }
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.FillRectangle(new SolidBrush(Color.Tomato), 0, 0, pictureBox.Width, pictureBox.Height);
            float scaleLoc = 0;
            for (int j = 0; j < intArray.Length; j++)
            {
                float scale = (float)intArray[j] / total;
                graphics.FillRectangle(new SolidBrush(colors[j]), (scaleLoc) * pictureBox.Width, 0, (scale) * pictureBox.Width, pictureBox.Height);
                //MessageBox.Show("" + (scaleLoc) * pictureBox.Width + ", 0, " + (scale) * pictureBox.Width + ", " + pictureBox.Height);
                scaleLoc += scale;
            }
            pictureBox.Image = bitmap;
        }
    }
}

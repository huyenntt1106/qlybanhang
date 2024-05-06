﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace qlybanhang.Class
{
    internal class Function
    {
        public static SqlConnection Conn;
        public static string connstring;
        public static void ketnoi()
        {
            connstring = "Data Source=DESKTOP-0BKJQ7L\\MAY1;Initial Catalog=quanlybanhang;Integrated Security=True;Encrypt=False";
            Conn = new SqlConnection();
            Conn.ConnectionString = connstring;

            Conn.Open();
         // MessageBox.Show("Done");
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection=Function.Conn;
            Mydata.SelectCommand.CommandText = sql;
            DataTable table=new DataTable();
            Mydata.Fill(table);
            return table;
         
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = Class.Function.Conn; // kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }



        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Function.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static bool IsDate(string d)
        {
            string[] parts=d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) &&
(Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else return false;
        }



    }
}

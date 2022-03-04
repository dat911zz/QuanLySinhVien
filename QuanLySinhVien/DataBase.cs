using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;

namespace QuanLySinhVien
{
    public class DataBase
    {
        SqlCommand cmd = new SqlCommand();
        //Khởi tạo kết nối tới CSDL
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=<Server-Name>;Initial Catalog=<table>;Persist Security Info=True;User ID=<username>;Password=<password>
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
            
        }
        //Test kết nối với mẫu chuỗi kết nối
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-GUE0JS7";
            string database = "SinhVien";
            string username = "test01";
            string password = "1234";
            return GetDBConnection(datasource, database, username, password);
        }
        //Chạy thử
        
        public List<QuanLySinhVien.> ExtractDB()
        {
            string sql = "SELECT * FROM dssv";

            Console.WriteLine("Getting Connection ...");
            SqlConnection conn = GetDBConnection();
            
            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                cmd.Connection = conn;
                cmd.CommandText = sql;
                //
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string mssv = reader.GetString(0);
                            string tensv = reader.GetString(1);
                            string gioitinh = reader.GetString(2);
                            DateTime ngaysinh = reader.GetDateTime(3);
                            string lop = reader.GetString(4);
                            int khoa = reader.GetInt32(5);
                            Console.Write("{0,-5}", ++i);
                            Console.WriteLine(" {0}, {1}, {2}, {3}, {4}, {5}", mssv, tensv, gioitinh, ngaysinh.ToShortDateString(), lop, khoa);

                            

                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
            }
            Console.Read();
        }
        
    }
}

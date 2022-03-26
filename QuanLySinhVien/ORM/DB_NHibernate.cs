using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;


namespace QuanLySinhVien.ORM
{
    public class DB_NHibernate : IORM
    {
        public void Extract(ref List<SinhVien> list_sv, ref List<MonHoc> list_mh)
        {
            var sefact = NHibernateSetup();
            ExtractSinhVien(sefact, ref list_sv);
            ExtractMonHoc(sefact, ref list_mh);
            ExtractDKHP(ref list_sv, list_mh);
        }
        /// <summary>
        /// Trích xuất bảng SinhVien
        /// </summary>
        /// <param name="sefact"></param>
        /// <param name="list_sv"></param>
        public void ExtractSinhVien(NHibernate.ISessionFactory sefact, ref List<SinhVien> list_sv)
        {
            using (var session = sefact.OpenSession())
            {
                list_sv = session.Query<SinhVien>().ToList();
                Console.WriteLine("\nFetch the complete list again\n");
                var students = session.CreateCriteria<SinhVien>().List<SinhVien>();
                int count = 0;
                foreach (var student in students)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3}", ++count, student.MaSV, student.TenSV, student.GioiTinh);
                }
            }
        }
        /// <summary>
        /// Trích xuất bảng MonHoc
        /// </summary>
        /// <param name="sefact"></param>
        /// <param name="list_mh"></param>
        public void ExtractMonHoc(NHibernate.ISessionFactory sefact, ref List<MonHoc> list_mh)
        {
            using (var session = sefact.OpenSession())
            {
                list_mh = session.Query<MonHoc>().ToList();
                Console.WriteLine("\nFetch the complete list again\n");
                var mhs = session.CreateCriteria<MonHoc>().List<MonHoc>();
                int count = 0;
                foreach (var mh in mhs)
                {
                    Console.WriteLine("{0} \t{1} \t{2}", ++count, mh.tenMH, mh.soTiet);
                }
            }
        }
        /// <summary>
        /// Trích xuất và đăng ký học phần tự động cho sinh viên
        /// </summary>
        /// <param name="list_sv"></param>
        /// <param name="list_mh"></param>
        public void ExtractDKHP(ref List<SinhVien> list_sv, List<MonHoc> list_mh)
        {
            SQLDataBase db = new SQLDataBase();
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = db.GetConnection("", "SinhVien", "test01", "1234");
            //db.GetConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Connection successful!");
                Console.ResetColor();
                Console.WriteLine();
                cmd.Connection = conn;
                //-------------------------------------
                cmd.CommandText = "SELECT * FROM DKHP";
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            List<MonHoc> tmp = new List<MonHoc>(list_mh.ToArray());
                            //-------------INPUT DATA----------------
                            for (int mh_i = 0; mh_i < reader.FieldCount; mh_i++)
                            {
                                if (reader.GetInt32(mh_i) == 1)
                                {
                                    //========Deep copy========= 
                                    var c = tmp[mh_i].Clone();
                                    list_sv[i].mhdk().Add((MonHoc)c);
                                }
                            }
                            i++;
                        }
                    }
                }
                //-------------------------------------
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
            
        }
        /// <summary>
        /// Setup custom configuration for NHibernate
        /// </summary>
        /// <returns></returns>
        public NHibernate.ISessionFactory NHibernateSetup()
        {
            NHibernateProfiler.Initialize();
            var cfg = new Configuration();
            cfg.Configure($"../../../ORM/hibernate.cfg.xml");
            return cfg.BuildSessionFactory();
        }

        //===================================================================================================================
        /// <summary>
        /// Beta testing for DataBase with NHibernate
        /// </summary>
        /// Log: "", "SinhVien","test01", "1234"
        public void NHibernateSetup(ref List<SinhVien> list_sv)
        {
            NHibernateProfiler.Initialize();
            var cfg = new Configuration();
            cfg.Configure($"../../../ORM/hibernate.cfg.xml");//Configure from file hibernate.cfg.xml
            //string connString = @"Data Source=" + datasource + ";Initial Catalog="
            //            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            cfg.DataBaseIntegration(x =>
            {
                //x.ConnectionString = connString;
                //x.Driver<SqlClientDriver>();
                //x.Dialect<MsSql2012Dialect>();
                x.LogSqlInConsole = true;//Show các câu lệnh SQL khi thực hiện hàm
            });

            //cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {
                //session.CreateQuery("");
                using (var tx = session.BeginTransaction())
                {
                    DateTime date = new DateTime(2000, 7, 19);//yyyy-mm-dd

                    //============Example For add sv into Table============
                    //var sinhvien1 = new SinhVien
                    //{
                    //    MaSV = "111121",
                    //    TenSV = "VCD",
                    //    GioiTinh = "nam",
                    //    NgaySinh = date,
                    //    Lop = "11DHTH8",
                    //    Khoa = "11"
                    //};
                    //==================================
                    Console.WriteLine("\nFetch the complete list again\n");
                    var students = session.CreateCriteria<SinhVien>().List<SinhVien>();
                    int count = 0;
                    foreach (var student in students)
                    {
                        Console.WriteLine("{0} \t{1} \t{2} \t{3}", ++count, student.MaSV, student.TenSV, student.GioiTinh);
                        list_sv.Add(student);
                    }
                    //session.Save(sinhvien1);
                    tx.CommitAsync();//Exception
                }
            }
        }
    }
}
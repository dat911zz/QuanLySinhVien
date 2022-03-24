using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ORM
{
    public class DB_NHibernate : IORM
    {
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Read(ref List<SinhVien> list_sv)
        {
            //NHibernateSetup(ref list_sv);
            var sefact = NHibernateSetup();
            using (var session = sefact.OpenSession())
            {
                //session.Query<SinhVien>("SELECT * FROM SinhVien");
                list_sv = (List<SinhVien>)session.CreateCriteria<SinhVien>().List<SinhVien>();
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

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
        public NHibernate.ISessionFactory NHibernateSetup()
        {
            NHibernateProfiler.Initialize();
            var cfg = new Configuration();
            cfg.Configure($"../../../ORM/hibernate.cfg.xml");
            return cfg.BuildSessionFactory();
        }

    }
}

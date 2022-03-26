using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuanLySinhVien.ORM
{
    /// <summary>
    /// Class for Dapper Library
    /// </summary>
    class DB_Dapper : Utility, IORM
    {
        public void Extract(ref List<SinhVien> list_sv, ref List<MonHoc> list_mh)
        {
            ExtractSinhVien(ref list_sv);
            ExtractMonHoc(ref list_mh);
            ExtractDKHP(ref list_sv, list_mh);
        }
        /// <summary>
        /// Trích xuất bảng SinhVien
        /// </summary>
        /// <param name="list_sv"></param>
        public void ExtractSinhVien(ref List<SinhVien> list_sv)
        {
            string sql = "SELECT * FROM SinhVien";
            using (var conn = new SqlConnection(GenerateConnectionString("", "SinhVien", "test01", "1234")))
            {
                list_sv = conn.Query<SinhVien>(sql).AsList();
            }
        }
        /// <summary>
        /// Trích xuất bảng MonHoc
        /// </summary>
        /// <param name="list_mh"></param>
        public void ExtractMonHoc(ref List<MonHoc> list_mh)
        {
            string sql = "SELECT * FROM MonHoc";
            using (var conn = new SqlConnection(GenerateConnectionString("", "SinhVien", "test01", "1234")))
            {
                list_mh = conn.Query<MonHoc>(sql).AsList();
            }
        }
        /// <summary>
        /// Trích xuất và đăng ký học phần tự động cho sinh viên
        /// </summary>
        /// <param name="list_sv"></param>
        /// <param name="list_mh"></param>
        public void ExtractDKHP(ref List<SinhVien> list_sv, List<MonHoc> list_mh)
        {
            string sql = "SELECT * FROM dkhp";
            using (var conn = new SqlConnection(GenerateConnectionString("", "SinhVien", "test01", "1234")))
            {
                List<DKHP> list_dkhp = conn.Query<DKHP>(sql).AsList();

                for (int i = 0; i < list_dkhp.Count; i++)
                {
                    List<int> tmp1 = new List<int>(list_dkhp[i].ToArray());
                    List<MonHoc> tmp = new List<MonHoc>(list_mh.ToArray());
                    for (int mh_i = 0; mh_i < tmp1.Count; mh_i++)
                    {
                        if (tmp1[mh_i] == 1)
                        {
                            //========Deep copy========= 
                            var c = tmp[mh_i].Clone();
                            list_sv[i].mhdk().Add((MonHoc)c);
                        }
                    }
                }
            }
        }
    }
    public class DKHP
    {
        //Props
        public virtual int C1 { get; set; }
        public virtual int C2 { get; set; }
        public virtual int C3 { get; set; }
        public virtual int C4 { get; set; }
        public virtual int C5 { get; set; }
        public virtual int C6 { get; set; }
        public virtual int C7 { get; set; }
        public virtual int C8 { get; set; }
        public virtual int C9 { get; set; }
        public virtual int C10 { get; set; }
        //Method
        public int[] ToArray()
        {
            return new int[]{ C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 };
        }
    }
}
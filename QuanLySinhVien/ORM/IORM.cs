using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ORM
{
    public interface IORM
    {
        /// <summary>
        /// Read database
        /// </summary>
        /// <param name="list_sv">List of Sinh vien</param>
        public void Read(ref List<SinhVien> list_sv);
        /// <summary>
        /// Update database (Coming soon)
        /// </summary>
        public void Update(ref List<SinhVien> list_sv);
        /// <summary>
        /// Delete database (Coming soon)
        /// </summary>
        public void Delete(ref List<SinhVien> list_sv);
    }
}

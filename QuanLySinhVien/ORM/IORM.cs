using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ORM
{
    public interface IORM
    {
        /// <summary>
        /// Extract database
        /// </summary>
        /// <param name="list_sv">List of Sinh vien</param>
        public void Extract(ref List<SinhVien> list_sv, ref List<MonHoc> list_mh);

        
    }
    
}

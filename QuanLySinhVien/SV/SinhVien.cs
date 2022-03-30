using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QuanLySinhVien.SV;

namespace QuanLySinhVien
{
    /// <summary>
    /// Class for SinhVien
    /// </summary>
    public class SinhVien
    {
        //==================================================================
        //Contructor & Destructor
        public SinhVien() 
        {
            this.Service = new SinhVienService(this);
        }
        public SinhVien(string ma, string ten, string gioitinh, DateTime ngaysinh, string lop, string khoa)
        {
            this.MaSV = ma;
            this.TenSV = ten;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.Lop = lop;
            this.Khoa = khoa;
            this.Service = new SinhVienService(this);
        }
        ~ SinhVien() { }
        //==================================================================
        //Properties
        public virtual string MaSV { get; set; }
        public virtual string TenSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual DateTime NgaySinh  { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }

        protected List<MonHoc> MonHocDK = new List<MonHoc>(5);

        public SinhVienService Service { get; set; }
        //==================================================================
        //Method
        public virtual List<MonHoc> MHDK
        {
            get
            {
                return MonHocDK;
            }
            set
            {
                MonHocDK = value;
            }           
        }
        //Lấy thông tin sinh viên (random, readfile...)
        public virtual void setData(string maSV, string tenSV, string gioiTinh, DateTime ngaySinh, string lop, string khoa)
        {
            MaSV = maSV;
            TenSV = tenSV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            Lop = lop;
            Khoa = khoa;
        }
    }
}

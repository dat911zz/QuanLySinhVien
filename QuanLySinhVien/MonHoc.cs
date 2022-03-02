using System;
using System.Collections.Generic;
using System.Text;

namespace Day01_QuanLySinhVien
{
    /// <summary>
    /// Class of MonHoc
    /// </summary>
    public class MonHoc : ICloneable
    {
        //==================================================================
        //Contructor & Destructor
        public MonHoc() { }
        ~ MonHoc() { }
        //==================================================================
        //Properties
        public string tenMH { get; set; }
        public int soTiet { get; set; }
        private double diemQT { get; set; }
        private double diemTP { get; set; }
        //==================================================================
        //Method
        //Lấy dữ liệu của môn học
        public void setMH(string TenMH, int SoTiet)
        {
            tenMH = TenMH;
            soTiet = SoTiet;
        }
        //Lấy điểm môn học (sinh viên)
        public void setDiemMH(double DiemQT, double DiemTP)
        {
            diemQT = DiemQT;
            diemTP = DiemTP;
        }
        //Form thông tin môn học (quản lý)
        public void showInfoMH()
        {
            Console.Write("\n{0,-21}\t{1,-5}",tenMH, soTiet);
        }
        //Form thông tin môn học sinh viên đã đăng ký (sinh viên)
        public void showInfoMH_DK()
        {
            Console.Write("\nTen mon: {0}\nSo tiet: {1}\n", tenMH, soTiet);
        }
        //Form thông tin môn học sinh viên đã đăng ký kèm điểm (sinh viên)
        public void showInfoMH_SV()
        {
            Console.Write("\t{0,-21}\t{1}\t\t{2}\t{3}\t{4}\t{5}",tenMH,soTiet,diemTP,diemQT,diemTongKet(), (isPass() == true ? "Dau" : "Rot"));
        }
        //Tính điểm tổng kết
        public double diemTongKet()
        {
            return (diemQT + diemTP) / 2;
        }
        //Kiểm tra sinh viên đậu hay rớt môn đã chọn
        public bool isPass()
        {
            return diemTongKet() >= 4;
        }
        //Nhập điểm môn học
        public void inputScoreMH()
        {
            var tmp = 0.0;
        checkpoint1:
            Console.Write("\nNhap diem thanh phan: ");
            if (double.TryParse(Console.ReadLine(), out tmp) == false)
            {
                Console.Write("Vui long nhap lai!");
                goto checkpoint1;
            }
            else
            {
                if (tmp < 0 || tmp > 10)
                {
                    Console.Write("Vui long nhap lai!");
                    goto checkpoint1;
                }
            }
            diemTP = tmp;
        checkpoint2:
            Console.Write("\nNhap diem qua trinh: ");
            if (double.TryParse(Console.ReadLine(), out tmp) == false)
            {
                Console.Write("Vui long nhap lai!");
                goto checkpoint2;
            }
            else
            {
                if (tmp < 0 || tmp > 10)
                {
                    Console.Write("Vui long nhap lai!");
                    goto checkpoint2;
                }
            }
            diemQT = tmp;
        }

        //------------------------
        // This is a deep copy implementation of Clone
        public object Clone()
        {
            return new MonHoc
            {
                tenMH = this.tenMH,
                soTiet = this.soTiet,
                diemTP = this.diemTP,
                diemQT = this.diemQT,
            };
        }
    }
}

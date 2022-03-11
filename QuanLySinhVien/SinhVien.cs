using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLySinhVien
{
    /// <summary>
    /// Class for SinhVien
    /// </summary>
    public class SinhVien : Viewer
    {
        //==================================================================
        //Contructor & Destructor
        public SinhVien() { }
        ~ SinhVien() { }
        //==================================================================
        //Properties
        private string MaSV { get; set; }
        private string TenSV { get; set; }
        private string GioiTinh { get; set; }
        private DateTime NgaySinh  { get; set; }
        private string Lop { get; set; }
        private string Khoa { get; set; }

        public List<MonHoc> MonHocDK = new List<MonHoc>();  
        //==================================================================
        //Method

        /// <summary>
        /// Get info of SinhVien
        /// </summary>
         
        //Nhập thông tin sinh viên (thủ công)
        public void setData()
        {
            Console.WriteLine("-Nhap thong tin cua sinh vien-");
            Console.Write("\nMa sinh vien: ");
            MaSV = Convert.ToString(Console.ReadLine());
            Console.Write("\nHo ten: ");
            TenSV = Convert.ToString(Console.ReadLine());
            Console.Write("\nGioi tinh: ");
            GioiTinh = Convert.ToString(Console.ReadLine());
            
            DateTime date = new DateTime();
            bool flag;
            do
            {
                Console.Write("\nNhap ngay sinh(mm/dd/yy) :");//theo thứ tự tháng/ngày/năm
                flag = DateTime.TryParse(Console.ReadLine(), out date);               
                if (flag == false)
                {
                    Console.WriteLine("KHONG DUNG DINH DANG, VUI LONG NHAP LAI!");
                }

            } while (flag == false);
            NgaySinh = date;
            Console.Write("\nLop: ");
            Lop = Convert.ToString(Console.ReadLine());
            Console.Write("\nKhoa: ");
            Khoa = Convert.ToString(Console.ReadLine());
        }
        //Lấy thông tin sinh viên (random, readfile...)
        public void setData(string maSV, string tenSV, string gioiTinh, DateTime ngaySinh, string lop, string khoa)
        {
            MaSV = maSV;
            TenSV = tenSV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            Lop = lop;
            Khoa = khoa;
        }
        //Trả về tên sinh viên
        public string getTenSV()
        {
            return TenSV;
        }
        //Xuất thông tin sinh viên
        public void getInfoSV()
        {
            Console.Write($"\nMSSV: {MaSV}\nHo ten: {TenSV}\nGioi tinh: {GioiTinh}\nNgay sinh: {NgaySinh.ToShortDateString()}\nLop: {Lop}\nKhoa: {Khoa}\n");
        }
        //Đăng ký môn học
        public void dangKyMonHoc(List<MonHoc> list_MH)
        {
            string pick;
            showCurrentListMH(list_MH);
            Console.WriteLine();
            DuongKe();
            Console.Write("\n-Dang Ky Mon Hoc-");
            foreach (var item in list_MH)
            {
                item.showInfoMH_DK();
                Console.Write("\nDang ky? (Y/N): ");
                pick = Console.ReadLine();
                if (pick == "Y" || pick == "y")
                {
                    MonHocDK.Add(item);
                }
            }
            showMonHocDaDK();

        }
        //Xuất danh sách môn học sinh viên đã đăng ký
        public void showMonHocDaDK()
        {
            Console.Write("\n\t---Cac mon hoc da dang ky---\n");
            Console.Write($"\nSo luong: {MonHocDK.Count}\n");
            DuongKe();
            showCurrentListMH(MonHocDK);
        }
        //Tìm môn học trong danh sách đã đăng ký
        public MonHoc searchMonHocDaDK(string name)
        {
            foreach (var item in MonHocDK)
            {
                if (string.Equals(item.tenMH, name) == true)
                {
                    return item;
                }
            }
            return null;
        }
        //Nhập điểm cho sinh viên
        public void inputScoreSV()
        {
            MonHoc x;
            string name, flag;
        retype:
            Console.Clear();
            showMonHocDaDK();
            Console.Write("\nVui long nhap ten mon hoc can nhap diem: ");
            name = Console.ReadLine();
            x = searchMonHocDaDK(name);
            if (x == null)
            {
                Console.Write("\nVui long nhap lai!");
                goto retype;
            }
            Console.Write("\n\t-=Thong tin cua sinh vien=-");
            x.inputScoreMH();
            Console.Write("\nBan co muon nhap diem mon khac (Y/N): ");
            flag = Console.ReadLine();
            if (flag == "Y" || flag == "y")
            {
                goto retype;
            }
        }
        //Xuất thông tin sinh viên (theo hàng ngang)
        public void showData()
        {
            Console.Write("\n{0,-11}\t{1,-18}\t{2,-3}\t{3}/{4}/{5}\t{6,-11}\t{7}", this.MaSV, this.TenSV, this.GioiTinh, this.NgaySinh.Day, this.NgaySinh.Month, this.NgaySinh.Year, this.Lop, this.Khoa);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    public class DKHP
    {
        //Props
        public virtual int STT { get; set; }
        public virtual string MaSV { get; set; }
        public virtual int MH1 { get; set; }
        public virtual int MH2 { get; set; }
        public virtual int MH3 { get; set; }
        public virtual int MH4 { get; set; }
        public virtual int MH5 { get; set; }
        public virtual int MH6 { get; set; }
        public virtual int MH7 { get; set; }
        //Method
        public int[] ToArray()
        {
            return new int[] { MH1, MH2, MH3, MH4, MH5, MH6, MH7 };
        }
    }
}

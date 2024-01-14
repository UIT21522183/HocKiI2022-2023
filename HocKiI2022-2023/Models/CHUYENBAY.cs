namespace HocKiI2022_2023.Models
{
    public class CHUYENBAY
    {
        public string MaCH { get; set; }
        public string Chuyen { get; set; }
        public string DDi { get; set; }
        public string DDen { get; set; }
        public string Ngay { get; set; }
        public string GBay { get; set; }
        public string GDen { get; set; }
        public int Thuong { get; set; }
        public int Vip { get; set; }
        public string MaMB { get; set; }
        public CHUYENBAY() { }
        public CHUYENBAY(string MaCH = "", string Chuyen = "",
                string DDi = "", string DDen = "",string Ngay="",string GBay="",string GDen="",int Thuong=0,int Vip=0,string MaMB="")
        {
            this.MaCH = MaCH;
            this.Chuyen = Chuyen;
            this.DDi = DDi; 
            this.DDen = DDen;
            this.Ngay = Ngay;
            this.GBay = GBay;
            this.GDen = GDen;
            this.MaMB = MaMB;
            this.Thuong = Thuong;
            this.Vip = Vip;
        }
    }
}

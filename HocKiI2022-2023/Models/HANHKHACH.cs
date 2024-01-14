namespace HocKiI2022_2023.Models
{
    public class HANHKHACH
    {
        public string MaHK { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public HANHKHACH() { }
        public HANHKHACH(string MaHK   ="", string HoTen="",
                string DiaChi = "", string DienThoai="")
        {
            this.MaHK = MaHK;
            this.HoTen = HoTen;
            this.DiaChi = DiaChi;
            this.DienThoai= DienThoai;
        }
    }
}

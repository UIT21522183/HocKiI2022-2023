namespace HocKiI2022_2023.Models
{
    public class CT_CB
    {
        public string MaHK { get; set; }
        public string MaCH { get; set; }
        public string SoGhe { get; set; }
        public bool LoaiGhe { get; set; }

        public CT_CB() { }
        public CT_CB(string MaHK = "", string MaCH = "",
                string SoGhe = "", bool LoaiGhe = false)
        {
            this.MaHK = MaHK;
            this.MaCH = MaCH;
            this.SoGhe = SoGhe;
            this.LoaiGhe = LoaiGhe;
        }
    }
}

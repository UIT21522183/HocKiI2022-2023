namespace HocKiI2022_2023.Models
{
    public class MAYBAY
    {
        public string MaMB { get; set; }
        public string HangMB { get; set; }
        public int SoCho { get; set; }
        public MAYBAY() { }
        public MAYBAY(string MaMB = "", string HangMB = "",
                int SoCho = 0)
        {
            this.MaMB = MaMB;
            this.HangMB = HangMB;
            this.SoCho = SoCho;
        }
    }
}

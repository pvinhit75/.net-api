namespace API_WebApp.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHh { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }    
        public int DonGia { get; set; }
        public int GiamGia { get; set; }

        //Relasionship
        public DonHang DonHang { get; set; }    
        public HangHoa HangHoa { get; set; }    


    }
}

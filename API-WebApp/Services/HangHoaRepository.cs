using API_WebApp.Data;
using API_WebApp.Models;
using System.Globalization;

namespace API_WebApp.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDBContext _context;
        private static int PAGE_SIZE {get; set;} = 5;

        public HangHoaRepository(MyDBContext context)
        {
            _context = context;
        }
        List<HangHoaModel> IHangHoaRepository.GetAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
           var allProducts = _context.HangHoas.AsQueryable();
            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = _context.HangHoas.Where(hh => hh.TenHh.Contains(search));

            }
           if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.TenHh);
            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(hh => hh.TenHh); 
                        break;
                    case "gia_asc": allProducts = allProducts.OrderBy(hh => hh.TenHh); 
                        break;
                    case "gia_desc": allProducts = allProducts.OrderByDescending(hh => hh.DonGia);
                        break;

                }
            }
            #region Paging
            allProducts = allProducts.Skip((page-1) * PAGE_SIZE).Take(PAGE_SIZE);   
            #endregion
            var result = allProducts.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                Dongia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });

            return result.ToList();
        }
    }
}

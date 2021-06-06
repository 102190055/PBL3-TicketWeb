using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;

namespace TicketWeb.Models
{
    public class FlightIndexViewModel
    {
        public string searchSanBayDi_ID { get; set; }
        public string searchSanBayDen_ID { get; set; }
        public string searchMaChuyenBay { get; set; }
        public string searchThoiGianDuKienBay { get; set; }
        public string searchSoGhe { get; set; }
        public string searchMayBayID { get; set; }
        public List<TicketWeb.Data.ChuyenBay> ChuyenBay { get; set; } = new List<ChuyenBay>();
    }
}

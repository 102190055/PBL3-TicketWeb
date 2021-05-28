using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketWeb.Data
{
    public class ChuyenBay 
    {
        [Required(ErrorMessage ="Bạn cần điền thông tin vào đây")]
        [Display(Name ="ID")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Mã chuyến bay")]
        public string MaChuyenBay { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID-Sân bay đi ")]
        public int SanBayDi_ID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID-Sân bay đến")]
        public int SanBayDen_ID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Thời gian dự kiến bay")]
        public DateTime ThoiGianDuKienBay { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Số ghế hạng 1")]
        public int SoGhe_Hang1 { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Số ghế hạng 2")]
        public int SoGhe_Hang2 { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID Máy bay")]
        public int MayBayID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Giá vé")]
        public decimal GiaVe { get; set; }

        [NotMapped]
        public string SanBayDen { get; set; }
        [NotMapped]
        public string SanBayDi { get; set; }
    }
    
    
}

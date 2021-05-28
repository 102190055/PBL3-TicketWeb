using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketWeb.Models
{
    public class VeMayBay
    {
        //[Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID ")]
        public int ID { get; set; }
        //[Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID-Chuyến bay")]
        public int ChuyenBay_ID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Tên Khách")]
        public string TenKhach { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Số điện thoại ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Email")]
        public string  Email { get; set; }
        //[Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID-Người đặt")]
        public string NguoiDat_ID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Giá vé")]
        public decimal GiaVe { get; set; }

    }
}

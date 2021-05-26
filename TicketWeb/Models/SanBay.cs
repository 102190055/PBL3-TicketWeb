using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketWeb.Data
{
    public class SanBay
    {
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name="ID")]
        public int ID { get; set; }
        [Display(Name ="Code")]
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name ="Tên sân bay")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Tên khu vực")]
        public string KhuVuc { get; set; }
    }
}

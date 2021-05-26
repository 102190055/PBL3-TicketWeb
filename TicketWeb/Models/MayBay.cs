using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketWeb.Models
{
    public class MayBay
    {
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "ID ")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Code")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Bạn cần điền thông tin vào đây")]
        [Display(Name = "Tên máy bay")]
        public string Name { get; set; }
    }
}

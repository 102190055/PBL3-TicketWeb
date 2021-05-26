using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Areas.Identity.Data;

namespace TicketWeb.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<TicketWebUser> Members { get; set; }
        public IEnumerable<TicketWebUser> NonMembers { get; set; }
    }
}

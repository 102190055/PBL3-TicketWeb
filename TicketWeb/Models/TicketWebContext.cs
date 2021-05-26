using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using TicketWeb.Areas.Identity.Data;
using TicketWeb.Models;

namespace TicketWeb.Data
{
    public partial class TicketWebContext : IdentityDbContext<TicketWebUser>
    {
        public TicketWebContext(DbContextOptions<TicketWebContext> options)
            : base(options)
        {
        }
        public DbSet<SanBay> SanBay { get; set; }
        public DbSet<ChuyenBay> ChuyenBays { get; set; }
        public DbSet<MayBay> MayBay { get; set; }
        public DbSet<VeMayBay> VeMayBay { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}

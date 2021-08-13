using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;
using TicketWeb.Models;
using Microsoft.AspNetCore.Identity;
using TicketWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketWeb.Views.BookTicket
{
    public class BookTicketController : Controller
    {
        private UserManager<TicketWebUser> _userManager;
        private TicketWebContext _dbContext;

        public BookTicketController(TicketWebContext dbCOntext, UserManager<TicketWebUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbCOntext;
        }
        // GET: BookTicketController
        public ActionResult Index(int start, int end,string ngaydi)
        {
            var sanbaydi = _dbContext.SanBay.FirstOrDefault(x => x.ID == start)?.KhuVuc;
            var sanbayden = _dbContext.SanBay.FirstOrDefault(x => x.ID == end)?.KhuVuc;

            CultureInfo enUS = new CultureInfo("en-US");
            var ngayDuKien = DateTime.Now;
            DateTime.TryParseExact(ngaydi, "dd/MM/yyyy", enUS, DateTimeStyles.None, out ngayDuKien);
            
            var listFlight = _dbContext.ChuyenBays.Where(s => (s.SanBayDi_ID == start) && (s.SanBayDen_ID == end) && (s.ThoiGianDuKienBay.Date.Date >= ngayDuKien.Date && s.ThoiGianDuKienBay.Date.Date < ngayDuKien.Date.AddDays(1)))
                                .Select(x => new ChuyenBay
                                {
                                    MaChuyenBay = x.MaChuyenBay,
                                    MayBayID = x.MayBayID,
                                    SanBayDen = sanbayden,
                                    SanBayDen_ID = end,
                                    SanBayDi = sanbaydi,
                                    SanBayDi_ID = start,
                                    SoGhe = x.SoGhe,                                    
                                    ThoiGianDuKienBay = x.ThoiGianDuKienBay,
                                    ID = x.ID,
                                    GiaVe = x.GiaVe
                                });
            return View(listFlight.ToList());
        }


        public ActionResult Booking(int chuyenbayid,int start,int end)
        {
            var sanbaydi = _dbContext.SanBay.FirstOrDefault(x => x.ID == start)?.KhuVuc;
            var sanbayden = _dbContext.SanBay.FirstOrDefault(x => x.ID == end)?.KhuVuc;
            var ChuyenBays = _dbContext.ChuyenBays.Where(x => x.ID == chuyenbayid);
            var SanBayDI = ChuyenBays.Select(x => new SelectListItem
            {
                Text = sanbaydi,
            }).ToList();
            ViewBag.SanBayDi = SanBayDI;
            //
            var SanBayDen = ChuyenBays.Select(x => new SelectListItem
            {
                Text = sanbayden,
            }).ToList();
            ViewBag.SanBayDen = SanBayDen;
            //
            var GiaVe = ChuyenBays.Select(x => new SelectListItem
            {
                Text = x.GiaVe.ToString(),
            }).ToList();
            ViewBag.GiaVe = GiaVe;
            //
            var chuyenbay = _dbContext.ChuyenBays.FirstOrDefault(x => x.ID == chuyenbayid);
            var vemaybay = new VeMayBay();
            vemaybay.ChuyenBay_ID = chuyenbayid;
            vemaybay.GiaVe = chuyenbay.GiaVe;

            return View(vemaybay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(VeMayBay model)
        {
            if (ModelState.IsValid)
            {
                var id = _userManager.GetUserId(this.User);
                model.NguoiDat_ID = id;
                _dbContext.VeMayBay.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Payment));
            }
            return View();
        }

        public ActionResult Payment(int chuyenbayid)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Success(int id)
        {
            return View();
        }

    }
}

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
                                    SoGhe_Hang1 = x.SoGhe_Hang1,
                                    SoGhe_Hang2 = x.SoGhe_Hang2,
                                    ThoiGianDuKienBay = x.ThoiGianDuKienBay,
                                    ID = x.ID,
                                    GiaVe = x.GiaVe
                                });
            return View(listFlight.ToList());
        }

        // GET: BookTicketController/Create
        public ActionResult Booking(int chuyenbayid)
        {
            var chuyenbay = _dbContext.ChuyenBays.FirstOrDefault(x => x.ID == chuyenbayid);
            var vemaybay = new VeMayBay();
            vemaybay.ChuyenBay_ID = chuyenbayid;
            vemaybay.GiaVe = chuyenbay.GiaVe;

            return View(vemaybay);
        }

        // POST: BookTicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(VeMayBay model)
        {
            if (ModelState.IsValid)
            {
                //model.ChuyenBay_ID = id;
                //model.NguoiDat_ID = _dbContext.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId());
                var id = _userManager.GetUserId(this.User);
                model.NguoiDat_ID = id;
                //model.GiaVe = 0;
                _dbContext.VeMayBay.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Payment));
            }
            return View();
        }

        public ActionResult Payment(int id)
        {
            return View();
        }
        public ActionResult Success(int id)
        {
            return View();
        }


        // GET: BookTicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookTicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

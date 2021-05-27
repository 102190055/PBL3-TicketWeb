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

namespace TicketWeb.Views.BookTicket
{
    public class BookTicketController : Controller
    {
        private TicketWebContext _dbContext;

        public BookTicketController(TicketWebContext dbCOntext)
        {
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
                                    ID = x.ID
                                });
            return View(listFlight.ToList());
        }

        // GET: BookTicketController/Create
        public ActionResult Booking()
        {
            return View();
        }

        // POST: BookTicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(VeMayBay model,int id,string InputName,string InputBirth,string InputPhone,string InputEmail)
        {
            if (ModelState.IsValid)
            {
                model.ChuyenBay_ID = id;
                model.TenKhach = InputName;
                model.NgaySinh = DateTime.ParseExact(InputBirth,"dd/MM//yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.PhoneNumber = InputPhone;
                model.Email = InputEmail;
                model.NguoiDat_ID = "null";
                _dbContext.VeMayBay.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Pay));
            }
            return View();
        }

        // GET: BookTicketController/Edit/5
        public ActionResult Pay(int id)
        {
            return View();
        }

        // POST: BookTicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(int id, IFormCollection collection)
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

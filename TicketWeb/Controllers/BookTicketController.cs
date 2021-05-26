using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;

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
            var sanbaydi = _dbContext.SanBay.FirstOrDefault(x => x.ID == start)?.Name;
            var sanbayden = _dbContext.SanBay.FirstOrDefault(x => x.ID == end)?.Name;

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
                                    ThoiGianDuKienBay = ngayDuKien,
                                    ID = x.ID
                                });
            return View(listFlight.ToList());
        }

        // GET: BookTicketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookTicketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookTicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BookTicketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookTicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

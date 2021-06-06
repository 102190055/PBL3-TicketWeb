using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;
using TicketWeb.Models;

namespace TicketWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FlightController : Controller
    {
        private TicketWebContext _dbContext;

        public FlightController(TicketWebContext dbCOntext)
        {
            _dbContext = dbCOntext;
        }
        

        public ActionResult Index(FlightIndexViewModel model)
        {
            var SanBayDilist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDilist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDilist.AddRange(SanBayDilist2);
            ViewBag.SanBayDi = SanBayDilist;

            var SanBayDenlist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDenlist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDenlist.AddRange(SanBayDenlist2);
            ViewBag.SanBayDen = SanBayDenlist;

            var Maybaylist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var Maybaylist2 = _dbContext.MayBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            Maybaylist.AddRange(Maybaylist2);
            ViewBag.MayBay = Maybaylist;


            var listFlight = _dbContext.ChuyenBays.AsQueryable();
            if (!string.IsNullOrEmpty(model.searchMaChuyenBay))
            {
                listFlight = listFlight.Where(s => s.MaChuyenBay.StartsWith(model.searchMaChuyenBay));
            }

            if (!string.IsNullOrEmpty(model.searchSanBayDen_ID))
            {
                listFlight = listFlight.Where(s => s.SanBayDen_ID.ToString() == model.searchSanBayDen_ID);
            }

            if (!string.IsNullOrEmpty(model.searchSanBayDi_ID))
            {
                listFlight = listFlight.Where(s => s.SanBayDi_ID.ToString() == model.searchSanBayDi_ID);
            }

            if (!string.IsNullOrEmpty(model.searchThoiGianDuKienBay))
            {
                CultureInfo enUS = new CultureInfo("en-US");
                var ngayDuKien = DateTime.Now;
                if (DateTime.TryParseExact(model.searchThoiGianDuKienBay, "dd/MM/yyyy", enUS, DateTimeStyles.None, out ngayDuKien))
                {
                    listFlight = listFlight.Where(s => s.ThoiGianDuKienBay.Date.Date >= ngayDuKien.Date && s.ThoiGianDuKienBay.Date.Date < ngayDuKien.Date.AddDays(1));
                }
            }

            if (!string.IsNullOrEmpty(model.searchSoGhe))
            {
                listFlight = listFlight.Where(s => s.SoGhe.ToString() == model.searchSoGhe);
            }
            if (!string.IsNullOrEmpty(model.searchMayBayID))
            {
                listFlight = listFlight.Where(s => s.MayBayID.ToString() == model.searchMayBayID);
            }
            model.ChuyenBay = listFlight.ToList();
            return View(model);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            var SanBayDilist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDilist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDilist.AddRange(SanBayDilist2);
            ViewBag.SanBayDi = SanBayDilist;

            var SanBayDenlist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDenlist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDenlist.AddRange(SanBayDenlist2);
            ViewBag.SanBayDen = SanBayDenlist;

            var Maybaylist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var Maybaylist2 = _dbContext.MayBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            Maybaylist.AddRange(Maybaylist2);
            ViewBag.MayBay = Maybaylist;
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChuyenBay collection)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ChuyenBays.Add(collection);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var SanBayDilist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDilist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDilist.AddRange(SanBayDilist2);
            ViewBag.SanBayDi = SanBayDilist;

            var SanBayDenlist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDenlist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDenlist.AddRange(SanBayDenlist2);
            ViewBag.SanBayDen = SanBayDenlist;

            var Maybaylist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var Maybaylist2 = _dbContext.MayBay.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            Maybaylist.AddRange(Maybaylist2);
            ViewBag.MayBay = Maybaylist;

            var editing = _dbContext.ChuyenBays.Find(id);
            return View(editing);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChuyenBay model)
        {
            try
            {
                var oldItem = _dbContext.ChuyenBays.Find(model.ID);
                oldItem.ID = model.ID;
                oldItem.MaChuyenBay = model.MaChuyenBay;
                oldItem.MayBayID = model.MayBayID;
                oldItem.SanBayDen_ID = model.SanBayDen_ID;
                oldItem.SanBayDi_ID = model.SanBayDi_ID;
                oldItem.SoGhe = model.SoGhe;
                oldItem.ThoiGianDuKienBay = model.ThoiGianDuKienBay;
                oldItem.GiaVe = model.GiaVe;
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleting = _dbContext.ChuyenBays.Find(id);
            return View(deleting);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleting = _dbContext.ChuyenBays.Find(id);
            if (deleting == null)
            {
                return View();
            }
            else
            {
                _dbContext.ChuyenBays.Remove(deleting);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

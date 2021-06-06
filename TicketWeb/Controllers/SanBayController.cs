using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;

namespace TicketWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SanBayController : Controller
    {
        private TicketWebContext _dbContext;

        public SanBayController(TicketWebContext dbCOntext)
        {
            _dbContext = dbCOntext;
        }
        // GET: SanBayController
        public ActionResult Index()
        {
            var ListMayBay = _dbContext.SanBay.ToList();
            return View(ListMayBay);
        }
        // GET: SanBayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanBayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanBay collection)
        {
            if (ModelState.IsValid)
            {
                _dbContext.SanBay.Add(collection);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: SanBayController/Edit/5
        public ActionResult Edit(int id)
        {
            var editing = _dbContext.SanBay.Find(id);
            return View(editing);
        }

        // POST: SanBayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanBay model)
        {
            try
            {
                var oldItem = _dbContext.SanBay.Find(model.ID);
                oldItem.ID = model.ID;
                oldItem.Code = model.Code;
                oldItem.Name = model.Name;
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanBayController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleting = _dbContext.SanBay.Find(id);
            return View(deleting);
        }

        // POST: SanBayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleting = _dbContext.SanBay.Find(id);
            if (deleting == null)
            {
                return View();
            }
            else
            {
                _dbContext.SanBay.Remove(deleting);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

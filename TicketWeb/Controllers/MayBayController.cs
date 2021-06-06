using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;
using TicketWeb.Models;

namespace TicketWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MayBayController : Controller
    {
        private TicketWebContext _dbContext;

        public MayBayController(TicketWebContext dbCOntext)
        {
            _dbContext = dbCOntext;
        }
        // GET: MayBayController
        public ActionResult Index()
        {
            var ListMayBay = _dbContext.MayBay.ToList();
            return View(ListMayBay);
        }
        // GET: MayBayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MayBayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MayBay collection)
        {
            if (ModelState.IsValid)
            {
                _dbContext.MayBay.Add(collection);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: MayBayController/Edit/5
        public ActionResult Edit(int id)
        {
            var editing = _dbContext.MayBay.Find(id);
            return View(editing);
        }

        // POST: MayBayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MayBay model)
        {
            try
            {
                var oldItem = _dbContext.MayBay.Find(model.ID);
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

        // GET: MayBayController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleting = _dbContext.MayBay.Find(id);
            return View(deleting);
        }

        // POST: MayBayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleting = _dbContext.MayBay.Find(id);
            if (deleting == null)
            {
                return View();
            }
            else
            {
                _dbContext.MayBay.Remove(deleting);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

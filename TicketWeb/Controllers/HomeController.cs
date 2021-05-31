using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicketWeb.Data;
using TicketWeb.Models;

namespace TicketWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private TicketWebContext _dbContext;
        public HomeController(TicketWebContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var SanBayDilist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDilist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name + " / " + x.KhuVuc,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDilist.AddRange(SanBayDilist2);
            ViewBag.SanBayDi = SanBayDilist;

            var SanBayDenlist = new List<SelectListItem>() { new SelectListItem { Text = "", Value = "" } };
            var SanBayDenlist2 = _dbContext.SanBay.Select(x => new SelectListItem
            {
                Text = x.Name + " / " + x.KhuVuc,
                Value = x.ID.ToString()
            }).ToList();
            SanBayDenlist.AddRange(SanBayDenlist2);
            ViewBag.SanBayDen = SanBayDenlist;

            return View();
        }
        public IActionResult lienhe()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

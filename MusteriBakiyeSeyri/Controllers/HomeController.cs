using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusteriBakiyeSeyri.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriBakiyeSeyri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MusteriBankDbContext _ctx;
        public HomeController(ILogger<HomeController> logger, MusteriBankDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.musteriler = _ctx.musteri_tanim_table.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int selectedMusteriId)
        {
            ViewBag.musteriler = _ctx.musteri_tanim_table.ToList();
            var faturalar = _ctx.musteri_fatura_table.Where(c => c.MUSTERI_ID == selectedMusteriId).ToList();

            List<DateTime> faturaTarihleri = faturalar.Select(c => c.FATURA_TARIHI).Distinct().ToList();
            decimal maxBorc = 0;
            DateTime maxBorcluTarih = new DateTime();
            foreach (var tar in faturaTarihleri)
            {
                var odenmemisFaturalar = faturalar.Where(c => c.FATURA_TARIHI <= tar && c.ODEME_TARIHI > tar);
                decimal toplamBorc = odenmemisFaturalar.Sum(c => c.FATURA_TUTARI);
                if (maxBorc < toplamBorc)
                {
                    maxBorc = toplamBorc;
                    maxBorcluTarih = tar;
                }
            }
            ViewBag.maxBorcTar = maxBorcluTarih;
            ViewBag.maxBorc = maxBorc;
            return View();
        }

        [HttpPost]
        public IActionResult IndexBySp(int selectedMusteriId)
        {
            ViewBag.musteriler = _ctx.musteri_tanim_table.ToList();

            var maxVals = _ctx.SPSonuclar.FromSqlInterpolated($"GetMaxBorcAndDate {selectedMusteriId}").ToList();
            ViewBag.maxBorcTar = maxVals.First().FATURA_TARIHI;
            ViewBag.maxBorc = maxVals.First().toplamBorc;
            return View("Index");
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

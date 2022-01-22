using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WDPR.Models;

namespace WDPR.Controllers
{
    public class OrthopedagogenController : Controller
    {

        private readonly MyContext _context;

        public OrthopedagogenController(MyContext context)
        {
            _context = context;
        }


        [Route("/Orthopedagogen")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Orthopedagogen = _context.Hulpverlener;
            return View();
        }

        [Route("/Orthopedagogen")]
        [HttpPost]
        public IActionResult Index(string VoorNaam)
        {
            ViewBag.zoekterm = VoorNaam;
            if(VoorNaam != null){
                ViewBag.Orthopedagogen = _context.Hulpverlener.Where(x => x.VoorNaam.Contains(VoorNaam) || x.achterNaam.Contains(VoorNaam));
            }
            else{
                ViewBag.Orthopedagogen = _context.Hulpverlener;
            }
            
            return View("Index");
        }

        
    }
}

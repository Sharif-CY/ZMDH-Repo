using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WDPR.Models;
using Microsoft.AspNetCore.Authorization;


namespace WDPR.Controllers
{
    public class ModeratorController : Controller
    {

        [Authorize(Roles = "Moderator")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

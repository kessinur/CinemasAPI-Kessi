using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemas.API.Client.Controllers
{
    public class TheatersController : Controller
    {
        // GET: Theaters
        public ActionResult Index()
        {
            return View();
        }
    }
}
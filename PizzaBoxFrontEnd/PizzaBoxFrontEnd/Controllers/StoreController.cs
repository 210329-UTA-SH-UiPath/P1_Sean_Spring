using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxFrontEnd.Controllers
{
    public class StoreController : Controller
    {
        // GET: StoreController
        public ActionResult Index()
        {
            return View();
        }

        
    }
}

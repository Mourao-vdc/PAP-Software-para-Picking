﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ArtigosController : Controller
    {
        // GET: Artigos
        public ActionResult Index()
        {
            return View();
        }
    }
}
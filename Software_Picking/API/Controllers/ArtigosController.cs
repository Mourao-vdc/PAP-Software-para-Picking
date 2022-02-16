using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        public HttpResponseMessage GetArtigos()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Models.Artigos.GetArtigos());

        }
    }
}
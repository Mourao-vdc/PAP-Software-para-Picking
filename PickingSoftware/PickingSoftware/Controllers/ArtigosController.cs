﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Artigos")]
    public class ArtigosController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetArtigos()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Models.Artigos.GetArtigos());
        }
    }
}
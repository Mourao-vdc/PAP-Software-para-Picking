using System;
using System.Net;
using System.Net.Http;
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
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Artigos.GetArtigos());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Artigos artigos)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Artigos.GetArtigos());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
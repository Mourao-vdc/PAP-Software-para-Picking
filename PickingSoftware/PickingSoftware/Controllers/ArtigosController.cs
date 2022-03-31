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
                Models.Artigos.GetAdicionar(artigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPost]
        public HttpResponseMessage GetEditar(Models.Artigos artigos)
        {
            try
            {
                Models.Artigos.GetEditar(artigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar")]
        [HttpPost]
        public HttpResponseMessage GetEliminar(Models.Artigos artigos)
        {
            try
            {
                Models.Artigos.GetEliminar(artigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
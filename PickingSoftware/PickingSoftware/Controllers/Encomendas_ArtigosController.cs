using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Encomendas_Artigos")]
    public class EncomendasArtigosController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetEncomendas_Artigos()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas_Artigos.GetEncomendas_Artigos());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                Models.Encomendas_Artigos.GetAdicionar(_encomendasartigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                Models.Encomendas_Artigos.GetEditar(_encomendasartigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                Models.Encomendas_Artigos.GetEliminar(_encomendasartigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
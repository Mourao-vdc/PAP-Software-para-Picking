using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Encomendas")]
    public class EncomendasController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetEncomendas()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas.GetEncomendas());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Encomendas _encomendas)
        {
            try
            {
                Models.Encomendas.GetAdicionar(_encomendas);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Encomendas _encomendas)
        {
            try
            {
                Models.Encomendas.GetEditar(_encomendas);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar/{id}")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(int id)
        {
            try
            {
                Models.Encomendas.GetEliminar(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
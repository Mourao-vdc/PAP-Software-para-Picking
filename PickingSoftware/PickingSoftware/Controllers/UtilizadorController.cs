using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Utilizador")]
    public class UtilizadorController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetUtilizadores()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Utilizador.GetUtilizadores());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Utilizador _utilizador)
        {
            try
            {
                Models.Utilizador.GetAdicionar(_utilizador);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Utilizador _utilizador)
        {
            try
            {
                Models.Utilizador.GetEditar(_utilizador);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(Models.Utilizador _utilizador)
        {
            try
            {
                Models.Utilizador.GetEliminar(_utilizador);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
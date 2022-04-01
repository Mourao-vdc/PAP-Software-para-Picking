using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Grupos")]
    public class GruposController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetGrupos()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Grupos.GetGrupos());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Grupos _grupos)
        {
            try
            {
                Models.Grupos.GetAdicionar(_grupos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Grupos _grupos)
        {
            try
            {
                Models.Grupos.GetEditar(_grupos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(Models.Grupos _grupos)
        {
            try
            {
                Models.Grupos.GetEliminar(_grupos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
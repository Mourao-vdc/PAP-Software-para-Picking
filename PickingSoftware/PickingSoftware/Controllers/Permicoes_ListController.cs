using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Permicoes_List")]
    public class PermicoesListController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetPermicoes_List()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Permicoes_List.GetPermicoes_List());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Permicoes_List _permicoeslist)
        {
            try
            {
                Models.Permicoes_List.GetAdicionar(_permicoeslist);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Permicoes_List _permicoeslist)
        {
            try
            {
                Models.Permicoes_List.GetEditar(_permicoeslist);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(Models.Permicoes_List _permicoeslist)
        {
            try
            {
                Models.Permicoes_List.GetEliminar(_permicoeslist);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
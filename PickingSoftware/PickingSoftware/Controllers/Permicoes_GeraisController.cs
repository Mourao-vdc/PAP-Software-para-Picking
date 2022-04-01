using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Permicoes_Gerais")]
    public class PermicoesGeraisController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        public HttpResponseMessage GetPermicoes_Gerais()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Permicoes_Gerais.GetPermicoes_Gerais());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Permicoes_Gerais _permicoesgerais)
        {
            try
            {
                Models.Permicoes_Gerais.GetAdicionar(_permicoesgerais);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Permicoes_Gerais _permicoesgerais)
        {
            try
            {
                Models.Permicoes_Gerais.GetEditar(_permicoesgerais);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Eliminar")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(Models.Permicoes_Gerais _permicoesgerais)
        {
            try
            {
                Models.Permicoes_Gerais.GetEliminar(_permicoesgerais);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
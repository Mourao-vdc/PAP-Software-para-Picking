using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Permissoes_Gerais")]
    public class PermissoesGeraisController : ApiController
    {
        [Route("Todas")]
        [HttpGet]
        //[Authorize]
        public HttpResponseMessage GetPermicoes_Gerais(string _nome)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Permissoes_Gerais.GetPermicoes_Gerais(_nome));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Permissoes_Gerais _permicoesgerais)
        {
            try
            {
                Models.Permissoes_Gerais.GetAdicionar(_permicoesgerais);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Permissoes_Gerais _permicoesgerais)
        {
            try
            {
                Models.Permissoes_Gerais.GetEditar(_permicoesgerais);
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
                Models.Permissoes_Gerais.GetEliminar(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
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
        public HttpResponseMessage GetAdicionar(Models.Artigos _artigos)
        {
            try
            {
                if (Models.Artigos.GetAdicionar(_artigos))
                    return Request.CreateResponse(HttpStatusCode.OK, "Artigo inserido com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível inserir o artigo!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Artigos _artigos)
        {
            try
            {
                if (Models.Artigos.GetEditar(_artigos))
                    return Request.CreateResponse(HttpStatusCode.OK, "Artigo atualizado com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível editar o artigo!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Eliminar/{id}")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(int id)
        {
            try
            {
                if (Models.Artigos.GetEliminar(id))
                    return Request.CreateResponse(HttpStatusCode.OK, "Artigo removido com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível remover o artigo!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
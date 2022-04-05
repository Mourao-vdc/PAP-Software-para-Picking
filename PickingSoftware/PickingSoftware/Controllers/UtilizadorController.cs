using System;
using System.Net;
using System.Net.Http;
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

        [Route("Eliminar/{id}")]
        [HttpDelete]
        public HttpResponseMessage GetEliminar(int id)
        {
            try
            {
                Models.Utilizador.GetEliminar(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Login")]
        [HttpGet]
        public HttpResponseMessage UserLogin(Models.Utilizador _utilizador)
        {
            try
            {
                if (Models.Utilizador.UserLogin(_utilizador))
                    return Request.CreateResponse(HttpStatusCode.OK);

                else
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
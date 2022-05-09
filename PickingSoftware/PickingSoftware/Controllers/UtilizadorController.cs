using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/utilizador")]
    public class UtilizadorController : ApiController
    {
        [Route("perfil")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage perfil()
        {
            try
            {
                //return Request.CreateResponse(HttpStatusCode.OK, Models.Utilizador.GetUtilizadores().Where(x => x.Nome == RequestContext.Principal.Identity.Name).First());
                return Request.CreateResponse(HttpStatusCode.OK, Models.Utilizador.GetUtilizadorNome(RequestContext.Principal.Identity.Name));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Todas")]
        [HttpGet]
        [Authorize]
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
                if (Models.Utilizador.GetAdicionar(_utilizador))
                    return Request.CreateResponse(HttpStatusCode.OK, "Utilizador criado com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possivel criar o utilizador!");
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

        [Route("VerifyEmail/{email}")]
        [HttpGet]
        public HttpResponseMessage UserVerifyEmail(string email)
        {
            try
            {
                if (Models.Utilizador.UserVerifyEmail(email))
                    return Request.CreateResponse(HttpStatusCode.OK);

                else
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("VerifyNome/{nome}")]
        [HttpGet]
        public HttpResponseMessage UserVerifyNome(string nome)
        {
            try
            {
                if (Models.Utilizador.UserVerifyNome(nome))
                    return Request.CreateResponse(HttpStatusCode.OK);

                else
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("SendEmail/{email}")]
        [HttpGet]
        public HttpResponseMessage SendEmail(string email)
        {
            try
            {
                if(Models.Utilizador.SendEmail(email))
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
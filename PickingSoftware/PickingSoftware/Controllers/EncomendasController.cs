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
        public HttpResponseMessage GetEncomendastodas()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas.GetEncomendastodas());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Todas/{_nome}")]
        [HttpGet]
        public HttpResponseMessage GetEncomendas(string _nome)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas.GetEncomendas(_nome));
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
                if (Models.Encomendas.GetAdicionar(_encomendas/*, RequestContext.Principal.Identity.Name*/))
                    return Request.CreateResponse(HttpStatusCode.OK, "Encomenda criada com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível criar a encomenda!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Encomendas _encomendas)
        {
            try
            {
                if (Models.Encomendas.GetEditar(_encomendas))
                    return Request.CreateResponse(HttpStatusCode.OK, "Encomenda atulizado com sucesso");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível editar a encomenda!");
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
                if (Models.Encomendas.GetEliminar(id))
                    return Request.CreateResponse(HttpStatusCode.OK, "Encomenda removido com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível remover a encomenda!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("maxid")]
        [HttpGet]
        public HttpResponseMessage GetMAXID()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas.GetMAXID());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("idnm2/{_Nome}")]
        [HttpGet]
        public HttpResponseMessage IDNM2(string _Nome)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas.IDNM2(_Nome));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Perfil/{_nome}")]
        [HttpGet]
        public HttpResponseMessage GetEncomendasPerfil(string _nome)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas.GetEncomendasPerfil(_nome));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
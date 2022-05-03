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
                if (Models.Encomendas.GetAdicionar(_encomendas/*, RequestContext.Principal.Identity.Name*/))
                    return Request.CreateResponse(HttpStatusCode.OK, "Pedido inserido com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível inserir o pedido!");
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
                    return Request.CreateResponse(HttpStatusCode.OK, "Pedido atulizado com sucesso");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível editar o pedido!");
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
                    return Request.CreateResponse(HttpStatusCode.OK, "Pedido removido com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível remover o pedido!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("IDM/{nome}")]
        [HttpGet]
        public HttpResponseMessage IDM(string nome)
        {
            try
            {
                if (Models.Encomendas.IDM(nome))
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
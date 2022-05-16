using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Validar")]
    public class ValidarController : ApiController
    {
        [Route("Todas/{_nome}")]
        [HttpGet]
        public HttpResponseMessage GetValidar(string _nome)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Validar.GetValidar(_nome));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Detalhes/{_idencomenda}")]
        [HttpGet]
        public HttpResponseMessage GetValidarDetalhes(int _idencomenda)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Validar.GetValidarDetalhes(_idencomenda));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Estado")]
        [HttpPut]
        public HttpResponseMessage GetValidarEstado(Models.Validar _validar)
        {
            try
            {
                if (Models.Validar.GetValidarEstado(_validar))
                    return Request.CreateResponse(HttpStatusCode.OK, "Verificação realizada com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possivel realizar a verificação da encomenda");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Validadas")]
        [HttpGet]
        public HttpResponseMessage GetValidadas()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Validar.GetValidadas());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
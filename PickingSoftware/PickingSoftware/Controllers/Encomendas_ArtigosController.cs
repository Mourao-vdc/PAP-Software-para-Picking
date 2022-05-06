using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Encomendas_Artigos")]
    public class EncomendasArtigosController : ApiController
    {
        [Route("Todas/{_idencomenda}")]
        [HttpGet]
        public HttpResponseMessage GetEncomendas_Artigos(int _idencomenda)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas_Artigos.GetEncomendas_Artigos(_idencomenda));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("Adicionar")]
        [HttpPost]
        public HttpResponseMessage GetAdicionar(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                if(Models.Encomendas_Artigos.GetAdicionar(_encomendasartigos))
                    return Request.CreateResponse(HttpStatusCode.OK, "Encomenda inserida com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível inserir a encomenda!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Editar")]
        [HttpPut]
        public HttpResponseMessage GetEditar(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                if (Models.Encomendas_Artigos.GetEditar(_encomendasartigos))
                    return Request.CreateResponse(HttpStatusCode.OK, "Encomenda inserida com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível inserir a encomenda!");
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
                if (Models.Encomendas_Artigos.GetEliminar(id))
                    return Request.CreateResponse(HttpStatusCode.OK, "Encomenda inserida com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível inserir a encomenda!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Estado")]
        [HttpPut]
        public HttpResponseMessage GetEstado(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                Models.Encomendas_Artigos.GetEstado(_encomendasartigos);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("EditQuantSituacao")]
        [HttpPut]
        public HttpResponseMessage EditQuantSituacao(Models.Encomendas_Artigos _encomendasartigos)
        {
            try
            {
                if (Models.Encomendas_Artigos.EditQuantSituacao(_encomendasartigos))
                    return Request.CreateResponse(HttpStatusCode.OK, "Quantidade alterada com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível editar a quantidade!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("idnm/{_Nome}")]
        [HttpGet]
        public HttpResponseMessage IDNM(string _Nome)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Encomendas_Artigos.IDNM(_Nome));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
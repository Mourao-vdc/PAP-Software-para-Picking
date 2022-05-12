using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickingSoftware.Controllers
{
    [RoutePrefix("api/Permissoes_Gerais")]
    public class PermissoesGeraisController : ApiController
    {
        [Route("Todas/{_nome}")]
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

        [Route("EditarEstado")]
        [HttpPut]
        public HttpResponseMessage GetEditarEstado(Models.Permissoes_Gerais _estado)
        {
            try
            {
                if (Models.Permissoes_Gerais.GetEditarEstado(_estado))
                    return Request.CreateResponse(HttpStatusCode.OK, "Acesso alterado com sucesso!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possivel alterar o acesso!");
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
                Models.Permissoes_Gerais.GetEliminar(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("PermissionsVerify/{_grupo}")]
        [HttpGet]
        public HttpResponseMessage PermissionsVerify(int _grupo)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Models.Permissoes_Gerais.PermissionsVerify(_grupo));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [Route("LoginView/{_PermissionNome}")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage LoginView(string _PermissionNome)
        {
            try
            {
                var _list = Models.Permissoes_Gerais.PermissionsVerify(
                    Models.Utilizador.GetUtilizadorNome(RequestContext.Principal.Identity.Name).ID_Grupo);

                Debug.WriteLine("");
                Debug.WriteLine("LISTA:");
                Debug.WriteLine(_list.Count.ToString());
                Debug.WriteLine("");
                Debug.WriteLine("Permissão");
                Debug.WriteLine(_PermissionNome);
                Debug.WriteLine("");

                if (Models.Permissoes_Gerais.LoginView(_list,
                    _PermissionNome))
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
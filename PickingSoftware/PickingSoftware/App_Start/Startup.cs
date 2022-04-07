using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(PickingSoftware.App_Start.Startup))]

namespace PickingSoftware.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
            /*var config = new HttpConfiguration();
            // configurando rotas
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
             );
            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            // ativando a geração do token
            AtivarGeracaoTokenAcesso(app);*/

            //ativando configuração WebApi
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myProvider = new ProviderDeTokensDeAcesso();

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };

            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

        private void AtivarGeracaoTokenAcesso(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ProviderDeTokensDeAcesso()
            };
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}

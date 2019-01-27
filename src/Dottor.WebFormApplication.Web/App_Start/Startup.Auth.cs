using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System.IO;
using Microsoft.Owin.Security.Interop;
using System.Configuration;

namespace Dottor.WebFormApplication.Web
{
    public partial class Startup {

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {
            // Now we create a data protector, with a fixed purpose and sub-purpose used in key derivation.
            var protectionProvider = DataProtectionProvider.Create(
                                        new DirectoryInfo(ConfigurationManager.AppSettings["KeyRing.Path"]), 
                                        (builder) => { builder.SetApplicationName("MicrosoftIgniteDemo"); });
            var dataProtector = protectionProvider.CreateProtector(
                "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                "Identity.Application",
                "v2");
            // And finally create a new auth ticket formatter using the data protector.
            var ticketFormat = new AspNetTicketDataFormat(new DataProtectorShim(dataProtector));

            // Now configure the cookie options to have the same cookie name, and use
            // the common format.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                CookieSecure = CookieSecureOption.Never,
                CookieName = ".MyApp.SharedCookie",
                TicketDataFormat = ticketFormat,
                CookieManager = new ChunkingCookieManager(),
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnApplyRedirect = ApplyRedirect
                }
            });


        }


        private static void ApplyRedirect(CookieApplyRedirectContext context)
        {
            Uri absoluteUri;
            if (Uri.TryCreate(context.RedirectUri, UriKind.Absolute, out absoluteUri))
            {
                var path = PathString.FromUriComponent(absoluteUri);
                if (path == context.OwinContext.Request.PathBase + context.Options.LoginPath)
                {
                    context.RedirectUri = "https://localhost:44307/Identity/Account/Login" +
                        new QueryString(
                            context.Options.ReturnUrlParameter,
                            context.Request.Uri.AbsoluteUri);
                }
            }

            context.Response.Redirect(context.RedirectUri);
        }

    }
}

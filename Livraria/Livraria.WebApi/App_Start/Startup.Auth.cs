using Owin;
using Microsoft.Owin.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.WebApi.App_Start
{
	public partial class Startup
	{
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
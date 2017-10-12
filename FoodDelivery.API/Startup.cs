using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(FoodDelivery.API.Startup))]

namespace FoodDelivery.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Business.BusinessModule.Init("DefaultConnection");
            app.MapSignalR();
        }
    }
}

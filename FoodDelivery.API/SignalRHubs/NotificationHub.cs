using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FoodDelivery.API.SignalRHubs
{
    public class NotificationHub : Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        public void Hello()
        {
            Clients.User("as").sayhello();
            Clients.All.hello();
        }

        public static void SayHello()
        {
            hubContext.Clients.All.hello();
        }
    }
}
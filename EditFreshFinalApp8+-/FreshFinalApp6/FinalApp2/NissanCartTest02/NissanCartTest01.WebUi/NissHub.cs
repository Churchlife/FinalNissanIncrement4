using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi
{
    public class NissHub : Hub
    {
        public void Announce(string name, string message)
        {
            Clients.All.Announce(name, message);
        }
    }
}
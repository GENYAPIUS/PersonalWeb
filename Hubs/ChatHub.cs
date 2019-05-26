using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PersonalWeb.Models;

namespace PersonalWeb.Hubs
{
    public class ChatHub : Hub
    {
        
        public async Task SendMessage(string user, string message)
        {


            var content = $"<div class='float-left'>使用者：{user}</div>" +
                          $"<div class='float-right'>{DateTime.Now.ToShortDateString()}&nbsp{DateTime.Now.ToLongTimeString()}</div><br />" +
                          $"<div>{message}</div>";

            await Clients.All.SendAsync("ReceiveMessage", content);
        }
    }
}

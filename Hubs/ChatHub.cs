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
        private readonly MessageStore _messageStore;
        public ChatHub(MessageStore messageStore)
        {
            _messageStore = messageStore;
        }
        public async Task SendMessage(string user, string message)
        {


            var content1 = $"<div class='container'>" +
                            $"<div class='row'>" +
                                $"<div class='col-2'>&nbsp;</div>" +
                                $"<div class='col-8 chatbox'>" +
                                    $"<div class='float-left'>使用者：";
            var content2 =          $"</div>" +
                                    $"<div class='float-right'>{DateTime.Now.ToShortDateString()}{DateTime.Now.ToLongTimeString()}</div><br />" +
                                    $"<div class='col-12'><hr /></div>" +
                                    $"<div>";
            var content3 =          $"</div>"+
                                $"</div>" +
                            $"</div>" +
                          $"</div>" +
                          $"<br />";
            _messageStore.AddMessage(user, message);
            await Clients.All.SendAsync("ReceiveMessage", content1,content2,content3, user, message);
        }
    }
}

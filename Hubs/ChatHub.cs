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
        private readonly DatabaseContext _context;
        public ChatHub(DatabaseContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string user, string comment)
        {
            var content1 = $"<div class='container'>" +
                            $"<div class='row'>" +
                                $"<div class='col-2'>&nbsp;</div>" +
                                $"<div class='col-8 chatbox'>" +
                                    $"<div class='float-left'>使用者：";
            var content2 =          $"</div>" +
                                    $"<div class='float-right'>{DateTime.Now.ToString("yyyy/MM/dd tt hh:mm:ss")}</div><br />" +
                                    $"<div class='col-12'><hr /></div>" +
                                    $"<div>";
            var content3 =          $"</div>"+
                                $"</div>" +
                            $"</div>" +
                          $"</div>" +
                          $"<br />";
            _context.Add(new Message
            {
                Name = user,
                Comment = comment,
                DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd tt hh:mm:ss"))
            });
            _context.SaveChanges();
            await Clients.All.SendAsync("ReceiveMessage", content1,content2,content3, user, comment);
        }
    }
}

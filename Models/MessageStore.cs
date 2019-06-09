using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PersonalWeb.Models;


namespace PersonalWeb.Models
{
    public class MessageStore
    {
        public MessageStore(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly DatabaseContext _dbContext;

        public void AddMessage(string name, string comment)
        {
                _dbContext.Messages.Add(new Message
                {
                    Name = name,
                    Comment = comment,
                    DateTime = DateTime.Now
                });
            _dbContext.SaveChanges();
        }
    }
}

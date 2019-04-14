using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class MessageBoardModel : Message
    {
        public IEnumerable<Message> MessageCollection { get; set; }
    }
}

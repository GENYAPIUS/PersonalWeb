using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class Message
    { 
            public int Id { get; set; }
            public DateTime DateTime { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }

    }
}

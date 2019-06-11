using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalWeb.Models
{
    public class Message
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd tt hh:mm:ss}")]
        public DateTime DateTime { get; set; }

        [Required,StringLength(20, ErrorMessage ="名字限定在 20 字以内。")]
        public string Name { get; set; }

        public string Comment { get; set; }

        public IEnumerable<Message> Messages { get; set; }

    }


}

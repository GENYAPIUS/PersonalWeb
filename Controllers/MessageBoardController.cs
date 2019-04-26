using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalWeb.Models;

namespace PersonalWeb.Controllers
{
    public class MessageBoardController : Controller
    {
        private readonly DatabaseContext _context;

        public MessageBoardController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string search, string currentFilter)
        {
            var message = new Message();
           
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["CurrentFilter"] = search;

            var messages = from m in _context.Messages select m;
            if (!string.IsNullOrEmpty(search))
                messages = messages.Where(m => m.Comment.Contains(search));
            switch (sortOrder)
            {
                case "name":
                    messages = messages.OrderBy(m => m.Name);
                    break;
                case "name_desc":
                    messages = messages.OrderByDescending(m => m.Name);
                    break;
                case "date_desc":
                    messages = messages.OrderByDescending(m => m.DateTime);
                    break;
                default:
                    messages = messages = messages.OrderBy(m => m.DateTime);
                    break;
            }

            message.Messages = await messages.AsNoTracking().ToListAsync();

            return View(message);
        }
    }
}
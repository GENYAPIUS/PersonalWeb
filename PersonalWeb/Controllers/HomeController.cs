using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> MessageBoard()
        {

            var collection = await _context.Messages.ToListAsync();
            MessageBoardModel messageBoardModel = new MessageBoardModel();
            messageBoardModel.MessageCollection = collection;


            return View(messageBoardModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MessageBoard([Bind("Id,Name,Comment")] MessageBoardModel messageData)
        {
            Message message = new Message();
            message.Id = messageData.Id;
            message.DateTime = DateTime.Now;
            message.Name = messageData.Name;
            message.Comment = messageData.Comment;
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MessageBoard));
            }
            return View(message);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

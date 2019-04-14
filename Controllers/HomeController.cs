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

        public async Task<IActionResult> MessageBoard()
        {
            var collection = await _context.Messages.ToListAsync();
            MessageBoardModel messageBoardModel = new MessageBoardModel();
            messageBoardModel.MessageCollection = collection;
            return View(messageBoardModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MessageBoard([Bind("Id,Name,Comment")] MessageBoardModel messageDatas)
        {
            if (ModelState.IsValid)
            {
                messageDatas.DateTime = DateTime.Now;
                _context.Add(messageDatas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MessageBoard));
            }
            return View(messageDatas);
        }

        public IActionResult Resume()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

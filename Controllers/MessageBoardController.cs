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
        private readonly MessageStore _messageStore;
        public MessageBoardController(DatabaseContext context,MessageStore messageStore)
        {
            _context = context;
            _messageStore = messageStore;
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Comment")] Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    message.DateTime = DateTime.Now;
                    _context.Add(message);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "無法傳送您的留言，" +
                                             "請再試一次，如果" +
                                             "問題仍然存在，" +
                                             "請聯絡管理者。");
            }
            return View(message);
        }

        public async Task<IActionResult> TestChat(string sortOrder, string search, string currentFilter)
        {
            var message = new Message();

            //ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            //ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            //ViewData["CurrentFilter"] = search;

            var messages = from m in _context.Messages select m;
            //if (!string.IsNullOrEmpty(search))
            //    messages = messages.Where(m => m.Comment.Contains(search));
            //switch (sortOrder)
            //{
            //    case "name":
            //        messages = messages.OrderBy(m => m.Name);
            //        break;
            //    case "name_desc":
            //        messages = messages.OrderByDescending(m => m.Name);
            //        break;
            //    case "date_desc":
            //        messages = messages.OrderByDescending(m => m.DateTime);
            //        break;
            //    default:
            //        messages = messages = messages.OrderBy(m => m.DateTime);
            //        break;
            //}

            message.Messages = await messages.AsNoTracking().ToListAsync();

            return View(message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMessage([Bind("Name,Comment")] Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    message.DateTime = DateTime.Now;
                    _messageStore.AddMessage(message.Name, message.Comment);
                    return Created("AddMessage", message);
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "無法傳送您的留言，" +
                                             "請再試一次，如果" +
                                             "問題仍然存在，" +
                                             "請聯絡管理者。");
            }
            return View(message);
        }

    }
}
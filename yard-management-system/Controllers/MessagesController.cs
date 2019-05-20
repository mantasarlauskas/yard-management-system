using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using yard_management_system.Models;

namespace yard_management_system.Controllers
{
    public class MessagesController : Controller
    {
        private readonly yard_management_systemContext _context;
        private readonly MessageReceiversController _msgReceiversCtrl;

        public MessagesController(yard_management_systemContext context, MessageReceiversController msgReceiversCtrl)
        {
            _context = context;
            _msgReceiversCtrl = msgReceiversCtrl;
        }

        public async Task CreateMessage(int id, string prevState, string currentState)
        {
            var cargo = await _context.Cargo.FirstOrDefaultAsync(m => m.ID == id);

            if (cargo == null)
            {
                return;
            }

            Message message = new Message();
            message.CargoID = id;
            message.Text = string.Format("Krovinio nr. {0} būsena buvo pakeista iš {1} į {2}", id, prevState, currentState);
            _context.Add(message);
            await _context.SaveChangesAsync();
            await _msgReceiversCtrl.Create(message, id);
        }
    }
}

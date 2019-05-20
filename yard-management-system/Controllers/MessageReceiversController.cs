using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yard_management_system.Models;

namespace yard_management_system.Controllers
{
    public class MessageReceiversController : Controller
    {
        private readonly yard_management_systemContext _context;

        public MessageReceiversController(yard_management_systemContext context)
        {
            _context = context;
        }

        public async Task Create(Message message, int cargoId)
        {
            var contractors = await _context.Contractor.Include(c => c.OrderContracts).Include(c => c.User).ToListAsync();
            var orderContractors = contractors.Where(c => c.OrderContracts.Where(o => o.CargoID == cargoId).ToList().Count != 0).ToList();
            if (orderContractors.Count > 0)
            {
                foreach (var contractor in orderContractors)
                {
                    MessageReceiver msgReceiver = new MessageReceiver();
                    msgReceiver.MessageID = message.ID;
                    msgReceiver.ContractorID = contractor.ID;
                    _context.Add(msgReceiver);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}

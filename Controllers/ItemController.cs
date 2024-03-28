using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_wasteManagementWebapi.Data;
using E_wasteManagementWebapi.DTO;
using E_wasteManagementWebapi.Model;
using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.Ocsp;
using NuGet.Configuration;
namespace E_wasteManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly E_WasteDbContext _context;

        public ItemController(E_WasteDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<E_WasteItem>>> GetItems()
        {

            return await _context.waste_items.Include(x => x.Users).ToListAsync();

        }


        [HttpGet("{userId}/history")]
        public async Task<ActionResult<IEnumerable<E_WasteItem>>> GetItemHistory(int userId)
        {
            var userItems = await _context.waste_items
            .Where(item => item.Users.UserId == userId)
            .ToListAsync();

            if (userItems == null)
            {
                return NotFound();
            }

            return userItems;
        }

        [HttpGet ("approved")]
        public async Task<ActionResult<IEnumerable<E_WasteItem>>> GetApprovedItem()
        {
            var approvedItems = await _context.waste_items
            .Where(item => item.RequestStatus == "Approve")
            .ToListAsync();

            if (approvedItems == null)
            {
                return NotFound();
            }

            return approvedItems;
        }

        [HttpPost]
        public async Task<IActionResult> PostItem(ItemDTO items)
        {
            // Set the user ID of the item to the authenticated user's ID
            User user = _context.users.Find(items.UserId);

            // Set the status of the item to 'Pending'
            items.RequestStatus = "Pending";
            items.ApprovedItemStatus = "None";

            if (user == null)
            {
                return NotFound();
            }


            var item = new E_WasteItem
            {
                ItemName = items.ItemName,
                Itemtype = items.Itemtype,
                ItemQuantity = items.ItemQuantity,
                ItemCondition = items.ItemCondition,
                ItemLocation = items.ItemLocation,
                RequestStatus = items.RequestStatus,
                ApprovedItemStatus = items.ApprovedItemStatus,
                Users = user
            };

            _context.waste_items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItems), new { id = items.ItemId }, item);
        }


        [HttpPost]
        public async Task<IActionResult> Put(UpdateStatusDTO DTO)
        {
            var status = await _context.waste_items.FindAsync(DTO.Id);

            status.RequestStatus = DTO.Status;

            // Check if the RequestStatus is "approved"
            if (DTO.Status.ToLower() == "approved")
            {
                // Update the ApprovedItemStatus column
                status.ApprovedItemStatus = "collected,recycled";
            }
            else
            {
                status.ApprovedItemStatus = DTO.ApprovedItemStatus;
            }

            _context.waste_items.Update(status);
            await _context.SaveChangesAsync();
            return Ok();
        }





        //    [HttpPost]
        //    public async Task<IActionResult> Put(UpdateStatusDTO DTO)
        //    {

        //        var status = await _context.waste_items.FindAsync(DTO.Id);

        //        status.RequestStatus = DTO.Status;

        //        _context.waste_items.Update(status);
        //        await _context.SaveChangesAsync();
        //        return Ok();
        //    }


        //}
    }
}
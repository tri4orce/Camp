using Camp.Models;
using Camp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ViewRender view;
        CampContext db;

        public AdminController(CampContext context, ViewRender view)
        {
            this.view = view;
            db = context;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Index(string lastName, string phoneNumber, bool processed, int page = 1)
        {
            int pageSize = 2;
            IQueryable<Order> orders = db.Orders.Include(t => t.Tour).Include(v => v.Voucher);
            
            orders = processed ? orders.Where(o => o.Processed == true) : orders.Where(o => o.Processed == false);

            if (!String.IsNullOrEmpty(lastName))
                orders = orders.Where(o => o.LastName == lastName);

            if (!String.IsNullOrEmpty(phoneNumber))
                orders = orders.Where(o => o.ContactPhone == phoneNumber);


            var count = await orders.CountAsync();
            var items = await orders.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var indexViewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterViewModel(lastName, phoneNumber, processed),
                Orders = items
            };
            
            return View(indexViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, string lastName, string phoneNumber, bool processed, int page = 1)
        {
            Order order = await db.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            db.Orders.Remove(order);

            Tour tour = db.Tours.Where(t => t.TourId == order.TourId).FirstOrDefault();
            tour.CountOfPlace++;
            db.Update(tour);
            db.SaveChanges();

            return RedirectToRoute(new { 
                controller = "Admin",
                action = "Index",
                lastName = lastName,
                phoneNumber = phoneNumber,
                processed = processed,
                page = page
            });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Order order;
            if (id == null)
            {
                order = await db.Orders.Include(t => t.Tour).Include(v => v.Voucher).Where(o => o.OrderId == 2).FirstOrDefaultAsync();
            }

            order = await db.Orders.Include(t => t.Tour).Include(v => v.Voucher).Where(o => o.OrderId == id).FirstOrDefaultAsync();

            EditOrderViewModel viewModel = new EditOrderViewModel
            {
                Order = order,
                Tours = db.Tours,
                Vouchers = db.Vouchers
            };
            return PartialView("PartialView/_OrderEditModal", viewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

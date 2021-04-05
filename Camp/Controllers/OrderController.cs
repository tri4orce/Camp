using Camp.Models;
using Camp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ViewRender view;
        CampContext db;

        public OrderController(CampContext context, ViewRender view)
        {
            this.view = view;
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Tour> Tours = db.Tours.Where(t => t.CountOfPlace > 0);
            OrderIndexViewModel viewModel = new OrderIndexViewModel { Tours = Tours, Vouchers = db.Vouchers };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CardInfo(int selectVoucherId, int selectTourId)
        {
            CardInfoOrderViewModel viewModel = new CardInfoOrderViewModel
            { 
                Voucher = await db.Vouchers.FindAsync(selectVoucherId), 
                Tour = await db.Tours.FindAsync(selectTourId) 
            };
            return PartialView("PartialView/_CardInfoOrder", viewModel);
        }

        [HttpPost]
        public JsonResult Index(Order order)
        {
            if (db.Tours.Where(t => t.TourId == order.TourId).FirstOrDefault().CountOfPlace > 0)
            {
                order.ContactPhone = "+7" + order.ContactPhone;
                order.Processed = false;
                db.Orders.Add(order);
                db.SaveChanges();

                Tour tour = db.Tours.Where(t => t.TourId == order.TourId).FirstOrDefault();
                tour.CountOfPlace--;
                db.Update(tour);
                
                var html = this.view.Render("Order/PartialView/_OrderSent", true);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = this.view.Render("Order/PartialView/_OrderSent", false);
                return new JsonResult(new { isValid = false, html = html });
            }

        }
    }
}

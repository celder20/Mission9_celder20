using Microsoft.AspNetCore.Mvc;
using Mission9_celder20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_celder20.Controllers
{
    public class BuyController : Controller
    {
        private IBuyRepository repo { get; set; }
        private Cart cart { get; set; }
        public BuyController (IBuyRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new BuyInfo());
        }
        [HttpPost]
        public IActionResult Checkout(BuyInfo buy)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                buy.Lines = cart.Items.ToArray();
                repo.SaveBuy(buy);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages.Store
{
    // only logged in users can access this page
    [Authorize]
    public class CartModel : PageModel
    {
        private ICartItems _cart;
        public List<CartItems> CartItems { get; set; }

        public CartModel(ICartItems cart)
        {
            _cart = cart;
        }
        // have each cart item so we need to foreach over the cart itself
        // cart => cartitems => iterate over cart items and display one by one
        public async Task OnGet()
        {
            var user = User.Identity.Name;
            CartItems = await _cart.GetAllCartItems(user);
        }
    }
}

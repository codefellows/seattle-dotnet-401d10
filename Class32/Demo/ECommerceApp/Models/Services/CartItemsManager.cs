using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class CartItemsManager : ICartItems
    {
        private StoreDbContext _context { get; }

        private UserManager<ApplicationUser> _userManager;

        public CartItemsManager(StoreDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _userManager = user;
        }

        public async Task AddItemToCart(CartItems cartItem)
        {
            _context.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItems> DeleteCartItem(int cartItemID)
        {
            CartItems cartItem = await _context.CartItems.FindAsync(cartItemID);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;

        }

        public async Task<List<CartItems>> GetAllCartItems(string username)
        {
            // Do some logic that gets all of the cart items for a specific user.
            // query the cart table for a specific cart id...given a user id.
            // how do we get the user id?
            // magic of user manager!
            var user = await _userManager.FindByNameAsync(username);


            var userCart = await _context.Cart.FirstOrDefaultAsync( x=> x.UserID == user.Id);


            var cartItems = await _context.CartItems.Where(x => x.CartID == userCart.ID)
                                               .Include(x => x.Service).ToListAsync();

            return cartItems;
        }

        public async Task<CartItems> UpdateQuantity(int cartItemID, CartItems cartItem, int quantity)
        {
            CartItems item = await _context.CartItems.FindAsync(cartItemID);
            item.Quantity = quantity;
            _context.Entry(item.Quantity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cartItem;

        }

        public async Task<CartItems> GetItemByID(int ID) => await _context.CartItems.FindAsync(ID);

        public async Task CreateCart(string userId)
        {
            Cart cart = new Cart();
            cart.UserID = userId;

            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Gets Cart Id for a specific user.
        /// </summary>
        /// <param name="userId">unique identifier for the user </param>
        /// <returns>0 for no record, actual string id for existing.</returns>
        public async Task<int> GetCartIdForUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.UserID == user.Id);
            if (cart != null)
            {
                return cart.ID;
            }

            return 0;
        }

    }
}

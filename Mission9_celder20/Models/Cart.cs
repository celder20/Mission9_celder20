using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_celder20.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        //This method is for adding an item to the cart, which is then displayed in a table with the book name, price, and quantity
        public void AddItem (Book bookName, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == bookName.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = bookName,
                    Quantity = qty,
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        //This calculates the total price for all the books added to a users cart and displays it at the bottom of the table
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }


    public class CartLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}

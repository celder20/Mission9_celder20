using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_celder20.Models
{
    public class EFBuyRepository : IBuyRepository
    {
        private BookstoreContext context;
        public EFBuyRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<BuyInfo> Buys => context.Buys.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveBuy(BuyInfo buy)
        {
            context.AttachRange(buy.Lines.Select(x => x.Book));

            if (buy.BuyId == 0)
            {
                context.Buys.Add(buy);
            }

            context.SaveChanges();
        }
    }
}

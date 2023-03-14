using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_celder20.Models
{
    public interface IBuyRepository
    {
        IQueryable<BuyInfo> Buys { get; }
        public void SaveBuy(BuyInfo buy);
    }
}

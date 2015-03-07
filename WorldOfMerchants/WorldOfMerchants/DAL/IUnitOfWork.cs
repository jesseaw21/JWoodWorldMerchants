using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldMerchants.DAL;
using WorldOfMerchants.Models;

namespace WorldOfMerchants.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Merchant> MerchantRepo { get; }
        IGenericRepo<Item> ItemRepo { get; }
        IGenericRepo<Player> PlayerRepo { get; }
        void Save();
    }
}

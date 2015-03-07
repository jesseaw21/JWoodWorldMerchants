using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldMerchants.DAL;
using WorldOfMerchants.Models;

namespace WorldOfMerchants.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private WorldContext context = new WorldContext();
        private IGenericRepo<Merchant> merchantRepo;
        private IGenericRepo<Item> itemRepo;
        private IGenericRepo<Player> playerRepo;


        public IGenericRepo<Models.Merchant> MerchantRepo
        {
            get
            {
                if (this.merchantRepo == null)
                {
                    this.merchantRepo = new WorldRepository<Merchant>(context);
                }
                return merchantRepo;
            }
        }

        public IGenericRepo<Models.Item> ItemRepo
        {
            get
            {
                if (this.itemRepo == null)
                {
                    this.itemRepo = new WorldRepository<Item>(context);
                }
                return itemRepo;
            }
        }

        public IGenericRepo<Models.Player> PlayerRepo
        {
            get
            {
                if (this.playerRepo == null)
                {
                    this.playerRepo = new WorldRepository<Player>(context);
                }
                return playerRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldMerchants.DAL;
using WorldOfMerchants.Models;

namespace WorldOfMerchants.DAL
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IGenericRepo<Merchant> merchantRepo;
        private IGenericRepo<Item> itemRepo;
        private IGenericRepo<Player> playerRepo;

        private List<Merchant> merchants;
        private List<Item> items;
        private List<Player> players;

        public FakeUnitOfWork(List<Merchant> m = null, List<Item> i = null, List<Player> p = null)
        {
            if (m == null)
                merchants = new List<Merchant>();
            else
                merchants = m;

            if (i == null)
                items = new List<Item>();
            else
                items = i;
            if (p == null)
                players = new List<Player>();
            else
                players = p;
        }

        public IGenericRepo<Models.Merchant> MerchantRepo
        {
            get
            {
                if (this.merchantRepo == null)
                {
                    this.merchantRepo = new FakeWorldRepository<Merchant>(merchants);
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
                    this.itemRepo = new FakeWorldRepository<Item>(items);
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
                    this.playerRepo = new FakeWorldRepository<Player>(players);
                }
                return playerRepo;
            }
        }

        public void Save()
        {
            // Nothing to do here
        }

        public void Dispose()
        {
            // Nothing to do here
        }
    }
}
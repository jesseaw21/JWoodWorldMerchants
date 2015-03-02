using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WorldOfMerchants.Models;

namespace WorldOfMerchants.DAL
{
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private WorldContext context;

        public PlayerRepository(WorldContext context)
        {
            this.context = context;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return context.Players.ToList();
        }

        public Player GetPlayerByID(int id)
        {
            return context.Players.Find(id);
        }

        public void InsertPlayer(Player student)
        {
            context.Players.Add(student);
        }

        public void DeletePlayer(int studentID)
        {
            Player student = context.Players.Find(studentID);
            context.Players.Remove(student);
        }

        public void UpdatePlayer(Player student)
        {
            context.Entry(student).State = EntityState.Modified;
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
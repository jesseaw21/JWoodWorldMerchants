using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldOfMerchants.Models;

namespace WorldOfMerchants.DAL
{
    public interface IPlayerRepository : IDisposable
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerByID(int playerId);
        void InsertPlayer(Player player);
        void DeletePlayer(int playerID);
        void UpdatePlayer(Player player);
        void Save();
    }
}
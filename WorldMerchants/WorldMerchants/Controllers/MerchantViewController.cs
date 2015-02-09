using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldMerchants.DAL;
using WorldMerchants.Models;

namespace WorldMerchants.Controllers
{
    public class MerchantViewController : Controller
    {
        // GET: MerchantView
        public ActionResult Index()
        {
            WorldContext db = new WorldContext();

            var merchants = db.Merchants.Include("Items"); // Grab Merchants from database
            var items = db.Items;  // Grab Items from database

            List<MerchantView> merchList = new List<MerchantView>();
            List<ItemView> itemViewList = new List<ItemView>();

            // This loop will grab name property from Items in itemList and add new items with that name
            // property to the List of ItemViews, so that the Items property of merchList can use this list
            foreach (Item i in items)  
            {
                itemViewList.Add(new ItemView() { Name = i.Name });
            }
            
            foreach (Merchant m in db.Merchants)
            {            
                merchList.Add(new MerchantView()
                {
                    Name = m.Name,
                    Location = m.Location,
                    Type = m.Type,
                    Items = itemViewList
                });                
            }
            return View(merchList);
        }
    }
}
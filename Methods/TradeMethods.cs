using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestWeb.DB;
using RestWeb.Models;

namespace RestWeb.Methods
{
    public class TradeMethods
    {
        public static Trade GetMaxAmountByUser(Guid? id)
        {
            List<Trade> tradeList = new List<Trade>();
            using (var db = new UserDbContext())
            {
                var userDataList = db.UsersData.Where(user => user.UserId == id).ToList();
                foreach (var user in userDataList) 
                {
					var trade = JsonConvert.DeserializeObject<Trade>(user.Entity);
                    tradeList.Add(trade);
                }
                var sortedTrade = tradeList.OrderBy(trade => trade.CreatedAt);

				return sortedTrade.Last();
            }
        }
    }
}

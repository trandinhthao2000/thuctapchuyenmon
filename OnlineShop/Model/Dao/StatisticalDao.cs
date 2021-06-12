using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class StatisticalDao
    {
        OnlineShopDbContext db = null;
        public StatisticalDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<StatisticalModel> listStatistical()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new StatisticalModel()
                         {
                             date = b.CreatedDate,
                             revenue = a.Price * a.Quantity,
                             benefit = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new StatisticalModel()
                         {
                             date = x.date,
                             revenue = x.revenue,
                             benefit = x.benefit,
                             status = x.status
                         });
            var model1 = new List<StatisticalModel>();
            foreach (var item in model.ToList())
            {
                int cout = 0;
                if (item.status == true)
                {
                    foreach (var item1 in model1)
                    {
                        if (item1.date.Value.Month == item.date.Value.Month && item1.date.Value.Year == item.date.Value.Year)
                        {
                            item1.revenue += item.revenue;
                            item1.benefit += item.benefit;
                            cout++;

                        }
                    }
                    if (cout == 0)
                    {
                        model1.Add(item);
                    }
                }
            }
            model1.OrderByDescending(x => x.date);
            return model1.ToList();
        }
        public List<StatisticalModel> Search(string keyword, ref int totalRecord)
        {
            totalRecord = db.Orders.Where(x => x.CreatedDate.ToString() == keyword).Count();
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new StatisticalModel()
                         {
                             date = b.CreatedDate,
                             revenue = a.Price * a.Quantity,
                             benefit = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new StatisticalModel()
                         {
                             date = x.date,
                             revenue = x.revenue,
                             benefit = x.benefit,
                             status = x.status
                         });
            var model1 = new List<StatisticalModel>();
            foreach (var item in model.ToList())
            {
                int cout = 0;
                if (item.status == true)
                {
                    foreach (var item1 in model1)
                    {
                        if (item1.date.Value.Month == item.date.Value.Month && item1.date.Value.Year == item.date.Value.Year)
                        {
                            item1.revenue += item.revenue;
                            item1.benefit += item.benefit;
                            cout++;
                        }
                    }
                    if (cout == 0)
                    {
                        model1.Add(item);
                    }
                }
            }
            model1.OrderByDescending(x => x.date);
            return model1.ToList();
        }
    }
}

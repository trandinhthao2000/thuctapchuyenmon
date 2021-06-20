using Model.EF;
using Model.ViewModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public List<ThongkeModel> listthongke()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            var model1 = new List<ThongkeModel>();
            foreach (var item in model.ToList())
            {
                int cout = 0;
                if (item.status == true)
                {
                    foreach (var item1 in model1)
                    {
                        if (item1.dateTime.Value.Month == item.dateTime.Value.Month && item1.dateTime.Value.Year == item.dateTime.Value.Year)
                        {
                            item1.doanhthu += item.doanhthu;
                            item1.loinhuan += item.loinhuan ;
                            cout++;

                        }
                    }
                    if (cout == 0)
                    {
                        model1.Add(item);
                    }
                }
            }
            model1.OrderByDescending(x => x.dateTime);
            return model1.ToList();
        }

        public List<ThongkeModel> Search(string keyword, ref int totalRecord)
        {
            totalRecord = db.Orders.Where(x => x.CreatedDate.ToString() == keyword).Count();
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            var model1 = new List<ThongkeModel>();
            foreach (var item in model.ToList())
            {
                int cout = 0;
                if (item.status == true)
                {
                    foreach (var item1 in model1)
                    {
                        if (item1.dateTime.Value.Month == item.dateTime.Value.Month && item1.dateTime.Value.Year == item.dateTime.Value.Year)
                        {
                            item1.doanhthu += item.doanhthu;
                            item1.loinhuan += item.loinhuan;
                            cout++;
                        }
                    }
                    if (cout == 0)
                    {
                        model1.Add(item);
                    }
                }
            }
            model1.OrderByDescending(x => x.dateTime);
            return model1.ToList();
        }

        public decimal doanhthu4()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? doanhthu4 = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    if (item.dateTime.Value.Month == 4)
                    {
                        doanhthu4 += item.doanhthu;
                    }
                }
            }
            return (decimal)doanhthu4;
        }
        public decimal loinhuan4()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? loinhuan4 = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    if (item.dateTime.Value.Month == 4)
                    {
                        loinhuan4 += item.loinhuan;
                    }
                }
            }
            return (decimal)loinhuan4;
        }
        public decimal doanhthu5()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? doanhthu5 = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    if (item.dateTime.Value.Month == 5)
                    {
                        doanhthu5 += item.doanhthu;
                    }
                }
            }
            return (decimal)doanhthu5;
        }
        public decimal loinhuan5()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? loinhuan5 = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    if (item.dateTime.Value.Month == 5)
                    {
                        loinhuan5 += item.loinhuan;
                    }
                }
            }
            return (decimal)loinhuan5;
        }
        public decimal doanhthu6()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? doanhthu6 = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    if (item.dateTime.Value.Month == 6)
                    {
                        doanhthu6 += item.doanhthu;
                    }
                }
            }
            return (decimal)doanhthu6;
        }
        public decimal loinhuan6()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? loinhuan6 = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    if (item.dateTime.Value.Month == 6)
                    {
                        loinhuan6 += item.loinhuan;
                    }
                }
            }
            return (decimal)loinhuan6;
        }
        public decimal countdoanhthu()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? totaldoanhthu = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    totaldoanhthu += item.doanhthu;
                }
            }
            return (decimal)totaldoanhthu;
        }
        public decimal countloinhuan()
        {
            var model = (from a in db.OrderDetails
                         join b in db.Orders on a.OrderID equals b.ID
                         join c in db.Products on a.ProductID equals c.ID
                         select new ThongkeModel()
                         {
                             dateTime = b.CreatedDate,
                             doanhthu = a.Price * a.Quantity,
                             loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                             status = b.Status
                         }).AsEnumerable().Select(x => new ThongkeModel()
                         {
                             dateTime = x.dateTime,
                             doanhthu = x.doanhthu,
                             loinhuan = x.loinhuan,
                             status = x.status
                         });
            decimal? totalloinhuan = 0;
            foreach (var item in model.ToList())
            {
                if (item.status == true)
                {
                    totalloinhuan += item.loinhuan;
                }
            }
            return (decimal)totalloinhuan;
        }

        public Stream CreateExcelFile(Stream stream = null)
        {
            var list = (from a in db.OrderDetails
                        join b in db.Orders on a.OrderID equals b.ID
                        join c in db.Products on a.ProductID equals c.ID
                        select new ThongkeModel()
                        {
                            dateTime = b.CreatedDate,
                            doanhthu = a.Price * a.Quantity,
                            loinhuan = a.Quantity * (a.Price - c.OriginalPrice),
                            status = b.Status
                        }).AsEnumerable().Select(x => new ThongkeModel()
                        {
                            dateTime = x.dateTime,
                            doanhthu = x.doanhthu,
                            loinhuan = x.loinhuan,
                            status = x.status
                        });
            var listexcel = new List<ThongkeModel>();
            foreach (var item in list.ToList())
            {
                int cout = 0;
                if (item.status == true)
                {
                    foreach (var item1 in listexcel)
                    {
                        if (item1.dateTime.Value.Month == item.dateTime.Value.Month && item1.dateTime.Value.Year == item.dateTime.Value.Year)
                        {
                            item1.doanhthu += item.doanhthu;
                            item1.loinhuan += item.loinhuan;
                            cout++;

                        }
                    }
                    if (cout == 0)
                    {
                        listexcel.Add(item);
                    }
                }
            }
            listexcel.OrderByDescending(x => x.dateTime);
            using (var package = new ExcelPackage(stream ?? new MemoryStream()))
            {
                package.Workbook.Properties.Author = "Đình Thảo";
                package.Workbook.Properties.Title = "Thống kê doanh thu";
                package.Workbook.Worksheets.Add("Sheet");
                var workSheet = package.Workbook.Worksheets[0];

                workSheet.Cells[1, 1].LoadFromCollection(listexcel, true, TableStyles.Dark9);
                BindingFormatForExcel(workSheet, listexcel);
                package.Save();
                return package.Stream;
            }
        }
        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<ThongkeModel> listItems)
        {
            worksheet.DefaultColWidth = 10;
            worksheet.Cells.Style.WrapText = true;
            worksheet.Cells[1, 1].Value = "Thời gian";
            worksheet.Cells[1, 2].Value = "Doanh thu";
            worksheet.Cells[1, 3].Value = "Lợi nhuận";

            using (var range = worksheet.Cells["A1:D1"])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Font.SetFromFont(new Font("Arial", 10));
            }

            for (int i = 0; i < listItems.Count; i++)
            {
                var item = listItems[i];
                worksheet.Cells[i + 2, 1].Value = item.dateTime.Value.Month + "-" + item.dateTime.Value.Year;
                worksheet.Cells[i + 2, 2].Value = item.doanhthu;
                worksheet.Cells[i + 2, 3].Value = item.loinhuan;
                if (item.loinhuan > 10000000)
                {
                    using (var range = worksheet.Cells[i + 2, 1, i + 2, 4])
                    {
                        range.Style.Font.Color.SetColor(Color.Red);
                    }
                }

            }


            worksheet.Cells[1, 1, listItems.Count + 5, 4].AutoFitColumns(15);

            worksheet.Cells[listItems.Count + 3, 3].Value = "Tổng doanh thu";
            worksheet.Cells[listItems.Count + 3, 4].Formula = "SUM(B2:B" + (listItems.Count + 1) + ")";
            worksheet.Cells[listItems.Count + 4, 3].Value = "Tổng lợi nhuận";
            worksheet.Cells[listItems.Count + 4, 4].Formula = "SUM(C2:C" + (listItems.Count + 1) + ")";
        }

    }
}


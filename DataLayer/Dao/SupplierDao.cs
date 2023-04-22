using DataLayer.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dao
{
    public class SupplierDao
    {
        NTQDBContext db;
        public SupplierDao()
        {
            db = new NTQDBContext();
        }
        public IEnumerable<Product> GetProductOfTeelab(int supplierID, string searchString, int page, int pageSize)
        {
            try
            {
                IQueryable<Product> model = db.Products.Where(x=>x.SupplierID==supplierID);
                if (!string.IsNullOrEmpty(searchString))
                {
                    model = model.Where(x => x.ProductName.Contains(searchString));
                    return model.OrderByDescending(x => x.NumberViews).ToPagedList(page, pageSize);
                }
                return model.OrderByDescending(x => x.NumberViews).ToPagedList(page, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

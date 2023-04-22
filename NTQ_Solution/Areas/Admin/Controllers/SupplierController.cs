using DataLayer.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTQ_Solution.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        SupplierDao supplierDao;
        public SupplierController()
        {
            supplierDao = new SupplierDao();
        }
        // GET: Admin/Supplier
        public ActionResult Index(int supplierID, string searchString, int page = 1, int pageSize = 5)
        {
            try
            {
                ViewBag.supplierID = supplierID;
                var model = supplierDao.GetProductOfTeelab(supplierID, searchString, page, pageSize);
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
using DevExpress.Web.Mvc;
using DevOnlinePOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevOnlinePOP.Controllers
{
    public class DetailController : Controller
    {
        DAL.Data.DataContext db = new DAL.Data.DataContext();
        // GET: Detail
        public ActionResult Index()
        {
            return View();
        }
        
        [ValidateInput(false)]
        public ActionResult DetailAndDuePartial()
        {
            string SupID = ApplicationUserData.SuppID;
            var model = db.tblpop_order_detail.Where(w=>w.tblpop_order_header.SuppID==SupID && w.OutStandingQty>0).OrderByDescending(o=>o.OutStandingQty);
            return PartialView("_DetailAndDuePartial", model.ToList());
        }
    }
}
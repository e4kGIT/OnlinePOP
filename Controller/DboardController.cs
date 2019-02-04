using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevOnlinePOP.Controllers
{
    [Authorize]
    public class DboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DashboardViewerPartial()
        {
            return PartialView("_DashboardViewerPartial", DashboardViewerSettings.Model);
        }
        public FileStreamResult DashboardViewerPartialExport()
        {
            return DevExpress.DashboardWeb.Mvc.DashboardViewerExtension.Export("DashboardViewer", DashboardViewerSettings.Model);
        }
    }
    class DashboardViewerSettings
    {
        public static DevExpress.DashboardWeb.Mvc.DashboardSourceModel Model
        {
            get
            {
                DevExpress.DashboardWeb.Mvc.DashboardSourceModel model = new DevExpress.DashboardWeb.Mvc.DashboardSourceModel();
                model.DashboardSource = typeof(Dashboard1);
                return model;
            }
        }
    }

}

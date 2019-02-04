using DAL.Data;
using DevExpress.Web.Mvc;
using DevOnlinePOP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DevOnlinePOP.Controllers
{
    [Authorize]
    public class POPController : Controller
    {
        // GET: POP

        public ActionResult Index()
        {            
            return View();
        }
        //public ActionResult OrdeDetailPartial(int OrderNo)
        //{
        //    string SupID = ApplicationUserData.SuppID;
        //    var model = db.tblpop_order_header.Where(w => w.SuppID == SupID && w.OrderNo == OrderNo).First();
        //    return PartialView("_OrdeDetailPartial", model.tblpop_order_detail.ToList());           
        //}
        public ActionResult OrdeStatusPartial(int OrderNo)
        {
            string SupID = ApplicationUserData.SuppID;
            var model = db.tblpop_order_header.Where(w => w.SuppID == SupID && w.OrderNo == OrderNo).First();
            return PartialView("_OrdeStatusPartial", model.tblpop_order_header_status.ToList());
        }
        public ActionResult OrderHeader(int OrderNo)
        {
            string SupID = ApplicationUserData.SuppID;
            var model = db.tblpop_order_header.Where(w => w.SuppID == SupID && w.OrderNo == OrderNo).First();
            return PartialView("_OrderHeader", model);
        }
        public ActionResult OrderInfo(int OrderNo)
        {
            return View();
        }
        DAL.Data.DataContext db = new DAL.Data.DataContext();

        //public async Task<ActionResult> GridViewPartial()
        //{
        //    string SupID = ApplicationUserData.SuppID;
        //    List<tblpop_order_header> model = new List<tblpop_order_header>();

        //    using (var client = new HttpClient())
        //    {
        //        //Passing service base url  
        //        client.BaseAddress = new Uri("http://localhost:11930/");

        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format  
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
        //        HttpResponseMessage Res = await client.GetAsync("api/OrderHeader/?SupplierID=" + SupID);

        //        //Checking the response is successful or not which is sent using HttpClient  
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            //Storing the response details recieved from web api   
        //            var OrdResponse = Res.Content.ReadAsStringAsync().Result;
        //            var mpm = await Res.Content.ReadAsAsync<IEnumerable<tblpop_order_header>>();
        //            //Deserializing the response recieved from web api and storing into the Employee list  
        //            // model = JsonConvert.DeserializeObject<List<tblpop_order_header>>(OrdResponse);
        //            model = mpm.ToList();
        //            //mpm.
        //        }
        //        //returning the employee list to view  
        //        //return View(EmpInfo);

        //        return PartialView("_GridViewPartial", model); ;
        //    }
        //}
        //[HttpGet]
        //public JsonResult GridViewPartialJson()
        //{
        //    return Json(db.tblpop_order_header.ToList(),JsonRequestBehavior.AllowGet);
        //}
        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            string SupID = ApplicationUserData.SuppID;
            var model = db.tblpop_order_header.Where(w => w.SuppID == SupID).ToList();
            return PartialView("_GridViewPartial", model);
        }
        //[ValidateInput(false)]
        //public ActionResult OrderInfoPartial(string Param)
        //{
        //    int OrderNo = Convert.ToInt32(Param.Split('|')[0]);// Convert.ToInt32(Request.Params["OrderNo"].ToString());
        //    string SupID = Session["SupID"].ToString();
        //    var model = db.tblpop_order_header.Where(w => w.SuppID == SupID && w.OrderNo == OrderNo);
        //    return PartialView("_OrderInfoPartial", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridViewPartialAddNew(DAL.Data.tblpop_order_header item)
        //{
        //    var model = db.tblpop_order_header;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            model.Add(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_GridViewPartial", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridViewPartialUpdate(DAL.Data.tblpop_order_header item)
        //{
        //    var model = db.tblpop_order_header;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var modelItem = model.FirstOrDefault(it => it.OrderNo == item.OrderNo);
        //            if (modelItem != null)
        //            {
        //                this.UpdateModel(modelItem);
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_GridViewPartial", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridViewPartialDelete(System.Int32 OrderNo)
        //{
        //    var model = db.tblpop_order_header;
        //    if (OrderNo >= 0)
        //    {
        //        try
        //        {
        //            var item = model.FirstOrDefault(it => it.OrderNo == OrderNo);
        //            if (item != null)
        //                model.Remove(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    return PartialView("_GridViewPartial", model.ToList());
        //}        


        [HttpGet]
        public ActionResult UpdateStatus(int StatusID,int OrderNo)
        {
            
            var nsta = db.tblpop_customer_status.Where(w => w.StatusID == StatusID).First();
            var norder = db.tblpop_order_header.Where(w=>w.OrderNo==OrderNo).First();
            var newStatus = new tblpop_order_header_status { CompanyId = "001", LastUpdate = DateTime.Now, StatusID = StatusID, OrderNo = norder.OrderNo, UserID = 1, WareHouseId = norder.WareHouseId };
            db.tblpop_order_header_status.Add(newStatus);
            db.SaveChanges();
            //Session["status"] = db.tblpop_order_header.Where(w => w.OrderNo == norder.OrderNo).First().tblpop_order_header_status;
            return OrderStatusPartial(db.tblpop_order_header.Where(w => w.OrderNo == norder.OrderNo).First().tblpop_order_header_status, OrderNo);
        }
        [ValidateInput(false)]
        public ActionResult OrderStatusPartial(ICollection<DAL.Data.tblpop_order_header_status> status,int? OrderNo)
        {
            if (status == null)
            {
                status =(ICollection < DAL.Data.tblpop_order_header_status >)Session["status"];
                OrderNo=(int)Session["CurrentOrderNo"];
            }
            
            string SupID = ApplicationUserData.SuppID;
            var allstatus = db.tblpop_customer_status.Where(w => w.SupplierID == SupID).OrderBy(o => o.PriorityID).Select(s => new StatusByBusiness
            {
                StatusID = s.StatusID,
                Status = s.StatusDesc,
                SeqNo = (int)s.PriorityID,
                LastUpdate = null,
                IShow = true,
                OrderNo=(int) OrderNo,
                // OrderNo=s.                
            }).ToList();

            if (status.Count > 0)
            {
                int MaxID = status.Max(m => m.tblpop_customer_status.PriorityID).Value;
                foreach (var item in allstatus)
                {
                    item.LastUpdate = status.Any(a => a.StatusID == item.StatusID) ? (DateTime?)status.Where(a => a.StatusID == item.StatusID).First().LastUpdate : null;
                    item.IsCurrent = item.SeqNo == MaxID;
                    item.IShow = item.SeqNo > MaxID;
                }
            }
            Session["status"] = status;
            Session["CurrentOrderNo"] = OrderNo;
            return PartialView("_OrderStatusPartial", allstatus);
        }
        [ValidateInput(false)]
        public ActionResult NewStatus(ICollection<DAL.Data.tblpop_order_header_status> status)
        {
            ViewBag.Updatedata = status.ToList();
            string SupID = ApplicationUserData.SuppID;
            List<DAL.Data.tblpop_customer_status> model;
            if(status.Count>0)
            {
                int MaxID = status.Max(m => m.tblpop_customer_status.PriorityID).Value;
                model = db.tblpop_customer_status.Where(w => w.SupplierID == SupID && w.PriorityID> MaxID).OrderBy(o => o.PriorityID).ToList();
            }
            else
            {
                model = db.tblpop_customer_status.Where(w => w.SupplierID == SupID).OrderBy(o => o.PriorityID).ToList();
            }
            return PartialView("_UpdateStatus", model);
        }

        [ValidateInput(false)]
        public ActionResult OrderDetail(ICollection<DAL.Data.tblpop_order_detail> detail)
        {
            List<tblpop_order_detail> model = null;
            try
            {
                //ViewData["Detaildata"] = detail;
                if (detail == null)
                    detail = (ICollection<DAL.Data.tblpop_order_detail>)Session["Detaildata"];
                else
                    Session["Detaildata"] = detail;
                model = detail.ToList();            
            }
            catch (Exception ex)
            {
                ViewData["EditError"] = ex.Message;              
            }
            return PartialView("_OrderDetail", model);
        }

        [ValidateInput(false)]
        public ActionResult OrdeDetailPartial(int OrderNo)
        {
                string SupID = ApplicationUserData.SuppID;
            var model = db.tblpop_order_header.Where(w => w.SuppID == SupID && w.OrderNo == OrderNo).First().tblpop_order_detail.ToList();
            return PartialView("_OrdeDetailPartial", model);
        }
    }
}
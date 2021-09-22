using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVC_BackOffice.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Categorys
        public ActionResult Index()
        {
            List<Order> lst = new List<Order>();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Get(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_Get);
               
                // convert Json
                lst = JsonConvert.DeserializeObject<List<Order>>(result);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                    
            }
            return View(lst);
        }

        // GET: Categorys/Details/5
        public ActionResult Details(int id)
        {
            Order order = new Order();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_GetId, id);
                //Convert Json
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(order);
        }

        // GET: Categorys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Order obj = new Order();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "OrderId":
                        obj.OrderId = int.Parse(item.Value);
                        break;
                    case "UserId":
                        obj.UserId = int.Parse(item.Value);
                        break;
                    case "Quantity":
                        obj.Quantity = int.Parse(item.Value);
                        break;
                    case "Price":
                        obj.Price = decimal.Parse(item.Value);
                        break;
                }
            }
            string data = JsonConvert.SerializeObject(obj);

            ApiConnector ac = new ApiConnector();
            string result = ac.Post(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_Post, data);
            return RedirectToAction(nameof(Index)); 
        }

        // GET: Categorys/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = new Order();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_GetId, id);
                // Convert Json
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(order);
        }

        // POST: Categorys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Order obj = new Order();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "OrderId":
                        obj.OrderId = int.Parse(item.Value);
                        break;
                    case "Quantity":
                        obj.Quantity = int.Parse(item.Value);
                        break;
                    case "Price":
                        obj.Price = decimal.Parse(item.Value);
                        break;
                    case "UserId":
                        obj.UserId = int.Parse(item.Value);
                        break;
                }
            }
            // Convert Json
            string data = JsonConvert.SerializeObject(obj);

            //Connect To API using class Helper
            ApiConnector ac = new ApiConnector();
            string result = ac.Put(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_Put + obj.OrderId, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorys/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = new Order();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsCategory.APIController+ ConstantsCategory.APIController_Action_GetId, id);
                // Convert Json
                order = JsonConvert.DeserializeObject<Order>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(order);
        }

        // POST: Categorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Order obj = new Order();
                foreach (var item in collection)
                {
                    switch (item.Key)
                    {
                        case "OrderId":
                            obj.OrderId = int.Parse(item.Value);
                            break;
                        case "Quantity":
                            obj.Quantity = int.Parse(item.Value);
                            break;
                        case "Price":
                            obj.Price = decimal.Parse(item.Value);
                            break;
                        case "UserId":
                            obj.UserId = int.Parse(item.Value);
                            break;
                    }
                }
                string data = JsonConvert.SerializeObject(obj);

                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Delete(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_Del + obj.OrderId, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
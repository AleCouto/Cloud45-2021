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
    public class ProductsController : Controller
    {
        // GET: Categorys
        public ActionResult Index()
        {
            List<Product> lst = new List<Product>();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Get(ConstantsProduct.APIController + ConstantsProduct.APIController_Action_Get);
               
                // convert Json
                lst = JsonConvert.DeserializeObject<List<Product>>(result);
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
            Product product = new Product();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsProduct.APIController + ConstantsProduct.APIController_Action_GetId, id);
                //Convert Json
                product = JsonConvert.DeserializeObject<Product>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(product);
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
            Product obj = new Product();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "ProductId":
                        obj.ProductId = int.Parse(item.Value);
                        break;
                    case "Name":
                        obj.Name = item.Value;
                        break;
                    case "Price":
                        obj.Price = decimal.Parse(item.Value);
                        break;
                    case "Amount":
                        obj.Amount = int.Parse(item.Value);
                        break;
                    case "Description":
                        obj.Description = item.Value;
                        break;
                    case "CategoryId":
                        obj.CategoryId = int.Parse(item.Value);
                        break;
                }
            }
            string data = JsonConvert.SerializeObject(obj);

            ApiConnector ac = new ApiConnector();
            string result = ac.Post(ConstantsProduct.APIController + ConstantsProduct.APIController_Action_Post, data);
            return RedirectToAction(nameof(Index)); 
        }

        // GET: Categorys/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = new Product();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsProduct.APIController + ConstantsProduct.APIController_Action_GetId, id);
                // Convert Json
                product = JsonConvert.DeserializeObject<Product>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(product);
        }

        // POST: Categorys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Product obj = new Product();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "ProductId":
                        obj.ProductId = int.Parse(item.Value);
                        break;
                    case "Name":
                        obj.Name = item.Value;
                        break;
                    case "Price":
                        obj.Price = decimal.Parse(item.Value);
                        break;
                    case "Amount":
                        obj.Amount = int.Parse(item.Value);
                        break;
                    case "Description":
                        obj.Description = item.Value;
                        break;
                    case "CategoryId":
                        obj.CategoryId = int.Parse(item.Value);
                        break;
                }
            }
            // Convert Json
            string data = JsonConvert.SerializeObject(obj);

            //Connect To API using class Helper
            ApiConnector ac = new ApiConnector();
            string result = ac.Put(ConstantsProduct.APIController + ConstantsProduct.APIController_Action_Put + obj.ProductId, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorys/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = new Product();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsProduct.APIController+ ConstantsProduct.APIController_Action_GetId, id);
                // Convert Json
                product = JsonConvert.DeserializeObject<Product>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(product);
        }

        // POST: Categorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Product obj = new Product();
                foreach (var item in collection)
                {
                    switch (item.Key)
                    {
                        case "ProductId":
                            obj.ProductId = int.Parse(item.Value);
                            break;
                        case "Name":
                            obj.Name = item.Value;
                            break;
                        case "Price":
                            obj.Price = decimal.Parse(item.Value);
                            break;
                        case "Amount":
                            obj.Amount = int.Parse(item.Value);
                            break;
                        case "Description":
                            obj.Description = item.Value;
                            break;
                        case "CategoryId":
                            obj.CategoryId = int.Parse(item.Value);
                            break;
                    }
                }
                string data = JsonConvert.SerializeObject(obj);

                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Delete(ConstantsProduct.APIController + ConstantsProduct.APIController_Action_Del + obj.ProductId, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
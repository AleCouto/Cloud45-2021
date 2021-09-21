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
    public class CategorysController : Controller
    {
        // GET: Categorys
        public ActionResult Index()
        {
            List<Category> lst = new List<Category>();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Get(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_Get);
               
                // convert Json
                lst = JsonConvert.DeserializeObject<List<Category>>(result);
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
            Category category = new Category();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_GetId, id);
                //Convert Json
                category = JsonConvert.DeserializeObject<Category>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(category);
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
            Category obj = new Category();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "CategoryId":
                        obj.CategoryId= int.Parse(item.Value);
                        break;
                    case "CategoryName":
                        obj.CategoryName = item.Value;
                        break;
                }
            }
            string data = JsonConvert.SerializeObject(obj);

            ApiConnector ac = new ApiConnector();
            string result = ac.Post(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_Post, data);
            return RedirectToAction(nameof(Index)); 
        }

        // GET: Categorys/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = new Category();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_GetId, id);
                // Convert Json
                category = JsonConvert.DeserializeObject<Category>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(category);
        }

        // POST: Categorys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Category obj = new Category();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "CategoryId":
                        obj.CategoryId = int.Parse(item.Value);
                        break;
                    case "CategoryName":
                        obj.CategoryName = item.Value;
                        break;
                }
            }
            // Convert Json
            string data = JsonConvert.SerializeObject(obj);

            //Connect To API using class Helper
            ApiConnector ac = new ApiConnector();
            string result = ac.Put(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_Put + obj.CategoryId, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorys/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = new Category();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_GetId, id);
                // Convert Json
                category = JsonConvert.DeserializeObject<Category>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(category);
        }

        // POST: Categorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Category obj = new Category();
                foreach (var item in collection)
                {
                    switch (item.Key)
                    {
                        case "CategoryId":
                            obj.CategoryId = int.Parse(item.Value);
                            break;
                        case "CategoryName":
                            obj.CategoryName = item.Value;
                            break;
                    }
                }
                string data = JsonConvert.SerializeObject(obj);

                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Delete(ConstantsCategory.APIController + ConstantsCategory.APIController_Action_Del + obj.CategoryId, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
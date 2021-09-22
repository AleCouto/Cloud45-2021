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
    public class UsersController : Controller
    {
        // GET: Categorys
        public ActionResult Index()
        {
            List<User> lst = new List<User>();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Get(ConstantsUser.APIController + ConstantsUser.APIController_Action_Get);
               
                // convert Json
                lst = JsonConvert.DeserializeObject<List<User>>(result);
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
            User user = new User();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsUser.APIController + ConstantsUser.APIController_Action_GetId, id);
                //Convert Json
                user = JsonConvert.DeserializeObject<User>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(user);
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
            User obj = new User();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "ProductId":
                        obj.UserId = int.Parse(item.Value);
                        break;
                    case "AccessLevel":
                        obj.AccessLevel = Convert.ToBoolean(item.Value);
                        break;
                    case "Name":
                        obj.Name = item.Value;
                        break;
                    case "Birthday":
                        obj.Birthday = item.Value;
                        break;
                    case "PhoneNumber":
                        obj.PhoneNumber = item.Value;
                        break;
                    case "Email":
                        obj.Email = item.Value;
                        break;
                    case "Indentification":
                        obj.Indentification = item.Value;
                        break;
                    case "FiscalNumber":
                        obj.FiscalNumber = item.Value;
                        break;
                    case "Address":
                        obj.Address = item.Value;
                        break;
                    case "PostalCode":
                        obj.PostalCode = item.Value;
                        break;
                }
            }
            string data = JsonConvert.SerializeObject(obj);

            ApiConnector ac = new ApiConnector();
            string result = ac.Post(ConstantsUser.APIController + ConstantsUser.APIController_Action_Post, data);
            return RedirectToAction(nameof(Index)); 
        }

        // GET: Categorys/Edit/5
        public ActionResult Edit(int id)
        {
            User user = new User();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsUser.APIController + ConstantsUser.APIController_Action_GetId, id);
                // Convert Json
                user = JsonConvert.DeserializeObject<User>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(user);
        }

        // POST: Categorys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            User obj = new User();
            foreach (var item in collection)
            {
                switch (item.Key)
                {
                    case "ProductId":
                        obj.UserId = int.Parse(item.Value);
                        break;
                    //case "AccessLevel":
                    //    obj.AccessLevel = Convert.ToBoolean(item.Value);
                    //    break;
                    case "Name":
                        obj.Name = item.Value;
                        break;
                    case "Birthday":
                        obj.Birthday = item.Value;
                        break;
                    case "PhoneNumber":
                        obj.PhoneNumber = item.Value;
                        break;
                    case "Email":
                        obj.Email = item.Value;
                        break;
                    case "Indentification":
                        obj.Indentification = item.Value;
                        break;
                    case "FiscalNumber":
                        obj.FiscalNumber = item.Value;
                        break;
                    case "Address":
                        obj.Address = item.Value;
                        break;
                    case "PostalCode":
                        obj.PostalCode = item.Value;
                        break;
                }
            }
            // Convert Json
            string data = JsonConvert.SerializeObject(obj);

            //Connect To API using class Helper
            ApiConnector ac = new ApiConnector();
            string result = ac.Put(ConstantsUser.APIController + ConstantsUser.APIController_Action_Put + obj.UserId, data);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorys/Delete/5
        public ActionResult Delete(int id)
        {
            User user = new User();
            try
            {
                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.GetId(ConstantsUser.APIController+ ConstantsUser.APIController_Action_GetId, id);
                // Convert Json
                user = JsonConvert.DeserializeObject<User>(result);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return View(user);
        }

        // POST: Categorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                User obj = new User();
                foreach (var item in collection)
                {
                    switch (item.Key)
                    {
                        case "ProductId":
                            obj.UserId = int.Parse(item.Value);
                            break;
                        case "AccessLevel":
                            obj.AccessLevel = Convert.ToBoolean(item.Value);
                            break;
                        case "Name":
                            obj.Name = item.Value;
                            break;
                        case "Birthday":
                            obj.Birthday = item.Value;
                            break;
                        case "PhoneNumber":
                            obj.PhoneNumber = item.Value;
                            break;
                        case "Email":
                            obj.Email = item.Value;
                            break;
                        case "Indentification":
                            obj.Indentification = item.Value;
                            break;
                        case "FiscalNumber":
                            obj.FiscalNumber = item.Value;
                            break;
                        case "Address":
                            obj.Address = item.Value;
                            break;
                        case "PostalCode":
                            obj.PostalCode = item.Value;
                            break;
                    }
                }
                string data = JsonConvert.SerializeObject(obj);

                //Connect To API using class Helper
                ApiConnector ac = new ApiConnector();
                string result = ac.Delete(ConstantsUser.APIController + ConstantsUser.APIController_Action_Del + obj.UserId, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_VirtualStore.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_VirtualStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
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
            catch (Exception ex)
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
    }
}

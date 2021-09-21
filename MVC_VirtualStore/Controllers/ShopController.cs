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


namespace MVC_VirtualStore.Controllers
{
    public class ShopController : Controller
    {
        // Implementando carrinho
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

            ApiConnector ac = new ApiConnector();
            string result = ac.Post(ConstantsOrder.APIController + ConstantsOrder.APIController_Action_Post, data);
            return RedirectToAction(nameof(Index));
        }


        //Implementar metodo Getpantas para filtrar
        public IActionResult GetPlants()
        {
            List<Product> lst = new List<Product>();


            return((IActionResult)lst);
        }

    }
}

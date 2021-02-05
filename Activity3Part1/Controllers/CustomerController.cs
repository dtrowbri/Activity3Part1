using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity3Part1.Models;

namespace Activity3Part1.Controllers
{
    public class CustomerController : Controller
    {
        private List<CustomerModel> customers = new List<CustomerModel> {
            new CustomerModel(0, "Alan Davies", 55),
            new CustomerModel(1, "Stephen Fry", 63),
            new CustomerModel(2, "Sandy Toksvig", 62),
            new CustomerModel(3, "Rob Brydon", 55),
            new CustomerModel(4, "Phil Jupitus", 58),
            new CustomerModel(5, "David Mitchell", 46),
            new CustomerModel(6, "Bill Bailey", 55)
         };
        // GET: Customer
        public ActionResult Index()
        {
            Tuple<List<CustomerModel>, CustomerModel> customerTuple = new Tuple<List<CustomerModel>, CustomerModel>(customers, customers[0]);

            return View("Customer", customerTuple);
        }

        [HttpPost]
        public ActionResult onSelectCustomer(string customer)
        {
            CustomerModel selectedCustomer = customers[Convert.ToInt32(customer)];
            Tuple<List<CustomerModel>, CustomerModel> customerTuple = new Tuple<List<CustomerModel>, CustomerModel>(customers, selectedCustomer);
            return PartialView("_CustomerDetails", customerTuple.Item2);
        }

        [HttpPost]
        public string GetMoreInfo(string customerId)
        {
            return "We interupt your daily programming for this very important vanity message!";
        }
    }
}
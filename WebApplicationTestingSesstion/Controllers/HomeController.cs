using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTestingSesstion.Models;
using Newtonsoft.Json;

namespace WebApplicationTestingSesstion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNew(Employee employee)
        {
            List<Employee> employees = new List<Employee>();

            if(!string.IsNullOrEmpty(HttpContext.Session.GetString("employeesList")))
            {
                var session = HttpContext.Session.GetString("employeesList");

                employees=JsonConvert.DeserializeObject<List<Employee>>(session);
            }

            employees.Add(employee);

            HttpContext.Session.SetString("employeesList", JsonConvert.SerializeObject(employees));

            return Json(employees);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

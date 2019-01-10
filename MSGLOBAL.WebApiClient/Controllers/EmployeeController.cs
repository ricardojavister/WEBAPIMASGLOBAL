using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using MSGLOBAL.RepositoryPattern.Model;
using MSGLOBAL.Business;

namespace MSGLOBAL.WebApiClient.Controllers
{
    public class searchby
    {
        public int id { get; set; }
    }

    public class EmployeeController : Controller
    {
        // GET: Employee1
        public ActionResult Index()
        {
            return View(GetEmployee());
        }

        [HttpPost]
        public JsonResult Index(searchby employee)
        {          
            IEnumerable<Employee> listOfEmployees;
            listOfEmployees = GetEmployee();
            if (employee.id != 0)
            {
                listOfEmployees = listOfEmployees.Where(s => s.id == employee.id).ToList();
            }
            return Json(listOfEmployees, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Employee> GetEmployee()
        {
            IEnumerable<Employee> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");

                //Called Member default GET All records
                //GetAsync to send a GET request 
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                //To store result of web api response. 
                var result = responseTask.Result;

                //If success received 
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();

                    employees = readTask.Result;
                }
                else
                {
                    //Error response received 
                    employees = Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return EmployeeBusiness.GetEmployees(employees);

        }
    }
}
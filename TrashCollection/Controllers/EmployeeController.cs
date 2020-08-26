using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        public ApplicationDbContext db;

        public EmployeeController(DbContextOptions<ApplicationDbContext> options)
        {
            db = new ApplicationDbContext(options);
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employee = db.Employee.Where(c => c.IdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))?.SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.Employee = employee;
            mymodel.Pickups = GetPickups(employee);
            mymodel.PickupAddresses = GetPickups(employee).Select(l => l.Address + ", " + l.City + ", " + l.ZipCode).ToList();
            mymodel.Customers = db.Customer.ToList();
            return View(mymodel);
        }

        public ActionResult AllCustomers()
        {
            List<Customer> customers = db.Customer.ToList();
            return View(customers);
        }

        public List<Customer> GetPickups(Employee employee)
        {
            DateTime today = new DateTime();
            today = DateTime.Today;
            Customer customer = db.Customer.Where(c => c.Id == 1).FirstOrDefault();
            int valu = customer.LastPickup.AddDays(7).CompareTo(today);
            List<Customer> customers = new List<Customer>();
            customers = db.Customer.Where(c => (c.ZipCode == employee.ServiceZip) && 
            (c.PickupDay == today.DayOfWeek && c.LastPickup.AddDays(7).CompareTo(today) <= 0 || (c.OneTimePickup == today && c.PendingOneTimePickup == true))).ToList();
            return customers;
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Customer.Where(c => c.Id == id).FirstOrDefault());
        }

        public ActionResult Complete(int idCust, int idEmp)
        {
            try
            {
                Customer customer = db.Customer.Where(c => c.Id == idCust).FirstOrDefault();
                customer.MonthBalance += 5;
                customer.LastPickup = DateTime.Today;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CompleteOneTime(int idCust, int idEmp)
        {
            try
            {
                Customer customer = db.Customer.Where(c => c.Id == idCust).FirstOrDefault();
                customer.MonthBalance += 5;
                customer.PendingOneTimePickup = false;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                employee.IdentityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

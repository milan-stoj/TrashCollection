using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
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
            mymodel.Employee = db.Employee.Where(c => c.IdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))?.SingleOrDefault();
            mymodel.Pickups = GetPickups();
            return View(mymodel);
        }

        public List<Customer> GetPickups()
        {
            DateTime today = new DateTime();
            today = DateTime.Today;
            List<Customer> customers = new List<Customer>();
            customers = db.Customer.Where(c => c.PickupDay == today.DayOfWeek).ToList();
            return customers;
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
    }
}

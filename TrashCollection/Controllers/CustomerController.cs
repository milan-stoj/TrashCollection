using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    [Authorize(Roles = "Customer")]

    public class CustomerController : Controller
    {
        public ApplicationDbContext db;

        public CustomerController(DbContextOptions<ApplicationDbContext> options)
        {
            db = new ApplicationDbContext(options);
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customer = db.Customer.Where(c => c.IdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))?.SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                customer.IdentityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomerDetails(int id, IFormCollection collection)
        {
            try
            {
                Customer customer = db.Customer.Where(c => c.Id == id).FirstOrDefault();
                customer.Name = collection["Name"];
                customer.Address = collection["Address"];
                customer.City = collection["City"];
                customer.State = collection["State"];
                customer.ZipCode = collection["ZipCode"];
                customer.PickupDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), collection["PickupDay"]);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSuspension(int id, IFormCollection collection)
        {
            try
            {
                Customer customer = db.Customer.Where(c => c.Id == id).FirstOrDefault();
                customer.SuspendStart = DateTime.Parse(collection["SuspendStart"]);
                customer.SuspendEnd = DateTime.Parse(collection["SuspendEnd"]);
                customer.ServiceSuspended = true;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClearSuspension(int id)
        {
            try
            {
                Customer customer = db.Customer.Where(c => c.Id == id).FirstOrDefault();
                customer.SuspendStart = DateTime.Today;
                customer.SuspendEnd = DateTime.Today;
                customer.ServiceSuspended = false;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOneTimePickup(int id, IFormCollection collection)
        {
            try
            {
                Customer customer = db.Customer.Where(c => c.Id == id).FirstOrDefault();
                customer.OneTimePickup = DateTime.Parse(collection["OneTimePickup"]);
                customer.PendingOneTimePickup = true;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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

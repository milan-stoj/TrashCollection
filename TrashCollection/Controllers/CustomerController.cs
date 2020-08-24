using System;
using System.Collections.Generic;
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
            if (db.Customer.Count() == 0)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(db.Customer.Where(c => c.IdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault());
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

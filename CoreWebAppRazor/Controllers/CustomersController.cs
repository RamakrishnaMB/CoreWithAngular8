using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreDataLayer.ModelsDB;
using CoreDataLayer.Interface;
using Models;
using CoreBusinessLogic.Interface;
using Configuration.EmailConfig;
using Configuration.EmailConfig.Interface;

namespace CoreWebAppRazor.Controllers
{
    public class CustomersController : Controller
    {
        private readonly dbTestContext _context;
        private readonly ICustomerService _CustomerService;
        private readonly IEmailService emailService;

        public CustomersController(dbTestContext context, ICustomerService customerService, IEmailService emailService)
        {
            _context = context;
            _CustomerService = customerService;
            this.emailService = emailService;
        }

        public ActionResult Index()
        {
            var listCustomers = _CustomerService.GetCustomers();
            EmailMessage emailMessage = new EmailMessage();

            emailMessage.ToAddresses = new List<EmailAddress> { new EmailAddress
            {
                Name = "Ramakrishna",
                Address = "ramakrishnamb@gmail.com"
            } };

            emailMessage.FromAddresses = new List<EmailAddress> { new EmailAddress{
                Address="ramakrishna.public@gmail.com"
            }
            };
            emailMessage.Subject = "Test email from dot net core";
            emailMessage.Content = "demo email body content with not content";
            this.emailService.Send(emailMessage);

            return View(listCustomers);
        }

        // GET: Customers
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Customers.ToListAsync());
        //}

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CustomersModel customers = await _CustomerService.FindCustomer(id);
            //var customers = await _context.Customers
            //    .FirstOrDefaultAsync(m => m.Cid == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Customers/Create
        //public async Task<IActionResult> Create([Bind("Cid,Name,Telephone")] Customers customers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(customers);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customers);
        //}

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Telephone")] CustomersModel customer)
        {
            if (ModelState.IsValid)
            {
                await _CustomerService.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customers = await _CustomerService.FindCustomer(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customers = await _context.Customers.FindAsync(id);
        //    if (customers == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customers);
        //}

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cid,Name,Telephone")] CustomersModel customers)
        {
            if (id != customers.Cid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _CustomerService.UpdateCustomer(customers);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_CustomerService.CustomersExists(customers.Cid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CustomersModel customers = await _CustomerService.FindCustomer(id);
            // var customers = await _context.Customers
            //   .FirstOrDefaultAsync(m => m.Cid == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _CustomerService.DeleteConfirmedCustomer(id);
            //   var customers = await _context.Customers.FindAsync(id);
            //_context.Customers.Remove(customers);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool CustomersExists(int id)
        //{
        //    return _context.Customers.Any(e => e.Cid == id);
        //}
    }
}

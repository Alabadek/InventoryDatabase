using BootCamp2024.Models;
using BootCamp2024.Services;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2024.Controllers
{
    public class CustomerController : Controller
    {
        
        public CustomerController()
        {

        }

        public IActionResult Index()
        {
            CustomerService customerService = new CustomerService();

            List<Customer> customers = customerService.GetCustomers();

            return View(customers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            CustomerService service = new CustomerService();

            service.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            CustomerService service = new CustomerService();

            Customer customer = service.GetCustomer(id);

            return View(customer);
        }


        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            CustomerService services = new CustomerService();
            services.EditCustomer(customer);
            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            CustomerService service = new CustomerService();
            service.DeleteCustomer(id);
            return RedirectToAction("Index");
            return View();
        }

    }
}

using Castle.Core.Resource;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class SalesController : Controller
    {
        private readonly IService<SaleInfo> _service;
        private readonly IService<Vehicle> _serviceVehicle;
        private readonly IService<Customer> _serviceCustomer;


        public SalesController(IService<SaleInfo> service, IService<Vehicle> serviceVehicle, IService<Customer> serviceCustomer)
        {
            _service = service;
            _serviceVehicle = serviceVehicle;
            _serviceCustomer = serviceCustomer;
        }

        // GET: SalesController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.VerticleId= new SelectList(await _serviceVehicle.GetAllAsync(), "Id","Model");
            ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Firstname");

            return View();
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(SaleInfo saleInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(saleInfo);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.VerticleId = new SelectList(await _serviceVehicle.GetAllAsync(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Firstname");

            return View(saleInfo);
        }

        // GET: SalesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.VerticleId = new SelectList(await _serviceVehicle.GetAllAsync(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Firstname");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, SaleInfo saleInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     _service.Update(saleInfo);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.VerticleId = new SelectList(await _serviceVehicle.GetAllAsync(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(await _serviceCustomer.GetAllAsync(), "Id", "Firstname");

            return View(saleInfo);
        }

        // GET: SalesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }


        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SaleInfo saleInfo)
        {
            try
            {
                _service.Delete(saleInfo);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

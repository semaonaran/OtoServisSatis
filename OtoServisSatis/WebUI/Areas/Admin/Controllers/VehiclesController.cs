using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]

    public class VehiclesController : Controller
    {
        
        private readonly IService<Vehicle> _service;
        private readonly IService<Brand> _serviceBrand;


        public VehiclesController(IService<Vehicle> service, IService<Brand> serviceBrand)
        {
            _service = service;
            _serviceBrand = serviceBrand;
        }

        // GET: VehiclesController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // GET: VehiclesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiclesController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(),"Id","Name");
            return View();
        }

        // POST: VehiclesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    await _service.AddAsync(vehicle);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(),"Id","Name");
            return View(vehicle);
        }

        // GET: VehiclesController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            var model = await _service.FindAsync(id);
            return View(model);
        }


        // POST: VehiclesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                try
                {

                     _service.Update(vehicle);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(vehicle);
        }

        // GET: VehiclesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: VehiclesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Vehicle vehicle)
        {
            try
            {
                _service.Delete(vehicle);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

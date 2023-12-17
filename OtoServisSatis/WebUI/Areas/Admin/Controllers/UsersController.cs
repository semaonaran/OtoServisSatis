using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Abstract;
using System.Data;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]

    public class UsersController : Controller
    {
        private readonly IService<User> _service;
        private readonly IService<Role> _serviceRole;


        public UsersController(IService<User> service, IService<Role> serviceRole)
        {
            _service = service;
            _serviceRole = serviceRole;
        }

        // GET: UsersController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.RoleId = new SelectList( await _serviceRole.GetAllAsync(),"Id","Name");
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(user);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.RoleId = new SelectList(await _serviceRole.GetAllAsync(), "Id", "Name");

            return View(user);
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model= await _service.FindAsync(id);
            ViewBag.RoleId = new SelectList(await _serviceRole.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(user);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.RoleId = new SelectList(await _serviceRole.GetAllAsync(), "Id", "Name");

            return View(user);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                _service.Delete(user);
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

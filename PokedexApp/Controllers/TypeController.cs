using Database;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Servicios;
using ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexApp.Controllers
{
    public class TypeController : Controller
    {
        private readonly Type1Service _typeservice;

        public TypeController(PokedexContext dbContext)
        {
            _typeservice = new(dbContext);
        }

        public async Task<IActionResult> Types()
        {
            return View(await _typeservice.GetAllViewModel());
        }

        public IActionResult Create()
        {

            return View("SaveType", new SaveType1ViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveType1ViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }
            await _typeservice.Add(vm);
            return RedirectToRoute(new { controller = "Type", action = "Types" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveType", await _typeservice.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveType1ViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }
            await _typeservice.Update(vm);
            return RedirectToRoute(new { controller = "Type", action = "Types" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typeservice.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _typeservice.Delete(id);
            return RedirectToRoute(new { controller = "Type", action = "Types" });
        }
    }
}

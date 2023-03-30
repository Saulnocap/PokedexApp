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
    public class RegionController : Controller
    {
        private readonly RegionService _regionservice;

        public RegionController(PokedexContext dbContext)
        {
            _regionservice = new(dbContext);
        }

        public async Task<IActionResult> Regiones()
        {
            return View(await _regionservice.GetAllViewModel());
        }

        public IActionResult Create()
        {

            return View("SaveRegion", new SaveRegionViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regionservice.Add(vm);
            return RedirectToRoute(new { controller = "Region", action = "Regiones" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionservice.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regionservice.Update(vm);
            return RedirectToRoute(new { controller = "Region", action = "Regiones" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionservice.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionservice.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Regiones" });
        }
    }
}

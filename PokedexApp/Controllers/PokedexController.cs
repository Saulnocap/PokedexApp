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
    public class PokedexController : Controller
    {

        private readonly PokemonService _pokemonservice;

        public PokedexController(PokedexContext dbContext)
        {
            _pokemonservice = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokemonservice.GetAllViewModel());
        }

        public async Task<IActionResult> Pokemones()
        {
            return View(await _pokemonservice.GetAllViewModel());
        }
        
        public IActionResult Create()
        {
           
            return View("SavePokemon",new SavePokemonViewModel());
        }
        [HttpPost]
        public async Task <IActionResult> Create(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonservice.Add(vm);
            return RedirectToRoute(new { controller = "Pokedex", action = "Pokemones" });          
        }

        public async Task<IActionResult> Edit(int id)
        {
           return View("SavePokemon", await _pokemonservice.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonservice.Update(vm);
            return RedirectToRoute(new { controller = "Pokedex", action = "Pokemones" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonservice.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonservice.Delete(id);
            return RedirectToRoute(new { controller = "Pokedex", action = "Pokemones" });
        }
    }
}

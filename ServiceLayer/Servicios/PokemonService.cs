using Database;
using Database.Models;
using ServiceLayer.Repos;
using ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Servicios
{
    public class PokemonService
    {

        private readonly PokemonRepos _pokemonrepos;

        public PokemonService(PokedexContext dbContext)
        {
            _pokemonrepos = new(dbContext);
        }

        public async Task Add(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
                pokemon.Name = vm.Name;
                pokemon.ImgUrl = vm.ImgUrl;
                pokemon.RegionId = vm.RegionId;
                pokemon.Type1id = vm.Type1id;
            await _pokemonrepos.AddAsync(pokemon);
        }
        public async Task Update(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Name = vm.Name;
            pokemon.ImgUrl = vm.ImgUrl;
            pokemon.RegionId = vm.RegionId;
            pokemon.Type1id = vm.Type1id;
            await _pokemonrepos.UpdateAsync(pokemon);
        }
        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonrepos.GetByIdAsync(id);

            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.ImgUrl = pokemon.ImgUrl;
            vm.RegionId = pokemon.RegionId;
            vm.Type1id = pokemon.Type1id;
            return vm;
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonrepos.GetByIdAsync(id);
            await _pokemonrepos.DeleteAsync(pokemon);
        }


        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var Pokemonlist = await _pokemonrepos.GetAllAsync();

            return Pokemonlist.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImgUrl = pokemon.ImgUrl

            }).ToList();
        }
    }

}


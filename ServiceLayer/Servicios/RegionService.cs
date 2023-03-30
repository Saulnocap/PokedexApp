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
    public class RegionService
    {

        private readonly RegionRepos _regionrepos;

        public RegionService(PokedexContext dbContext)
        {
            _regionrepos = new(dbContext);
        }

        public async Task Add(SaveRegionViewModel vm)
        {
            Region region = new();
            region.Name = vm.Name;
            await _regionrepos.AddAsync(region);
        }
        public async Task Update(SaveRegionViewModel vm)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;
            await _regionrepos.UpdateAsync(region);
        }
        public async Task<SaveRegionViewModel> GetByIdSaveViewModel(int id)
        {
            var region = await _regionrepos.GetByIdAsync(id);

            SaveRegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Name = region.Name;
            return vm;
        }

        public async Task Delete(int id)
        {
            var region = await _regionrepos.GetByIdAsync(id);
            await _regionrepos.DeleteAsync(region);
        }


        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var Regionlist = await _regionrepos.GetAllAsync();

            return Regionlist.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name

            }).ToList();
        }
    }

}

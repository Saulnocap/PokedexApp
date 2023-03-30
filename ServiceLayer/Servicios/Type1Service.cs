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
    public class Type1Service
    {

        private readonly Type1Repos _typerepos;

        public Type1Service(PokedexContext dbContext)
        {
            _typerepos = new(dbContext);
        }

        public async Task Add(SaveType1ViewModel vm)
        {
            Type1 type = new();
            type.Name = vm.Name;
            type.Opcional = vm.Opcional;
            await _typerepos.AddAsync(type);
        }
        public async Task Update(SaveType1ViewModel vm)
        {
            Type1 type = new();
            type.Id = vm.Id;
            type.Name = vm.Name;
            type.Opcional = vm.Opcional;
            await _typerepos.UpdateAsync(type);
        }
        public async Task<SaveType1ViewModel> GetByIdSaveViewModel(int id)
        {
            var type = await _typerepos.GetByIdAsync(id);

            SaveType1ViewModel vm = new();
            vm.Id = type.Id;
            vm.Name = type.Name;
            vm.Opcional = type.Opcional;
            return vm;
        }

        public async Task Delete(int id)
        {
            var type = await _typerepos.GetByIdAsync(id);
            await _typerepos.DeleteAsync(type);
        }


        public async Task<List<Type1ViewModel>> GetAllViewModel()
        {
            var Typelist = await _typerepos.GetAllAsync();

            return Typelist.Select(type => new Type1ViewModel
            {
                Id = type.Id,
                Name = type.Name,
                Opcional = type.Opcional

            }).ToList();
        }
    }

}

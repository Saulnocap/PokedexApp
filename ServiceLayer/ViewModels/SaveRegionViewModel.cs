using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class SaveRegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Coloque el nombre de la Region")]
        public string Name { get; set; }

    }
}

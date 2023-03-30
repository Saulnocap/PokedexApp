using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Coloque el nombre del pokemon")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Coloque la imagen del pokemon")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Coloque la region del pokemon")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Coloque el/los tipos del pokemon")]
        public int Type1id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ViewModels
{
    public class SaveType1ViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Coloque el nombre del tipo principal")]
        public string Name { get; set; }
        public string Opcional { get; set; }

    }
}

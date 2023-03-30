using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Type1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Opcional { get; set; }

        //navigation properties
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}

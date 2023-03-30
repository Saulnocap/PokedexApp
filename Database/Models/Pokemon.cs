using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int RegionId { get; set; }
        public int Type1id { get; set; }

        //navigation properties

        public Region Region { get; set; }
        public Type1 Type1 { get; set; }

    }
}

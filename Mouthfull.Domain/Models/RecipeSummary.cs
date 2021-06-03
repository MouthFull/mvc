using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouthfull.Domain.Models
{
   public class RecipeSummary
    {
        public int id { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public bool Favorite { get; set; }
        public string Comment { get; set; }
        public int EntityId { get; set; }

    }
}

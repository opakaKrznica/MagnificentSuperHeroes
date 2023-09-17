using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnificentSuperHeroes.Shared
{
    public class Team
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please give this character a name. Thanks! :)")]
        public string Name { get; set; } = string.Empty;
    }
}

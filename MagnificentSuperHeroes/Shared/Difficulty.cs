using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnificentSuperHeroes.Shared
{
    public class Difficulty
    {
        [Required, Range(1, int.MaxValue, ErrorMessage = "The Id can't be smaller than 1!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please give this character a name. Thanks! :)")]
        public string Title { get; set; } = string.Empty;
    }
}

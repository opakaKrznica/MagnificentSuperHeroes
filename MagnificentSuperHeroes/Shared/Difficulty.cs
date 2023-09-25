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
       
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
    }
}

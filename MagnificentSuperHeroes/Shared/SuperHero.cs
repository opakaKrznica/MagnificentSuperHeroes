﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnificentSuperHeroes.Shared
{
    public class SuperHero
    {
        //[Required, Range(1, int.MaxValue, ErrorMessage = "The Id can't be smaller than 1!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please give this hero a name. Thanks! :)")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please give this hero a name. Thanks! :)")]
        public string HeroName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; } = DateTime.Now;
        public string Image { get; set; } = string.Empty;
        public Team Team { get; set; } 
        public Difficulty Difficulty { get; set; }        

        public Comic Comic  { get; set; }
        public int ComicId { get; set; } = 1;

        public int TeamId { get; set; } = 1;
        public int DifficultyId { get; set; } = 1;

        public bool IsReadyToFight { get; set; } = true;


    }
}

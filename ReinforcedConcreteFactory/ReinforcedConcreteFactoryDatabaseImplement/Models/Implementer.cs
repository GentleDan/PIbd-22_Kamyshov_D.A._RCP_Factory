﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReinforcedConcreteFactoryDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }

        [Required]
        public string ImplementerFIO { get; set; }

        [Required]
        public int WorkingTime { get; set; }

        [Required]
        public int PauseTime { get; set; }

        [ForeignKey("ImplementerId")]
        public List<Order> Orders { get; set; }
    }
}

﻿using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFModels
{
    public class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Documento { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public string Nombres { get; set; } = "";
        
        [MaxLength(128), MinLength(3), Required]
        public string Apellidos { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public string Direccion { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Telefono { get; set; } = "";

        public List<Vehiculos> Vehiculos { get; set; }
    }
}

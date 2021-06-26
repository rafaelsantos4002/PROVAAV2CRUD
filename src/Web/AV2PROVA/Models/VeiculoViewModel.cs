using Dominio.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AV2PROVA.Models
{
    public class VeiculoViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório!")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório!")]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório!")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "*Campo Obrigatório!")]
        [DisplayName("Quilometragem")]
        public string Quilometragem { get; set; }

    }
}


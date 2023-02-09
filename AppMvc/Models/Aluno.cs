﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMvc.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Nome Completo")]
        [Required(ErrorMessage ="O campo {0} é requerido")]
        [MaxLength(100,ErrorMessage = "No Maximo 100 caracteres")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string CPF { get; set; }

        public string Descricao { get; set; }

        public DateTime DataMatricula { get; set; }
        public bool Ativo { get; set; }
    }
}
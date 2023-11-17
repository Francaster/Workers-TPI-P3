﻿using System.ComponentModel.DataAnnotations;

namespace ConsultaTrabajadores.Presentacion.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? UserType { get; set; }
    }
}

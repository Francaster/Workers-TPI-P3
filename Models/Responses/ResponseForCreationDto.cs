﻿using System.ComponentModel.DataAnnotations;

namespace ConsultaTrabajadores.Presentacion.Models.Responses
{
    public class ResponseForCreationDto
    {
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = string.Empty;
    }
}

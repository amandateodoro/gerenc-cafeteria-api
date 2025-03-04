﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CafeManiaApi.Dtos
{
    public class LoginDto
    {
        [Required]
        [MinLength(5)]
        public required string Username { get; set; }

        [Required]
        [MinLength(5)]
        public required string Password { get; set; }
    }
}

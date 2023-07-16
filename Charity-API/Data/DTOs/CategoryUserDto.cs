﻿using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class CategoryUserDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}

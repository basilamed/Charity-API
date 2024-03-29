﻿using Charity_API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class DonationDto
    {
        public DateTime DonationDate { get; set; }
        [Required]
        public double DonationAmount { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string DonatorId { get; set; }
    }
}

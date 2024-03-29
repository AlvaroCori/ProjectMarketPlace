﻿using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.InternModels
{
    public partial class User
    {
        public int Id { get; set; }

        public string? UserCode { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}


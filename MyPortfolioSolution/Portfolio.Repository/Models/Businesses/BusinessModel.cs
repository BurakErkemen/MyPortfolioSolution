﻿namespace Portfolio.Repositories.Models.Businesses
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Hâlâ çalışıyorsa nullable
    }
}

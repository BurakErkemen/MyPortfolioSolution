﻿using Portfolio.Repositories.Models.AboutMe;

namespace Portfolio.Repositories.Models.Businesses
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = default!;
        public string Position { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // AboutMe ile ilişki
        public int AboutMeId { get; set; }
        public AboutMeModel? AboutMe { get; set; } 
    }
}
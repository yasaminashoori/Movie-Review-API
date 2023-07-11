using System;

namespace movie_review_api.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
    }
}

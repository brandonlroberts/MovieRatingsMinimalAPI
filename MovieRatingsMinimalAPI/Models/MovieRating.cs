using MovieRatingsMinimalAPI.Models.Base;

namespace MovieRatingsMinimalAPI.Models
{
    public class MovieRating : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string ImagePosterUrl { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}

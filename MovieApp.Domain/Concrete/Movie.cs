using MovieApp.Domain.Abstract;

namespace MovieApp.Domain.Concrete
{
    public class Movie : BaseEntity
    {
        public Guid ApiId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public int PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public double VoteOverage { get; set; }
        public int VoteCount { get; set; }
    }
}

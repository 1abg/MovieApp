using MovieApp.Domain.Abstract;

namespace MovieApp.Domain.Concrete
{
    public class MovieNote : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public string Note { get; set; }


        // relations
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

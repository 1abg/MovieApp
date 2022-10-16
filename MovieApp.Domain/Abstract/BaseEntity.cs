namespace MovieApp.Domain.Abstract
{
    public abstract class BaseEntity
    {
        private Guid _defaultValue = Guid.NewGuid();
        public Guid Id { get => _defaultValue; set => _defaultValue = value; }
    }
}

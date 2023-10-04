using Domain.Interfaces;

namespace Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public virtual int Id { get; set; }
    }
}

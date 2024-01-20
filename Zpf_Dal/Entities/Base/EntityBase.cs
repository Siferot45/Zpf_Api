using Zpf_Interfaces;

namespace Zpf_Dal.Entities.Base
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}

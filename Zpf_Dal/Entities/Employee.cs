using Zpf_Dal.Entities.Base;

namespace Zpf_Dal.Entities
{
    internal class Employee : NameBase
    {
        public int Age { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Position { get; set; }
    }
}

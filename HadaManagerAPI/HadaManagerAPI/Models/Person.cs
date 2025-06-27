using HadaManagerAPI.Models.Interfaces;

namespace HadaManagerAPI.Models
{
    public sealed class Person : IIndexable
    {
        public required Guid Id { get; init; }
        public required string Name { get; set; }
    }
}

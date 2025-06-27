using HadaManagerAPI.Models.Interfaces;

namespace HadaManagerAPI.Models
{
    public sealed class Room : IIndexable
    {
        public required Guid Id { get; init; }
        public required string Name { get; set; }
        public required int Capacity { get; set; }
        public int Occupancy { get; set; }
    }
}

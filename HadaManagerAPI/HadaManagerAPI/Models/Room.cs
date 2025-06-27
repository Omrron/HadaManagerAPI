namespace HadaManagerAPI.Models
{
    public sealed class Room
    {
        public required string Name { get; set; }
        public required Guid Id { get; init; }
        public required int Capacity { get; set; }
        public int Occupancy { get; set; }
    }
}

namespace JLAHeadquarters.StorageApp.Entities
{
    public class Villian: EntityBase
    {
        public string? VillianName { get; set; }

        public override string ToString() => $"Id: {Id}, Villian Name: {VillianName}";
    }
}


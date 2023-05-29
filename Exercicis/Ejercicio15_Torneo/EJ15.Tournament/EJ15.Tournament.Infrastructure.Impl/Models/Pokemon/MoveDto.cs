namespace EJ15.Tournament.Infrastructure.Impl.Models.Pokemon
{
    public class MoveDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Accuracy { get; set; }
        public int? Power { get; set; }
        public MoveTypeDto Type { get; set; }
    }
}

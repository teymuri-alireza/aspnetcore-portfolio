namespace MyPortfolio.Models.Entities
{
    public class Coffee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Price { get; set; }
        public required bool Available { get; set; }
        public required Category Type { get; set; }
        public required string ImagePath { get; set; }
    }
    public enum Category
    {
        Hot,
        Iced
    }
}

namespace MyPortfolio.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Telegram { get; set; }
        public required string Location { get; set; }
    }
}

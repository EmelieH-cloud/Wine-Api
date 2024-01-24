namespace Wine_Api.Models
{
    public class Wine
    {
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public string? Description { get; set; }
    }
}

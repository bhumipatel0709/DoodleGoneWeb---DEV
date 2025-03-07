using System.ComponentModel.DataAnnotations;

namespace DoodleGone.Models
{
    public class Eraser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Colour { get; set; }
        public string? Size { get; set; }
        public string? Durability { get; set; }
        public decimal Price { get; set; }
    }
}
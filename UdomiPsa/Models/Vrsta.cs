using System.ComponentModel.DataAnnotations;

namespace UdomiPsa.Models
{
    public class Vrsta
    {
        [Key]
        public int Id { get; set; }
        public string VrstaPsa { get; set; }
        public string? ImageFileName { get; set; }

        public ICollection<Pas> Pasi { get; set; }

    }
}

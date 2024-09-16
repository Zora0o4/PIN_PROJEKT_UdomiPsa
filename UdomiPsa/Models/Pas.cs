using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdomiPsa.Models
{
    public class Pas
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string? Godine { get; set; }
        public bool Udomljen { get; set; }
        public int VrstaId { get; set; }
        [ForeignKey("VrstaId")]


        [NotMapped]
        public string? VrstaPesa { get; set; }

        public virtual Vrsta Vrsta { get; set; } // Navigacijsko svojstvo
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace UdomiPsa.Models
{
    public class PasDbo
    {
        public string Ime { get; set; }
        public string? Godina { get; set; }
        public bool Udomljen { get; set; }
        public string? VrstaCuke { get; set; }

        public IEnumerable<SelectListItem> Vrst {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }


        [Required(ErrorMessage = "Wpisz rodzaj towaru")]
        [MaxLength(30, ErrorMessage = "Rodzaj towaru może zawierać max 30 znaków")]
        public required string Nazwa { get; set; }

        public string Opis { get; set; } = string.Empty;

        // to jest obsługa relacji jeden do wielu po stronie wielu 
        // rodzaj ma wiele towarów danego rodzaju 

        public ICollection<Towar> Towar { get; } = new List<Towar>();

        // koniec klucza obcego po stronie wielu
    }
}

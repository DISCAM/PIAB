using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowaru { get; set; }

        // to jest obsługa relacji jeden do wielu
        // kod po stronie jednego - towar ma jeden rodzaj 

        [ForeignKey("Rodzaj")]
        public int IdRodzaju { get; set; }
        public Rodzaj? Rodzaj { get; set; }

        // koniec klucza obcego po stronie jeden 

        [Required(ErrorMessage = "Wpisz kod")]
        public required string Kod { get; set; }

        [Required(ErrorMessage = "Wpisz nzwę towaru")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Wpisz cenę towaru")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
        public string Opis { get; set; } = string.Empty;

        [Required(ErrorMessage = "Dodaj zdjęcie")]
        [Display(Name = " wybierz zdjęcie")]
        public required string FotoUrl { get; set; }
    }
}

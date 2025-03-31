using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Aktualnosc
    {
        [Key]  // to co niżej bedzie kluczem głównym
        public int IdAktulanosci { get; set; }


        [Required(ErrorMessage = "Tytuł odniśnika jest wymagany")] // pole nie może być puste
        [MaxLength(10, ErrorMessage = "Link może zawierać max 10 znaków")] // pole nie może być dłuższe niż 10 znaków
        [Display(Name = "Tytuł odnośnika")]  // tak ma nazywać sie pole widoczne na interface   
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł aktulaności jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytuł może zwierać max 50 znaków")]
        [Display(Name = "Tytuł aktulaności")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")] /// tu decydujemy o typie danych w bazie danych
        public required string Tresc { get; set; }

        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycje wyświetlania")]
        public int Pozycja { get; set; }
    }
}

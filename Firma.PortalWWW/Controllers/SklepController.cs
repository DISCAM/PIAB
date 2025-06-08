using Firma.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context;
        
        public SklepController(FirmaContext context)
        {
            _context = context;
        }

        // to jest funkcja która dostarcza danych widokowi index 
        // bedzie on wyświetlł wszyskie towary z bazy danych
        // o danym id podanego jako parametr 

        public async Task<IActionResult> Index(int? id)
        {
            // pobieramy z bazy danch wszyskie rodzaje towarów posortowane względem pozycji
            // i przekazujemy je do widoku za pomocą ViewBag > tu zapiszemy wszykie rodzaje towarów 
            ViewBag.ModelRodzaje  = await _context.Rodzaj.ToListAsync();

            // id bedzie wypełniany przy każdym klinkeciu na dany rodzaj towaru
            // ale przy pierwsym wejsciu na strone id bedzie null

            if (id == null)
            {
                id = 1; // wtedy id przyjmuje wartość 1
            }

            // za bazy danych pobieramy wszystkie towary z danego rodzaju

            var item = await _context.Towar.Where(t => t.IdRodzaju == id).ToListAsync();

            return View(item);
        }
    }
}

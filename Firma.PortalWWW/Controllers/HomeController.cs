using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Firma.PortalWWW.Models;
using Firma.Data;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FirmaContext _context;

    public HomeController(ILogger<HomeController> logger, FirmaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(int? id) // jako parametr funcka dostaje Id strony któa zostaje klienknieta 
    {
        //ViewBag.ModelStrony = 
        //    (
        //    from strona in _context.Strona // dla każdej pozycji z bazy danych context stron
        //    orderby strona.Pozycja // posortowanej wzgledem pozycji 
        //    select strona // pobieramy stronę
        //    ).ToList();
        // krótki sposób 

        ViewBag.ModelStrony = await _context.Strona.OrderBy(s => s.Pozycja).ToListAsync();


        //ViewBag.ModelAktulanosci =
        //    (
        //    from aktulanosc in _context.Aktualnosc // dla każdej pozycji z bazy danych context aktualności
        //    orderby aktulanosc.Pozycja descending // posortowanej wzgledem pozycja 
        //    select aktulanosc // pobieramy aktualność
        //    ).Take(4).ToList(); // pobieramy 4 aktualności

        ViewBag.ModelAktualnosci = await _context.Aktualnosc.OrderByDescending(a => a.Pozycja).Take(4).ToListAsync();

        if(id == null) // id jest null przy pierwszym uruchomienieu strony
        {
            //id = _context.Strona.Min(s => s.Id); // id przyjmuje wartość minimalną z bazy danych
            id = 1;
        }
        // asynchronicznie odnajduje w bazie dancy stronę o damym ID 
        var item = await _context.Strona.FindAsync(id);
        //odnalezioną stronę o danym id przekzaujemu do widoku 

        return View(item); // jak funkcja nazywa sie index to strone też przekazuje do widiku o nazwie index
    }

    public IActionResult OpisFirmy()
    { 
        return View(); 
    }

    public IActionResult HistoriaFirmy()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

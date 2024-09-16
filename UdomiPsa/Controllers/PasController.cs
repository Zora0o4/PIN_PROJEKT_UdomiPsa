using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UdomiPsa.Models;

namespace UdomiPsa.Controllers
{
    [Authorize]
    public class PasController : Controller
    {
        MyContext my_context;
        public PasController(MyContext context)
        {
            my_context = context;
        }

        public IActionResult VrstePasa()
        {
            List<Vrsta> vrstePasa = my_context.Vrstas.ToList();
            return View(vrstePasa);
        }

        public async Task<IActionResult> Index()
        {
            var psi = await my_context.Pass.Include(p => p.Vrsta).ToListAsync();
            return View(psi);
        }

        
        public IActionResult Pregled(int id) 
        {

           var psi = my_context.Pass
               .Include(p => p.Vrsta)  
               .Where(p => p.VrstaId == id)
               .ToList();
            return View(psi);  
            }

        [HttpGet]
        public IActionResult AddVrsta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVrsta(Vrsta v)
        {
            my_context.Vrstas.Add(v);
            my_context.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Pasmina je dodana";
            return View();
        }

        public IActionResult AddPas() 
        {
            ViewBag.getvrstu = my_context.Vrstas.ToList();
            return View();        
        }

        [HttpPost]
        public IActionResult AddPas(Pas p)
        {
            my_context.Pass.Add(p);
            my_context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("AddPas");

        }

        [HttpGet]
        public IActionResult Uredi(int id)
        {
            var pas = my_context.Pass
                .Include(p => p.Vrsta) 
                .FirstOrDefault(p => p.Id == id);

            if (pas == null)
            {
                return NotFound();
            }

            ViewBag.VrstaId = new SelectList(my_context.Vrstas, "Id", "VrstaPsa", pas.VrstaId);

            return View(pas);  
        }

        // POST: Uredi
        [HttpPost]
        public async Task<IActionResult> Uredi(Pas viewModel)
        {
            var p = await my_context.Pass
                .Include(p => p.Vrsta) // Učitaj povezana svojstva ako je potrebno
                .FirstOrDefaultAsync(p => p.Id == viewModel.Id);

            if (p is not null) 
            {
                p.Ime = viewModel.Ime;
                p.Godine = viewModel.Godine;
                p.VrstaId = viewModel.VrstaId;
                p.Udomljen = viewModel.Udomljen;

                await my_context.SaveChangesAsync();

            }
            return RedirectToAction("Index", "Pas");
        }


        public async Task<IActionResult> Obrisi(int id)
        {
            var pas = await my_context.Pass
                .Include(p => p.Vrsta) 
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pas is not null) 
            {   
                my_context.Pass.Remove(pas);
                await my_context.SaveChangesAsync();
            
            }
            return RedirectToAction("Index", "Pas" );
        }

        //public IActionResult Udomi()
        //{
        //    return View();
        //}
    }
}

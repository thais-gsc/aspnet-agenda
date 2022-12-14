using AssessmentAgendaAniversariosAspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentAgendaAniversariosAspNet.Controllers
{
    public class AmigoController : Controller
    {
        private readonly ModelContext context;

        public AmigoController(ModelContext _context)
        {
            context = _context;
        }

        // GET: AmigoController
        public ActionResult Index(string ordem, string pesquisa)
        {
            ViewData["OrdemAniversario"] = ordem;
            ViewData["Filtro"] = pesquisa;

            DateTime hoje = DateTime.Today;
            //var amigos = from a in context.Amigos select a;
            var listaAmigos = context.Amigos.ToList();
            var amigosOrdenados = listaAmigos.OrderBy(amigos => amigos.DiasAteAniversario()).ToList();


            if (!String.IsNullOrEmpty(pesquisa))
            {
                amigosOrdenados = context.Amigos.Where(a => a.Nome.Contains(pesquisa) || a.Sobrenome.Contains(pesquisa)).ToList();
            }

            return View(amigosOrdenados);
        }

        // GET: AmigoController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigo = context.Amigos.FirstOrDefault(a => a.Id == id);

            if(amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // GET: AmigoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmigoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Amigo amigo)
        {
            try
            {
                context.Add(amigo);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AmigoController/Edit/5
        public ActionResult Edit(int id)
        {
            var amigo = context.Amigos.First(a => a.Id == id);

            return View(amigo);
        }

        // POST: AmigoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Amigo amigo)
        {
            var amigoEditado = context.Amigos.First(a => a.Id == id);
            
            amigoEditado.Nome = amigo.Nome;
            amigoEditado.Sobrenome = amigo.Sobrenome;
            amigoEditado.Aniversario = amigo.Aniversario;

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: AmigoController/Delete/5
        public ActionResult Delete(int id)
        {
            context.Amigos.Remove(context.Amigos.First(a => a.Id == id));

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: AmigoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

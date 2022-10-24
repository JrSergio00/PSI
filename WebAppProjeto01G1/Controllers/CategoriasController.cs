using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Modelo.Tabelas;
using Servico.Tabelas;
using System;

namespace WebAppProjeto01G1.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();
        /*private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
            new Categoria() { CategoriaId = 2, Nome = "Monitores"},
            new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
            new Categoria() { CategoriaId = 4, Nome = "Mouses"},
            new Categoria() { CategoriaId = 5, Nome = "Desktops"}
        };*/

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        //GET: Categorias/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaId(id);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaId(id);
        }

        //GET: Categorias/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaId(id);
        }

        //POST: Categorias/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private ActionResult ObterVisaoCategoriaId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria fabricante = categoriaServico.ObterCategoriaPorId((long)id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }


        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }
    }
}
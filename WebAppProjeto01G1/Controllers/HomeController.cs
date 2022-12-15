using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Modelo.Cadastros;
using Modelo.Tabelas;
using Servico.Cadastros;
using Servico.Tabelas;
using System.Net;
using System.IO;

namespace WebAppProjeto01G1.Controllers
{
    public class HomeController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        
        // GET: Home
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }
    }
}
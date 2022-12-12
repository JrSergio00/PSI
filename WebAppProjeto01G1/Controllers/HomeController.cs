using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppProjeto01G1.Controllers
{
    public class HomeController : Controller
    {
        private ProdutoServico produtoservico = new ProdutoServico();
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            return View(produtoservico.ObterProdutosClassificadosPorNome());
        }
    }
}
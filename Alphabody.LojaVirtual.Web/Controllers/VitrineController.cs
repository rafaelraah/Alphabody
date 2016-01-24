using Alphabody.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alphabody.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {

        ProdutosRepositorio _repositorio;
        public int produtosPorPagina = 2;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {

            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos
                .OrderBy(prod => prod.Nome)
                .Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina);
            
            

            return View(produtos);
        }
    }
}
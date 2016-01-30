using Alphabody.LojaVirtual.Dominio.Repositorio;
using Alphabody.LojaVirtual.Web.Models;
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
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {

            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel pvm = new ProdutosViewModel()
            {

                Produtos = _repositorio.Produtos
                .Where(prod => categoria == null || prod.Categoria == categoria)
                .OrderBy(prod => prod.Nome)
                .Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina),

                Paginacao = new Paginacao()
                {
                    ItensTotal = _repositorio.Produtos.Count(),
                    PaginaAtual = pagina,
                    ItensPorPagina = produtosPorPagina
                }

            };

            return View(pvm);
        }
    }
}
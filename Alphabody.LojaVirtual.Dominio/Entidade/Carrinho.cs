using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphabody.LojaVirtual.Dominio.Entidade
{
   public class Carrinho
    {

       private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>();

       //Adicionar
       public void AdicionarItem(Produto produtoAux, int quantidade)
       {

           ItemCarrinho item = _itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoID == produtoAux.ProdutoID);

           if (item == null)
           {
               _itensCarrinho.Add(new ItemCarrinho
               {

                   Produto = produtoAux,
                   Quantidade = quantidade

               });
           }
           else
           {

               item.Quantidade += quantidade;

           }


       }

       //Remover
       public void RemoverItem(Produto produtoAux)
       {

           _itensCarrinho.RemoveAll(p => p.Produto.ProdutoID == produtoAux.ProdutoID);

       }

       //Obter o valor total

       public decimal ObterValorTotal()
       {

           return _itensCarrinho.Sum(e => e.Produto.Preco*e.Quantidade);

       }

       //Limpar o carrinho
       public void LimparCarrinho()
       {

           _itensCarrinho.Clear();

       }



       //Itens Carrinho
       public IEnumerable<ItemCarrinho> ItensCarrinho()
       {

           return _itensCarrinho; //ou faz um get 

       }



    }

   public class ItemCarrinho
   {

       public Produto Produto { get; set; }

       public int Quantidade { get; set; }



   }

}

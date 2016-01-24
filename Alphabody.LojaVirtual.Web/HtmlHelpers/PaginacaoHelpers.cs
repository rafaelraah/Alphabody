using Alphabody.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Alphabody.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {

        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {

            StringBuilder resultadoStringBuilder = new StringBuilder();

            for (int i = 0; i < paginacao.TotalDePaginas; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("<a>");

                tagBuilder.MergeAttribute("href",paginaUrl(i));
                tagBuilder.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tagBuilder.AddCssClass("selected");
                    tagBuilder.AddCssClass("btn-primary");
                }

                tagBuilder.AddCssClass("btn btn-default");
                resultadoStringBuilder.Append(tagBuilder);

            }

            return MvcHtmlString.Create(resultadoStringBuilder.ToString());

        }

    }
}
using NerdStore.Catalogo.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoDto>> ObterTodos();
        Task<ProdutoDto> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo);
        Task<IEnumerable<CategoriaDto>> ObterCategorias();

        Task AdicionarProduto(ProdutoDto produto);
        Task AtualizarProduto(ProdutoDto produto);

        Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDto> ReporEstoque(Guid id, int quantidade);
    }
}

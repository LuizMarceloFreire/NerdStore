using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public EstoqueService(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;   
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepositorio.ObterPorId(produtoId);

            if (produto == null) return false;

            if(!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            _produtoRepositorio.Atualizar(produto);
            return await _produtoRepositorio.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepositorio.ObterPorId(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);

            _produtoRepositorio.Atualizar(produto);
            return await _produtoRepositorio.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepositorio?.Dispose();
        }
    }
}

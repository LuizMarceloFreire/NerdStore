using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoEventHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;   
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent notification, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepositorio.ObterPorId(notification.AggregateId);

            //ENVIAR EMAIL PARA AQUISICAO DE MAIS PRODUTOS.
        }
    }
}

using AutoMapper;
using NerdStore.Catalogo.Application.Dto;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;
        private readonly IEstoqueService _estoqueService;

        public ProdutoAppService(IProdutoRepositorio produtoRepositorio, IMapper mapper, IEstoqueService estoqueService)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
            _estoqueService = estoqueService;   
        }

        public async Task AdicionarProduto(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _produtoRepositorio.Adicionar(produto);

            await _produtoRepositorio.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _produtoRepositorio.Atualizar(produto);

            await _produtoRepositorio.UnitOfWork.Commit();
        }        

        public async Task<IEnumerable<CategoriaDto>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDto>>(await _produtoRepositorio.ObterCategorias());
        }

        public async Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepositorio.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoDto> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoDto>(await _produtoRepositorio.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepositorio.ObterTodos());
        }

        public async Task<ProdutoDto> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
            {
                throw new DomainException("Falha ao repor estoque.");
            }

            return _mapper.Map<ProdutoDto>(await _produtoRepositorio.ObterPorId(id));
        }

        public async Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade)
        {
            if(!_estoqueService.DebitarEstoque(id, quantidade).Result)
            {
                throw new DomainException("Falha ao debitar estoque.");
            }

            return _mapper.Map<ProdutoDto>(await _produtoRepositorio.ObterPorId(id));
        }

        public void Dispose()
        {
            _produtoRepositorio?.Dispose();
            _estoqueService?.Dispose();
        }
    }
}

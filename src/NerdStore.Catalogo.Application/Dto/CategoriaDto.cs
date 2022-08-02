using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.Dto
{
    public class CategoriaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Codigo { get; set; }

        public IEnumerable<ProdutoDto> Produtos { get; set; }
    }
}
using NerdStore.Core.Domain;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public string Nome { get; set; }
        public int Codigo { get; set; }

        //EF Relation
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria()
        {

        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio.");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Código não pode ser igual a zero.");
        }
    }
}

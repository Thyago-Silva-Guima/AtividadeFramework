using System.Collections.Generic;
using System.Linq;
using EFProject.Data;
using EFProject.Models;

namespace EFProject.Repositories
{
   // Atividade 1
    public class ProdutoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Atualizar(Produto produto)
        {
            var existente = _context.Produtos.Find(produto.Id);
            if (existente != null)
            {
                existente.Nome = produto.Nome;
                existente.Preco = produto.Preco;
                _context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }

        // Desafio: listar produtos acima de um valor mínimo
        public List<Produto> ListarAcimaDe(double precoMinimo)
        {
            return _context.Produtos
                .Where(p => p.Preco > precoMinimo)
                .ToList();
        }
    }
}

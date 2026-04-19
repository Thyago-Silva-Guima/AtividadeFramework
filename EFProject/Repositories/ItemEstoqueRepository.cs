using System;
using System.Collections.Generic;
using System.Linq;
using EFProject.Data;
using EFProject.Models;

namespace EFProject.Repositories
{
    // Atividade 4
    public class ItemEstoqueRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(ItemEstoque item)
        {
            _context.ItensEstoque.Add(item);
            _context.SaveChanges();
        }

        public List<ItemEstoque> Listar()
        {
            return _context.ItensEstoque.ToList();
        }

        public void BaixarEstoque(int id, int quantidade)
        {
            var item = _context.ItensEstoque.Find(id);
            if (item == null)
                throw new Exception("Item não encontrado.");

            if (item.Quantidade - quantidade < 0)
                throw new InvalidOperationException("Estoque insuficiente. Operação cancelada.");

            item.Quantidade -= quantidade;
            _context.SaveChanges();
        }

        public List<ItemEstoque> ListarEstoqueBaixo(int limiteMinimo = 5)
        {
            return _context.ItensEstoque
                .Where(i => i.Quantidade < limiteMinimo)
                .ToList();
        }

        public void Remover(int id)
        {
            var item = _context.ItensEstoque.Find(id);
            if (item != null)
            {
                _context.ItensEstoque.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}

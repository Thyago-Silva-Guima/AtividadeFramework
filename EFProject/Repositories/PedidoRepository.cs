using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFProject.Data;
using EFProject.Models;

namespace EFProject.Repositories
{
// Atividade 6
    public class PedidoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public List<Pedido> ListarComItens()
        {
            return _context.Pedidos
                .Include(p => p.Itens)
                .ToList();
        }

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefault(p => p.Id == id);
        }

        // Desafio: calcular total de itens de um pedido
        public int TotalItens(int pedidoId)
        {
            var pedido = BuscarPorId(pedidoId);
            if (pedido == null) return 0;
            return pedido.Itens.Sum(i => i.Quantidade);
        }

        public void Remover(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
        }
    }
}

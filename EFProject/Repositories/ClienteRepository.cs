using System;
using System.Collections.Generic;
using System.Linq;
using EFProject.Data;
using EFProject.Models;

namespace EFProject.Repositories
{
    // Atividade 2
    public class ClienteRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public void Adicionar(Cliente c)
        {
            if (!c.Email.Contains("@"))
                throw new ArgumentException("Email inválido.");

            _context.Clientes.Add(c);
            _context.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public Cliente BuscarPorEmail(string email)
        {
            return _context.Clientes.FirstOrDefault(c => c.Email == email);
        }

        public void Atualizar(Cliente cliente)
        {
            var existente = _context.Clientes.Find(cliente.Id);
            if (existente != null)
            {
                existente.Nome = cliente.Nome;
                existente.Email = cliente.Email;
                _context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}

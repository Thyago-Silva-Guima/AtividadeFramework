using System;
using System.Collections.Generic;
using EFProject.Models;
using EFProject.Repositories;

namespace EFProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("========== TUTORIAL: ESTUDANTE ==========\n");

            var repoEstudante = new EstudanteRepository();

            Console.WriteLine("=== INSERINDO ESTUDANTE ===");
            repoEstudante.Adicionar(new Estudante { Nome = "João Silva", Idade = 22 });
            Console.WriteLine("Estudante inserido.\n");

            Console.WriteLine("=== LISTANDO ESTUDANTES ===");
            foreach (var e in repoEstudante.Listar())
                Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");
            Console.WriteLine();

            Console.WriteLine("=== BUSCANDO POR ID ===");
            var encontrado = repoEstudante.BuscarPorId(1);
            if (encontrado != null)
                Console.WriteLine($"Encontrado: {encontrado.Nome} - {encontrado.Idade} anos");
            Console.WriteLine();

            Console.WriteLine("=== ATUALIZANDO ===");
            repoEstudante.Atualizar(new Estudante { Id = 1, Nome = "Maria Oliveira", Idade = 25 });
            Console.WriteLine("Atualizado.\n");

            Console.WriteLine("=== REMOVENDO ===");
            repoEstudante.Remover(1);
            Console.WriteLine("Removido.\n");

            Console.WriteLine("========== ATIVIDADE 1: PRODUTO ==========\n");

            var repoProduto = new ProdutoRepository();
            repoProduto.Adicionar(new Produto { Nome = "Notebook", Preco = 3500.00 });
            repoProduto.Adicionar(new Produto { Nome = "Mouse", Preco = 89.90 });
            repoProduto.Adicionar(new Produto { Nome = "Teclado", Preco = 150.00 });

            Console.WriteLine("=== TODOS OS PRODUTOS ===");
            foreach (var p in repoProduto.Listar())
                Console.WriteLine($"{p.Id} - {p.Nome} - R$ {p.Preco:F2}");

            Console.WriteLine("\n=== PRODUTOS ACIMA DE R$ 100,00 ===");
            foreach (var p in repoProduto.ListarAcimaDe(100))
                Console.WriteLine($"{p.Nome} - R$ {p.Preco:F2}");
            Console.WriteLine();
            Console.WriteLine("========== ATIVIDADE 2: CLIENTE ==========\n");

            var repoCliente = new ClienteRepository();
            try
            {
                repoCliente.Adicionar(new Cliente { Nome = "Ana Costa", Email = "ana@email.com" });
                repoCliente.Adicionar(new Cliente { Nome = "Bruno Lima", Email = "bruno@email.com" });
                Console.WriteLine("Clientes adicionados.\n");

                Console.WriteLine("=== BUSCAR POR EMAIL ===");
                var clienteEmail = repoCliente.BuscarPorEmail("ana@email.com");
                if (clienteEmail != null)
                    Console.WriteLine($"Encontrado: {clienteEmail.Nome}");

                Console.WriteLine("\n=== TESTANDO EMAIL INVÁLIDO ===");
                repoCliente.Adicionar(new Cliente { Nome = "Inválido", Email = "semArroba" });
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro esperado: {ex.Message}");
            }
            Console.WriteLine();

          
            Console.WriteLine("========== ATIVIDADE 3: CURSOS ==========\n");

            var repoCurso = new CursoRepository();
            repoCurso.Adicionar(new Curso { Nome = "C# Básico", CargaHoraria = 40 });
            repoCurso.Adicionar(new Curso { Nome = "Entity Framework", CargaHoraria = 20 });
            repoCurso.Adicionar(new Curso { Nome = "Angular", CargaHoraria = 60 });
            repoCurso.Adicionar(new Curso { Nome = "SQL Server", CargaHoraria = 30 });
            repoCurso.Adicionar(new Curso { Nome = "Docker", CargaHoraria = 15 });

            Console.WriteLine("=== ORDENADOS POR NOME ===");
            foreach (var c in repoCurso.ListarOrdenadoPorNome())
                Console.WriteLine($"{c.Nome} - {c.CargaHoraria}h");

            Console.WriteLine("\n=== CARGA HORÁRIA >= 30h ===");
            foreach (var c in repoCurso.FiltrarPorCargaHoraria(30))
                Console.WriteLine($"{c.Nome} - {c.CargaHoraria}h");
            Console.WriteLine();

            Console.WriteLine("========== ATIVIDADE 4: ESTOQUE ==========\n");

            var repoEstoque = new ItemEstoqueRepository();
            repoEstoque.Adicionar(new ItemEstoque { Nome = "Parafuso", Quantidade = 100 });
            repoEstoque.Adicionar(new ItemEstoque { Nome = "Porca", Quantidade = 3 });
            repoEstoque.Adicionar(new ItemEstoque { Nome = "Arruela", Quantidade = 2 });

            Console.WriteLine("=== ESTOQUE BAIXO (< 5) ===");
            foreach (var i in repoEstoque.ListarEstoqueBaixo())
                Console.WriteLine($"{i.Nome} - {i.Quantidade} unidades");

            Console.WriteLine("\n=== BAIXA DE ESTOQUE ===");
            try
            {
                repoEstoque.BaixarEstoque(1, 10);
                Console.WriteLine("Baixa de 10 unidades de Parafuso realizada.");
                repoEstoque.BaixarEstoque(1, 999);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro esperado: {ex.Message}");
            }
            Console.WriteLine();

           
            Console.WriteLine("========== ATIVIDADE 5: PROFESSOR E CURSOS ==========\n");

            var repoProfessor = new ProfessorRepository();
            repoProfessor.Adicionar(new Professor
            {
                Nome = "Carlos Silva",
                Cursos = new List<Curso>
                {
                    new Curso { Nome = "C# Básico", CargaHoraria = 40 },
                    new Curso { Nome = "Entity Framework", CargaHoraria = 20 }
                }
            });

            Console.WriteLine("=== PROFESSORES COM CURSOS ===");
            foreach (var prof in repoProfessor.ListarComCursos())
            {
                Console.WriteLine($"Professor: {prof.Nome}");
                foreach (var curso in prof.Cursos)
                    Console.WriteLine($"  - {curso.Nome} ({curso.CargaHoraria}h)");
            }
            Console.WriteLine();
            Console.WriteLine("========== ATIVIDADE 6: PEDIDO E ITENS ==========\n");

            var repoPedido = new PedidoRepository();
            repoPedido.Adicionar(new Pedido
            {
                Data = DateTime.Now,
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { Produto = "Notebook", Quantidade = 1 },
                    new ItemPedido { Produto = "Mouse", Quantidade = 2 }
                }
            });

            Console.WriteLine("=== PEDIDOS COM ITENS ===");
            foreach (var pedido in repoPedido.ListarComItens())
            {
                Console.WriteLine($"Pedido #{pedido.Id} - {pedido.Data:dd/MM/yyyy}");
                foreach (var item in pedido.Itens)
                    Console.WriteLine($"  - {item.Produto} x{item.Quantidade}");

                Console.WriteLine($"  Total de itens: {repoPedido.TotalItens(pedido.Id)}");
            }

            Console.WriteLine("\n=== FIM ===");
        }
    }
}

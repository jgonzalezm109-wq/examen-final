using System;
using System.Collections.Generic;

namespace CrudCurso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GastoRepositorio repo = new CursoRepositorio();
            string opcion;

            do
            {
                opcion = LeerOpcionMenu();


                try
                {
                    switch (opcion)
                    {
                        case "1":
                            RegistrarCurso(repo);
                            break;
                        case "2":
                            ListarCurso(repo);
                            break;
                        case "3":
                            BuscarCursoPorId(repo);
                            break;
                        case "4":
                            ActualizarMonto(repo);
                            break;
                        case "5":
                            EliminarCurso(repo);
                            break;
                        case "6":
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al ejecutar la operación: {ex.Message}");
                }

            } while (opcion != "6");
        }

        private static string LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== SISTEMA DE CONTROL DE CURSOS ===");
            Console.WriteLine("1. Registrar Curso");
            Console.WriteLine("2. Listar Curso");
            Console.WriteLine("3. Buscar Curso por Id");
            Console.WriteLine("4. Actualizar monto");
            Console.WriteLine("5. Eliminar Curso");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");
            return Console.ReadLine();
        }

        private static void RegistrarCurso(CursoRepositorio repo)
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine().Trim();

            Console.Write("Monto: ");
            bool montoOk = decimal.TryParse(Console.ReadLine(), out decimal monto);

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine().Trim();

            if (!montoOk || monto <= 0 || string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            Curso nuevoCurso = new Curso 
            {
                Descripcion = descripcion,
                Monto = monto,
                Categoria = categoria
            };

            repo.Insertar(nuevoCurso);
            Console.WriteLine("Curso registrado.");
        }

        private static void ListarCurso(CursoRepositorio repo)
        {
            List<Curso> lista = repo.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay Curso registrados.");
                return;
            }

            decimal totalGeneral = 0;

            foreach (Curso g in lista)
            {
                Console.WriteLine(g);
                totalGeneral += g.Monto;
            }

            Console.WriteLine($"TOTAL GASTADO: Q {totalGeneral:N2}");
        }

        private static void BuscarGastoPorId(CursoRepositorio repo)
        {
            Console.Write("Ingrese el Id a buscar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso g = repo.BuscarPorId(id);
            if (g != null)
            {
                Console.WriteLine(g);
            }
            else
            {
                Console.WriteLine("No existe ese Id.");
            }
        }

        private static void ActualizarMonto(CursoRepositorio repo)
        {
            Console.Write("Ingrese el Id del Curso: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Gasto CursoExistente = repo.BuscarPorId(id);
            if (CursoExistente == null)
            {
                Console.WriteLine("No existe ese Id.");
                return;
            }

            Console.WriteLine($"Curso actual: {CursoExistente}");

            Console.Write("Ingrese el nuevo monto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal nuevoMonto) || nuevoMonto <= 0)
            {
                Console.WriteLine("Monto inválido.");
                return;
            }

            CursoExistente.Monto = nuevoMonto;
            repo.Actualizar(gastoExistente);
            Console.WriteLine("Gasto actualizado.");
        }

        private static void EliminarGasto(CursoRepositorio repo)
        {
            Console.Write("Ingrese el Id del gasto a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            if (repo.Eliminar(id))
            {
                Console.WriteLine("Gasto eliminado.");
            }
            else
            {
                Console.WriteLine("No existe ese Id.");
            }
        }
    }
}
namespace examen_final 

using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudGastos
{
    public class CursoRepositorio
    {
        private static List<Curso> listaGastos = new List<Curso>();
        private static int siguienteId = 1;


        static CursoRepositorio()
        {
            listaGastos.Add(new Curso { Id = siguienteId++, Descripcion = "Cuaderno", Monto = 20.50m, Categoria = "Estudios" });
            listaGastos.Add(new Curso { Id = siguienteId++, Descripcion = "Gasolina", Monto = 250.00m, Categoria = "Transporte" });
            listaGastos.Add(new Curso { Id = siguienteId++, Descripcion = "Cena", Monto = 100.00m, Categoria = "Comida" });
        }

        public void Insertar(Curso g)
        {
            g.Id = siguienteId++;
            listaGastos.Add(g);
        }

        public List<Curso> ListarTodos()
        {
            return listaCurso;
        }


        public Curso BuscarPorId(int id)
        {
            foreach (Curso g in listaCurso)
            {
                if (g.Id == id)
                {
                    return g;
                }
            }
            return null;
        }


        public bool Actualizar(Curso CursoActualizado)
        {
            Gasto g = BuscarPorId(gastoActualizado.Id);
            if (g != null)
            {
                g.Descripcion = CursoActualizado.Descripcion;
                g.Monto = CursoActualizado.Monto;
                g.Categoria = CursoActualizado.Categoria;
                return true;
            }
            return false;
        }


        public bool Eliminar(int id)
        {
            Curso g = BuscarPorId(id);
            if (g != null)
            {
                listaCurso.Remove(g);
                return true;
            }
            return false;
        }
    }
}

namespace examen_final
{
    internal class CursoRepositorio
    {
    }
}

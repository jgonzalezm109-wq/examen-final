using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudCurso
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = "";
        public decimal Monto { get; set; }
        public string Categoria { get; set; } = "";

        public override string ToString()
        {
            return $"{Id} - {Descripcion} | Q {Monto:N2} | Categoría: {Categoria}";
        }
    }
}


namespace examen_final
{
    internal class Curso
    {
    }
}

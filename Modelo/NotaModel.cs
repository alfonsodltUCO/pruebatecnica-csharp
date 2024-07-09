using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Modelo
{
    /// <summary>
    /// Se define el modelo de datos a usar en este caso con sus correspondientes campos, id y calificacion.
    /// </summary>
    public class NotaModel
    {
        public double Calificacion { get; set; }
        public int Id { get; set; }
    }
}

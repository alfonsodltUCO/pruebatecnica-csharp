using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Modelo;
using WinFormsApp1.Servicio;

namespace WinFormsApp1
{
    /// <summary>
    /// Clase para manejar el correspondiente formulario y sus botones y tabla
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Se define el servicio, la tabla y el modelo que usará los datos.
        /// </summary>
        private Notas service;
        private NotaModel nota;
        private DataTable tabla;

        /// <summary>
        /// Se inicializan los elementos
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            service = new Notas();
            nota = new NotaModel();
            tabla= new DataTable();
            tabla.Columns.Add("Calificaciones");
            notasGrid.DataSource = tabla;

        }

        /// <summary>
        /// Maneja la lógica del botón correspondiente que en este caso es (Borrado).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            tabla.Clear();
            this.service.Borrar();

        }

        /// <summary>
        /// Maneja la lógica del botón correspondiente que en este caso es (Guardado).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text) && Double.TryParse(this.textBox1.Text, out double calificacion) && (calificacion >= 0 && calificacion <= 10))
            {
                this.nota.Calificacion = calificacion;
                this.service.Añadir(this.nota);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una calificación válida.");
            }

        }

        /// <summary>
        /// Maneja la lógica del botón correspondiente que en este caso es (Listado).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonMostrar_Click(object sender, EventArgs e)
        {
            tabla.Clear();
            List<NotaModel> notas = await this.service.Mostrar();
            
            foreach(var item in notas)
            {
                DataRow fila = tabla.NewRow(); 

                fila["Calificaciones"] = $"Nota {item.Id}: Esta es la nota correspondiente {item.Calificacion}.";
                tabla.Rows.Add(fila);
            }            
        }
    }
}

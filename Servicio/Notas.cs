using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;

namespace WinFormsApp1.Servicio
{
    /// <summary>
    /// Se define el servicio que permitirá el acceso a los datos y el manejo de estos.
    /// </summary>
    public class Notas
    {
        /// <summary>
        /// Se define el cliente Http para acceso a la API
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Constructor para determinar el intercambio de informacion en este caso Json además de definir la Uri a la API.
        /// </summary>
        public Notas() { 
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("http://localhost:3000/");
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Definición del método (Guardado) a la API por parte del servicio.
        /// </summary>
        /// <param name="nota"></param>
        public async void Añadir(NotaModel nota)
        {
            try
            {
                string jsonNota = System.Text.Json.JsonSerializer.Serialize(new { calificacion = nota.Calificacion });

                var contenido = new StringContent(
                    jsonNota,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage respuesta = await this.client.PostAsync("notas", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Nota añadida correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo añadir la nota. Código de estado: " + respuesta.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servicio no disponible.Inténtelo más tarde");
            }
        }

        /// <summary>
        /// Definición del método (Borrar) a la API por parte del servicio.
        /// </summary>
        public async void Borrar()
        {
            try
            {              


                HttpResponseMessage respuesta = await this.client.DeleteAsync("notas");

                if (respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Notas borradas correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar el borrado de las nota. Código de estado: " + respuesta.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servicio no disponible.Inténtelo más tarde");
            }
        }

        /// <summary>
        /// Definición del método (Listado) a la API por parte del servicio.
        /// </summary>
        /// <returns>Lista de notas en el sistema</returns>
        public async Task<List<NotaModel>> Mostrar()
        {
            try
            {
                HttpResponseMessage respuesta = await this.client.GetAsync("notas");

                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer el contenido JSON de la respuesta
                    string contenido = await respuesta.Content.ReadAsStringAsync();

                    // Deserializar el contenido JSON
                    var jsonDoc = JsonDocument.Parse(contenido);

                    // Obtener el array "listNotas" del JSON
                    JsonElement listNotasElement;
                    if (jsonDoc.RootElement.TryGetProperty("listNotas", out listNotasElement))
                    {
                        // Deserializar el array "listNotas" a una lista de NotaModel
                        List<NotaModel> notas = new List<NotaModel>();

                        foreach (JsonElement element in listNotasElement.EnumerateArray())
                        {
                            NotaModel nota = new NotaModel();
                            nota.Id = element.GetProperty("id").GetInt32();
                            nota.Calificacion = element.GetProperty("calificacion").GetDouble();
                            notas.Add(nota);
                        }

                        return notas;
                    }
                    else
                    {
                        MessageBox.Show("Servicio no disponible.Inténtelo más tarde");
                        return new List<NotaModel>();
                    }
                }
                else
                {
                    MessageBox.Show("Lista vacia");
                    return new List<NotaModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servicio no disponible.Inténtelo más tarde");
                return new List<NotaModel>();
            }
        }
    }

}

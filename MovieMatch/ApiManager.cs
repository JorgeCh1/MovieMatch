using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MovieMatch
{
    public class ApiManager
    {
        private HttpClient httpClient;
        private string apiUrl;
        private string apiKey;

        public ApiManager(string apiUrl, string apiKey)
        {
            this.apiUrl = apiUrl;
            this.apiKey = apiKey;
            httpClient = new HttpClient();
        }

        public async Task<List<Movie>> ObtenerTodasLasPeliculas()
        {
            List<Movie> allMovies = new List<Movie>();

            try
            {
                int pagina = 1;
                bool hayMasPaginas = true;

                while (hayMasPaginas)
                {
                    string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

                        List<Movie> movies = movieResponse.Results;
                        allMovies.AddRange(movies);

                        if (pagina >= movieResponse.TotalPages)
                        {
                            hayMasPaginas = false;
                        }
                        else
                        {
                            pagina++;
                        }
                    }
                    else
                    {
                        // Manejar el caso de error en la solicitud HTTP
                        hayMasPaginas = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las películas: " + ex.Message);
            }


            return allMovies;
        }
    }

}

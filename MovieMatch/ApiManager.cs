using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        // Themoviedb usa paginación quiere decir que en cada página de carga almacena 20 películas.
        // Este método carga la primera página, esto para mayor eficiencia.
        public async Task<List<Movie>> ObtenerTodasLasPeliculas()
        {
            List<Movie> allMovies = new List<Movie>();

            try
            {
                int pagina = 1;
                string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

                    List<Movie> movies = movieResponse.Results;
                    allMovies.AddRange(movies);
                }
                else
                {
                    // Manejar el caso de error en la solicitud HTTP
                    throw new Exception("Error al obtener las películas");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las películas: " + ex.Message);
            }

            return allMovies;
        }


        // Este método carga las miles de millones de películas.
        // Está comentareado para que saturar la carga en la aplicación, de ser necesario usarlo, descomentarearlo.
        /*public async Task<List<Movie>> ObtenerTodasLasPeliculas()
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
        }*/

        public async Task<List<Genre>> ObtenerTodosLosGeneros()
        {
            string url = $"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                GenreResponse genreResponse = JsonConvert.DeserializeObject<GenreResponse>(json);
                return genreResponse.Genres;
            }
            else
            {
                throw new Exception("Error al obtener los géneros de películas.");
            }
        }

    }
}


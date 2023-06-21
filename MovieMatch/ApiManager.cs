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

        //public async Task<List<Movie>> ObtenerPeliculasPorGenero(string nombreGenero)
        //{
        //    List<Movie> peliculasPorGenero = new List<Movie>();

        //    try
        //    {
        //        // Buscar el ID del género por su nombre
        //        int? generoId = genreResponse.Genres.FirstOrDefault(g => g.Name.Equals(nombreGenero, StringComparison.OrdinalIgnoreCase))?.Id;

        //        if (generoId.HasValue)
        //        {
        //            string url = $"{apiUrl}?api_key={apiKey}&page=1&with_genres={generoId}"; 
        //            HttpResponseMessage response = await httpClient.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string json = await response.Content.ReadAsStringAsync();
        //                MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

        //                List<Movie> peliculas = movieResponse.Results;
        //                peliculasPorGenero.AddRange(peliculas);
        //            }
        //            else
        //            {
        //                // Manejar el caso de error en la solicitud HTTP
        //                throw new Exception("Error al obtener las películas por género");
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("El género especificado no fue encontrado.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener las películas por género: " + ex.Message);
        //    }

        //    return peliculasPorGenero;
        //}

        public async Task<List<Movie>> ObtenerPeliculasPorGenero(string nombreGenero, GenreResponse genreResponse)
        {
            List<Movie> peliculasPorGenero = new List<Movie>();

            try
            {
                string url = $"{apiUrl}?api_key={apiKey}&page=1";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

                    // Filtrar las películas por el nombre del género
                    List<Movie> peliculasFiltradas = movieResponse.Results
                        .Where(m => m.GenreIds.Any(g => ObtenerNombreGeneroPorId(g, genreResponse).Equals(nombreGenero, StringComparison.OrdinalIgnoreCase)))
                        .ToList();

                    peliculasPorGenero.AddRange(peliculasFiltradas);

                    // Punto de depuración para imprimir los datos obtenidos
                    Console.WriteLine("Películas obtenidas:");
                    foreach (var pelicula in peliculasPorGenero)
                    {
                        Console.WriteLine($"{pelicula.Id} - {pelicula.Title}");
                    }
                }
                else
                {
                    // Manejar el caso de error en la solicitud HTTP
                    throw new Exception("Error al obtener las películas por género");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las películas por género: " + ex.Message);
            }

            return peliculasPorGenero;
        }

        private string ObtenerNombreGeneroPorId(int genreId, GenreResponse genreResponse)
        {
            Genre genre = genreResponse.Genres.FirstOrDefault(g => g.Id == genreId);
            return genre?.Name ?? string.Empty;
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

        public async Task<GenreResponse> ObtenerTodosLosGeneros()
        {
            try
            {
                string urlGeneros = $"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}";
                HttpResponseMessage responseGeneros = await httpClient.GetAsync(urlGeneros);

                if (responseGeneros.IsSuccessStatusCode)
                {
                    string jsonGeneros = await responseGeneros.Content.ReadAsStringAsync();
                    GenreResponse genreResponse = JsonConvert.DeserializeObject<GenreResponse>(jsonGeneros);
                    return genreResponse;
                }
                else
                {
                    throw new Exception("Error al obtener los géneros disponibles");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los géneros: " + ex.Message);
            }
        }


    }
}


﻿using System;
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
        // Estos métodos cargan la primera página, esto para mayor eficiencia.
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


        public async Task<List<Movie>> ObtenerPeliculasPorGenero(string nombreGenero, GenreResponse genreResponse)
        {
            List<Movie> peliculasPorGenero = new List<Movie>();

            try
            {
                int pagina = 1;
                string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
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

        // Themoviedb usa paginación quiere decir que en cada página de carga almacena 20 películas.
        // Estos métodos cargan TODAS las páginas, esto por si se quiere usar TODAS las películas (No recomendable).
        //public async Task<List<Movie>> ObtenerTodasLasPeliculas()
        //{
        //    List<Movie> allMovies = new List<Movie>();

        //    try
        //    {
        //        int pagina = 1;
        //        bool hayMasPaginas = true;

        //        while (hayMasPaginas)
        //        {
        //            string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
        //            HttpResponseMessage response = await httpClient.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string json = await response.Content.ReadAsStringAsync();
        //                MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

        //                List<Movie> movies = movieResponse.Results;
        //                allMovies.AddRange(movies);

        //                if (pagina >= movieResponse.TotalPages)
        //                {
        //                    hayMasPaginas = false;
        //                }
        //                else
        //                {
        //                    pagina++;
        //                }
        //            }
        //            else
        //            {
        //                // Manejar el caso de error en la solicitud HTTP
        //                hayMasPaginas = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener las películas: " + ex.Message);
        //    }


        //    return allMovies;
        //}

        //public async Task<List<Movie>> ObtenerPeliculasPorGenero(string nombreGenero, GenreResponse genreResponse)
        //{
        //    List<Movie> peliculasPorGenero = new List<Movie>();

        //    try
        //    {
        //        int pagina = 1;
        //        bool hayMasPaginas = true;

        //        while (hayMasPaginas)
        //        {
        //            string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
        //            HttpResponseMessage response = await httpClient.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string json = await response.Content.ReadAsStringAsync();
        //                MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

        //                // Filtrar las películas por el nombre del género
        //                List<Movie> peliculasFiltradas = movieResponse.Results
        //                    .Where(m => m.GenreIds.Any(g => ObtenerNombreGeneroPorId(g, genreResponse).Equals(nombreGenero, StringComparison.OrdinalIgnoreCase)))
        //                    .ToList();

        //                peliculasPorGenero.AddRange(peliculasFiltradas);

        //                if (pagina >= movieResponse.TotalPages)
        //                {
        //                    hayMasPaginas = false;
        //                }
        //                else
        //                {
        //                    pagina++;
        //                }
        //            }
        //            else
        //            {
        //                // Manejar el caso de error en la solicitud HTTP
        //                hayMasPaginas = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener las películas por género: " + ex.Message);
        //    }

        //    return peliculasPorGenero;
        //}

        // Themoviedb usa paginación quiere decir que en cada página de carga almacena 20 películas.
        // Estos métodos cargan las páginas que deseemos, en este caso 3, esto para mayor eficiencia y práctica.
        //public async Task<List<Movie>> ObtenerTodasLasPeliculas()
        //{
        //    List<Movie> allMovies = new List<Movie>();
        //    int maxPaginas = 3;

        //    try
        //    {
        //        int pagina = 1;
        //        int paginasCargadas = 0;
        //        bool hayMasPaginas = true;

        //        while (hayMasPaginas && paginasCargadas < maxPaginas)
        //        {
        //            string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
        //            HttpResponseMessage response = await httpClient.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string json = await response.Content.ReadAsStringAsync();
        //                MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

        //                List<Movie> movies = movieResponse.Results;
        //                allMovies.AddRange(movies);

        //                if (pagina >= movieResponse.TotalPages)
        //                {
        //                    hayMasPaginas = false;
        //                }
        //                else
        //                {
        //                    pagina++;
        //                    paginasCargadas++;
        //                }
        //            }
        //            else
        //            {
        //                // Manejar el caso de error en la solicitud HTTP
        //                hayMasPaginas = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener las películas: " + ex.Message);
        //    }

        //    return allMovies;
        //}

        //public async Task<List<Movie>> ObtenerPeliculasPorGenero(string nombreGenero, GenreResponse genreResponse)
        //{
        //    List<Movie> peliculasPorGenero = new List<Movie>();
        //    int maxPaginas = 3;

        //    try
        //    {
        //        int pagina = 1;
        //        int paginasCargadas = 0;
        //        bool hayMasPaginas = true;

        //        while (hayMasPaginas && paginasCargadas < maxPaginas)
        //        {
        //            string url = $"{apiUrl}?api_key={apiKey}&page={pagina}";
        //            HttpResponseMessage response = await httpClient.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string json = await response.Content.ReadAsStringAsync();
        //                MovieResponse movieResponse = JsonConvert.DeserializeObject<MovieResponse>(json);

        //                // Filtrar las películas por el nombre del género
        //                List<Movie> peliculasFiltradas = movieResponse.Results
        //                    .Where(m => m.GenreIds.Any(g => ObtenerNombreGeneroPorId(g, genreResponse).Equals(nombreGenero, StringComparison.OrdinalIgnoreCase)))
        //                    .ToList();

        //                peliculasPorGenero.AddRange(peliculasFiltradas);

        //                if (pagina >= movieResponse.TotalPages)
        //                {
        //                    hayMasPaginas = false;
        //                }
        //                else
        //                {
        //                    pagina++;
        //                    paginasCargadas++;
        //                }
        //            }
        //            else
        //            {
        //                // Manejar el caso de error en la solicitud HTTP
        //                hayMasPaginas = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener las películas por género: " + ex.Message);
        //    }

        //    return peliculasPorGenero;
        //}


        private string ObtenerNombreGeneroPorId(int genreId, GenreResponse genreResponse)
        {
            // Obtiene el nombre de un género por su ID
            Genre genre = genreResponse.Genres.FirstOrDefault(g => g.Id == genreId);
            return genre?.Name ?? string.Empty;
        }


        public async Task<GenreResponse> ObtenerTodosLosGeneros()
        {
            try
            {
                // Obtiene todos los géneros disponibles desde la API
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


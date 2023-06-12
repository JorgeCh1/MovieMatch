using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieMatch
{
    public class MovieResponse
    {
        [JsonProperty("results")]
        public List<Movie> Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    public class Movie
    {
        [JsonProperty("original_title")]
        public string Title { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("vote_average")]
        public decimal Rating { get; set; }

        [JsonProperty("poster_path")]
        public string Poster { get; set; }

        /*[JsonProperty("genre_ids")]
        public string Genere { get; set; }*/

        // Agrega más propiedades según los datos que necesites de la película
    }

}

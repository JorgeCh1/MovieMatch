using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieMatch
{
    public static class UserContext
    {
        public static int LoggedUserId { get; set; }
    }

    public class MovieResponse
    {
        [JsonProperty("results")]
        public List<Movie> Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    public class GenreResponse
    {
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_title")]
        public string Title { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("vote_average")]
        public double Rating { get; set; }

        [JsonProperty("poster_path")]
        public string Poster { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        public List<string> Genres { get; set; }
    }

}

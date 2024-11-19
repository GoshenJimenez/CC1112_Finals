using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoshenJimenez.Finals.Web.Pages;

public class Movies : PageModel
{
    private readonly ILogger<Movies> _logger;
    public List<Movie>? Items { get; set; }

    public Movies(ILogger<Movies> logger)
    {
        _logger = logger;
    }

    public void OnGet(string? sortBy = "title", string? sortDir = "asc")
    {
        var movies = new List<Movie>()
        {
            new Movie(){
                Title = "Final Fantasy Advent Children",
                Director = "Tetsuya Nomura",
                Release = DateTime.Parse("September 14, 2005"),
                NetProfit = 15000000,
                Genre = Genre.Fantasy
            },
            new Movie(){
                Title = "The Notebook",
                Director = "Nick Cassavetes",
                Release = DateTime.Parse("September 15, 2004"),
                NetProfit = 118300000,
                Genre = Genre.Drama           
            },
            new Movie(){
                Title = "Daddy Daycare",
                Director = "Steve Carr",
                Release = DateTime.Parse("August 20, 2003"),
                NetProfit = 164400000,
                Genre = Genre.Comedy           
            },
            new Movie(){
                Title = "the Matrix",
                Director = "Lana Wachowski, Lilly Wachowski",
                Release = DateTime.Parse("May 26, 1999"),
                NetProfit = 467600000,
                Genre = Genre.SciFi           
            },
            new Movie(){
                Title = "Poltergeist",
                Director = "Tobe Hooper",
                Release = DateTime.Parse("January 14, 1983"),
                NetProfit = 121700000,
                Genre = Genre.Suspense           
            }        
        };

        if(sortBy!.ToLower() == "title" && sortDir!.ToLower() == "asc")
        {
            movies = movies.OrderBy(a => a.Title).ToList();
        }
        else if(sortBy!.ToLower() == "title" && sortDir!.ToLower() == "desc")
        {
            movies = movies.OrderByDescending(a => a.Title).ToList();
        }
        else if(sortBy!.ToLower() == "director" && sortDir!.ToLower() == "asc")
        {
            movies = movies.OrderBy(a => a.Director).ToList();
        }
        else if(sortBy!.ToLower() == "director" && sortDir!.ToLower() == "desc")
        {
            movies = movies.OrderByDescending(a => a.Director).ToList();
        }
        else if(sortBy!.ToLower() == "release" && sortDir!.ToLower() == "asc")
        {
            movies = movies.OrderBy(a => a.Release).ToList();
        }
        else if(sortBy!.ToLower() == "release" && sortDir!.ToLower() == "desc")
        {
            movies = movies.OrderByDescending(a => a.Release).ToList();
        } 
        else if(sortBy!.ToLower() == "netprofit" && sortDir!.ToLower() == "asc")
        {
            movies = movies.OrderBy(a => a.NetProfit).ToList();
        }
        else if(sortBy!.ToLower() == "netprofit" && sortDir!.ToLower() == "desc")
        {
            movies = movies.OrderByDescending(a => a.NetProfit).ToList();
        } 
        else if(sortBy!.ToLower() == "genre" && sortDir!.ToLower() == "asc")
        {
            movies = movies.OrderBy(a => a.Genre).ToList();
        }
        else if(sortBy!.ToLower() == "genre" && sortDir!.ToLower() == "desc")
        {
            movies = movies.OrderByDescending(a => a.Genre).ToList();
        }                        
        this.Items = movies;
    }

    public class Movie
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public DateTime? Release  { get; set; }
        public decimal? NetProfit  { get; set; }
        public Genre? Genre  { get; set; }        
    }

    public enum Genre
    {
        Comedy,
        Action,
        Drama,
        SciFi,
        Fantasy,
        Suspense
    }
}

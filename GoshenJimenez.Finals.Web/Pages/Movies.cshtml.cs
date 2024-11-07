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

    public void OnGet()
    {
        this.Items = new List<Movie>()
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

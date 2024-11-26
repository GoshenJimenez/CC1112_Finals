using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoshenJimenez.Finals.Web.Pages;

public class Movies : PageModel
{
    private readonly ILogger<Movies> _logger;
    public List<Movie>? Items { get; set; }

    [BindProperty]
    public string? Keyword { get; set; }
    [BindProperty]
    public string? FilterBy { get; set; }

    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public List<int?> PrevPages { get; set; }
    public List<int?> NextPages { get; set; }

    public Movies(ILogger<Movies> logger)
    {
        _logger = logger;
    }

    public void OnGet(int? pageIndex = 1, int? pageSize = 5, string? sortBy = "title", string? sortDir = "asc",string? filterBy = "title", string? keyword = "")
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
            },  
            new Movie(){
                Title = "Final Fantasy Advent Children 1",
                Director = "Tetsuya Nomura",
                Release = DateTime.Parse("September 14, 2005"),
                NetProfit = 15000000,
                Genre = Genre.Fantasy
            },
            new Movie(){
                Title = "The Notebook 1",
                Director = "Nick Cassavetes",
                Release = DateTime.Parse("September 15, 2004"),
                NetProfit = 118300000,
                Genre = Genre.Drama           
            },
            new Movie(){
                Title = "Daddy Daycare 1",
                Director = "Steve Carr",
                Release = DateTime.Parse("August 20, 2003"),
                NetProfit = 164400000,
                Genre = Genre.Comedy           
            },
            new Movie(){
                Title = "the Matrix 1",
                Director = "Lana Wachowski, Lilly Wachowski",
                Release = DateTime.Parse("May 26, 1999"),
                NetProfit = 467600000,
                Genre = Genre.SciFi           
            },
            new Movie(){
                Title = "Poltergeist 1",
                Director = "Tobe Hooper",
                Release = DateTime.Parse("January 14, 1983"),
                NetProfit = 121700000,
                Genre = Genre.Suspense           
            },  
            new Movie(){
                Title = "Final Fantasy Advent Children 2",
                Director = "Tetsuya Nomura",
                Release = DateTime.Parse("September 14, 2005"),
                NetProfit = 15000000,
                Genre = Genre.Fantasy
            },
            new Movie(){
                Title = "The Notebook 2",
                Director = "Nick Cassavetes",
                Release = DateTime.Parse("September 15, 2004"),
                NetProfit = 118300000,
                Genre = Genre.Drama           
            },
            new Movie(){
                Title = "Daddy Daycare 2",
                Director = "Steve Carr",
                Release = DateTime.Parse("August 20, 2003"),
                NetProfit = 164400000,
                Genre = Genre.Comedy           
            },
            new Movie(){
                Title = "the Matrix 2",
                Director = "Lana Wachowski, Lilly Wachowski",
                Release = DateTime.Parse("May 26, 1999"),
                NetProfit = 467600000,
                Genre = Genre.SciFi           
            },
            new Movie(){
                Title = "Poltergeist 2",
                Director = "Tobe Hooper",
                Release = DateTime.Parse("January 14, 1983"),
                NetProfit = 121700000,
                Genre = Genre.Suspense           
            }        
        };

        if(string.IsNullOrEmpty(filterBy)){
            filterBy = "title";
        };

        this.FilterBy = filterBy;

        if(!string.IsNullOrEmpty(keyword)){
            if(filterBy!.ToLower() == "title"){
                movies = movies.Where(
                                    (a => a.Title != null 
                                &&  a.Title.ToLower().Contains(keyword!.ToLower())
                                )
                            )
                .ToList();
            }else if(filterBy!.ToLower() == "director"){
                movies = movies.Where(
                                    (a => a.Director != null 
                                &&  a.Director.ToLower().Contains(keyword!.ToLower())
                                )
                            )
                .ToList();        
            }
            else if(filterBy!.ToLower() == "release"){
                movies = movies.Where(
                                    (a => a.Release != null 
                                &&  a.Release!.Value.ToString("MMMM dd, yyyy").ToLower().Contains(keyword!.ToLower())
                                )
                            )
                .ToList();        
            } 
            else if(filterBy!.ToLower() == "netprofit"){
                movies = movies.Where(
                                    (a => a.NetProfit != null 
                                &&  string.Format("{0:C}", a.NetProfit).Contains(keyword!.ToLower())
                                )
                            )
                .ToList();        
            }
            else if(filterBy!.ToLower() == "genre"){
                movies = movies.Where(
                                    (a => a.NetProfit != null 
                                &&  a.Genre!.Value.ToString().Contains(keyword!.ToLower())
                                )
                            )
                .ToList();        
            } 

            this.Keyword = keyword;                                   
        }

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

        var pageCount = (int)Math.Ceiling((double)movies.Count() / (double)pageSize!.Value);
        var skip = pageSize * (pageIndex - 1);

        int? prev1 = ((pageIndex - 1) > 0) ? (pageIndex - 1) : null;
        int? prev2 = ((pageIndex - 2) > 0) ? (pageIndex - 2) : null;
        int? prev3 = ((pageIndex - 3) > 0) ? (pageIndex - 3) : null;

        int? next1 = ((pageIndex + 1) <= pageCount) ?(pageIndex + 1) : null;
        int? next2 = ((pageIndex + 2) <= pageCount) ?(pageIndex + 2) : null;
        int? next3 = ((pageIndex + 3) <= pageCount) ?(pageIndex + 3) : null;

        var prevPages = new List<int?>();
        if(prev1 != null)
            prevPages.Add(prev1); 
        
        if(prev2 != null)
            prevPages.Add(prev2);
        
        if(prev3 != null)
            prevPages.Add(prev3);     

        var nextPages = new List<int?>();
        if(next1 != null)
            nextPages.Add(next1); 
        
        if(next2 != null)
            nextPages.Add(next2);
        
        if(next3 != null)
            nextPages.Add(next3);     

        if(skip == null)
            skip = 0;

        this.Items = movies.Skip(skip!.Value).Take(pageSize.Value).ToList();
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
        this.PrevPages = prevPages.OrderBy(a => a).ToList();
        this.NextPages = nextPages.OrderBy(a => a).ToList();
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

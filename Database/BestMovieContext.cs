using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SQLInjection.Database
{
    public class BestMovieContext : DbContext
    {
        public BestMovieContext(DbContextOptions<BestMovieContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<BestMovie> BestMovies { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class BestMovie
    {
        public int BestMovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public string ImdbScore { get; set; }
        public string Actor { get; set; }
        public string Genre { get; set; }
     }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
    public class DbInitializer
    {
        public static void Initialize(BestMovieContext context)
        {
            context.Database.EnsureCreated();

            if (!context.BestMovies.Any())
            {

                var bestMovies = new BestMovie[]
                {
                    new BestMovie
                    {
                        Title = "Apocalypse Now",
                        ImdbScore = "8.4",
                        Director = "Francis Ford Coppola",
                        Synopsis = "A U.S. Army officer serving in Vietnam is tasked with assassinating a renegade Special Forces Colonel who sees himself as a god.",
                        Actor = "Marlon Brando",
                        Genre = "War, Drama"
                    },
                    new BestMovie
                    {
                        Title = "Fight Club",
                        ImdbScore = "8.8",
                        Director = "David Fincher",
                        Synopsis = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                        Actor = "Brad Pitt",
                        Genre = "Drama"
                    },
                    new BestMovie
                    {
                        Title = "Taxi Driver",
                        ImdbScore = "8.3",
                        Director = "Martin Scorsese",
                        Synopsis = "A mentally unstable veteran works as a nighttime taxi driver in New York City, where the perceived decadence and sleaze fuels his urge for violent action by attempting to liberate a presidential campaign worker and an underage prostitute.",
                        Actor = "Robert De Niro",
                        Genre = "Crime, Drama"
                    },
                    new BestMovie
                    {
                        Title = "The Godfather",
                        ImdbScore = "9.2",
                        Director = "Francis Ford Coppola",
                        Synopsis = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                        Actor = "Al Pacino",
                        Genre = "Crime, Drama"
                    },
                    new BestMovie
                    {
                        Title = "The Wolf of Wall Street",
                        ImdbScore = "8.2",
                        Director = "Martin Scorsese",
                        Synopsis = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                        Actor = "Leonardo DiCaprio",
                        Genre = "Biography, Crime, Drama"
                    },
                    new BestMovie
                    {
                        Title = "Joker",
                        ImdbScore = "8.6",
                        Director = "Todd Phillips",
                        Synopsis = "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime.",
                        Actor = "Joaquin Phoenix",
                        Genre = "Thriller, Drama, Crime"
                    },
                    new BestMovie
                    {
                        Title = "Forrest Gump",
                        ImdbScore = "8.8",
                        Director = "Robert Zemeckis",
                        Synopsis = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                        Actor = "Tom Hanks",
                        Genre = "Drama, Romance"
                    },
                    new BestMovie
                    {
                        Title = "American Psycho",
                        ImdbScore = "7.6",
                        Director = "Mary Harron",
                        Synopsis = "A wealthy New York City investment banking executive, Patrick Bateman, hides his alternate psychopathic ego from his co-workers and friends as he delves deeper into his violent, hedonistic fantasies.",
                        Actor = "Christian Bale",
                        Genre = "Comedy, Crime, Drama"
                    }
                };

                foreach (BestMovie bm in bestMovies)
                {
                    context.BestMovies.Add(bm);
                }

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {

                var users = new User[]
                {
                    new User
                    {
                        UserName = "jdoe",
                        FullName = "John Doe",
                        Password = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8"
                    },
                    new User
                    {
                        UserName = "asmith",
                        FullName = "Adam Smith",
                        Password = "b1b3773a05c0ed0176787a4f1574ff0075f7521e"
                    },
                    new User
                    {
                        UserName = "jmoore",
                        FullName = "Jane Moore",
                        Password = "f9a7c6df341325822e3ea264cfe39e5ef8c73aa4"
                    },
                    new User
                    {
                        UserName = "lorange",
                        FullName = "Lizzy Orange",
                        Password = "c608d35e5d875bbe971efffd97693c633dd2a41d"
                    }
                };

                foreach (User user in users)
                {
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }
    }
}

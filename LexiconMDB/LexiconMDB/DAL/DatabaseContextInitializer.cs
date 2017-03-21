using System.Data.Entity;
using System.Collections.Generic;
using LexiconMDB.Models;

namespace LexiconMDB.DAL
{
    internal class DatabaseContextInitializer : DropCreateDatabaseAlways<LexiconMDBContext>
    {
        protected override void Seed(LexiconMDBContext context)
        {
            context.Movies.AddRange(new List<Movie> {
                new Models.Movie { Title = "Psycho", Genre = "Horror", Length=110 },
                new Models.Movie { Title = "Wolf Creek", Genre = "Splatter", Length=90 },
                new Models.Movie { Title = "Dr Strangelove", Genre = "Comedy", Length=110 },
                new Models.Movie { Title = "The Lovemaker", Genre = "Erotic", Length=190 },
                new Models.Movie { Title = "On the beach", Genre = "Drama", Length =121 }
            });
        }
    }
}
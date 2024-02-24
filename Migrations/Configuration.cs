namespace TestStore.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestStore.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestStore.Models.TestStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestStore.Models.TestStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        List<Artist> artists = new List<Artist>()
            {
             new Artist(){ArtistName = "Al Di Meola" },
             new Artist(){ ArtistName = "Rush"}

            };
        artists.ForEach(art => context.Artists.AddOrUpdate(a => a.ArtistName, art));
            context.SaveChanges();

            List<Genre> genres = new List<Genre>()
            {
            new Genre(){ Name = "Jazz",Description = "cool"},
            new Genre(){ Name = "Rock",Description = "great"}
            };
        genres.ForEach(gen => context.Genres.AddOrUpdate(g => g.Name, gen));
            context.SaveChanges();

            List<Album> albums = new List<Album>()
            {
            new Album(){
            ArtistID = artists.Single(ar => ar.ArtistName == "Rush").ArtistID,

                GenreID = genres.Single(ge => ge.Name == "Rock").GenreID,

            Price = 9.99M,
            Title = "Caravan",
            AlbumArtUrl ="hgh"
             }
            };

        albums.ForEach(alb => context.Albums.AddOrUpdate(a => a.AlbumArtUrl, alb)); ;
            context.SaveChanges();
        }
    }
}

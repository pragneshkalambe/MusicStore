using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestStore.Models
{
    public class Album
    {
        public virtual int AlbumID { get; set; }

        [Required]
        public virtual int ArtistID { get; set; }

        [Required]
        public virtual int GenreID { get; set; }

        public virtual int ProductID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }

        //Navigational properties
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
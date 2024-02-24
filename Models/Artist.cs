using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TestStore.Models
{
    public class Artist
    {

        public virtual int ArtistID { get; set; }

        public virtual string ArtistName { get; set; }

        public List<Album> Albums { get; set; }
    }
}
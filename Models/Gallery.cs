using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace jupter_server.Models
{
    [Index(nameof(sequence))]
    public class Gallery : BaseModel
    {

        public string name { get; set; }

        public string? introduce { get; set; }

        public int sequence { get; set; }


        public ICollection<GalleryAlbum> GalleryAlbums { get; } =  new List<GalleryAlbum>();
    }
}

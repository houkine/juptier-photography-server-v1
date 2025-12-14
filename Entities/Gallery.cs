//this is album, the page protity. will have 5 templates, also considered as sections, coded as GalleryThemeInfo entity.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace jupter_server.Entities
{
    public class Gallery : BaseModel
    {

        public string? name { get; set; }

        public string? backgroundImage { get; set; }

        public ICollection<GalleryThemeInfo> ThemeInfos { get; } =  new List<GalleryThemeInfo>();
    }
}

//this is album, the page protity. will have 5 templates, also considered as sections, coded as GalleryThemeInfo entity.

using Microsoft.EntityFrameworkCore;

namespace jupter_server.Entities
{
    [Index(nameof(name))]

    public class Gallery : BaseModel
    {

        public string name { get; set; } = "";

        public string? backgroundImage { get; set; }

        public ICollection<GalleryThemeInfo> ThemeInfos { get; } =  new List<GalleryThemeInfo>();

        public Gallery(){}
        public Gallery(string name)
        {

            this.name = name;
        }
    }
}

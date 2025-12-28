namespace jupter_server.Helpers;

using Microsoft.EntityFrameworkCore;
using jupter_server.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
           options.UseNpgsql(Configuration.GetConnectionString("jupterServerDatabase"));
    }

    // user
    public DbSet<User> User { get; set; }

    //gallery
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<GalleryThemeInfo> GalleryThemeInfo { get; set; }
    public DbSet<ThemeAlbumInfo> ThemeAlbumInfo { get; set; }
    public DbSet<AlbumImageListInfo> AlbumImageListInfo { get; set; }
    public DbSet<AlbumImageInfo> AlbumImageInfo { get; set; }


    //public DbSet<Order> Order { get; set; }
    //public DbSet<Item> Item { get; set; }
    //public DbSet<UserAlbum> UserAlbum { get; set; }
    //public DbSet<Photo> Photo { get; set; }
    //public DbSet<Gallery> Gallery { get; set; }
    //public DbSet<GalleryAlbum> GalleryAlbum { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DataInitalize(modelBuilder);
        //modelBuilder.Entity<Post>()
        //    .HasMany(e => e.Tags)
        //    .WithMany();
    }

    private void DataInitalize(ModelBuilder modelBuilder)
    {
        // Gallery
        Guid Gallery_Gallery_1 = Guid.Parse("630e5ef0-cf44-4b82-b4e1-9838cee24e4d");
        modelBuilder.Entity<Gallery>().HasData(
           new Gallery { id = Gallery_Gallery_1, name = "gallery_1" }
        );

        // GalleryThemeInfo
        Guid Gallery_GalleryThemeInfo_1 = Guid.Parse("ba11a7ef-ddcb-4545-a40a-fc3262801f96");
        Guid Gallery_GalleryThemeInfo_2 = Guid.Parse("56bbe3de-8d3f-4630-b0c1-21a49c64c97b");
        Guid Gallery_GalleryThemeInfo_3 = Guid.Parse("1b56daf8-2992-479f-acec-c34838c91898");
        Guid Gallery_GalleryThemeInfo_4 = Guid.Parse("9f45fc55-2d8f-4008-a4ec-f6526ef280e1");
        modelBuilder.Entity<GalleryThemeInfo>().HasData(
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_1, GalleryId= Gallery_Gallery_1, title = "NATURE", description= "this is nature theme", coverImage="", sequence=1 },
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_2, GalleryId = Gallery_Gallery_1, title = "CHARACTER", description= "this is character theme", coverImage="", sequence=2 },
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_3, GalleryId = Gallery_Gallery_1, title = "EVENT", description= "this is event theme", coverImage="", sequence=3 },
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_4, GalleryId = Gallery_Gallery_1, title = "BUSINESS", description= "this is business theme", coverImage="", sequence=4 }
        );

        // ThemeAlbumInfo
        Guid Gallery_ThemeAlbumInfo_1 = Guid.Parse("061e7679-87da-4e4d-b516-dbb2443671a2");
        Guid Gallery_ThemeAlbumInfo_2 = Guid.Parse("a0331524-0418-439f-baf2-e783c26dcb04");
        Guid Gallery_ThemeAlbumInfo_3 = Guid.Parse("5af125aa-0eeb-4c01-95e9-e89d9268771e");
        Guid Gallery_ThemeAlbumInfo_4 = Guid.Parse("77a70ce5-e14f-4039-9df1-27c5ff0b605f");
        Guid Gallery_ThemeAlbumInfo_5 = Guid.Parse("adfa6ea8-2b61-487c-bf4c-a98eaa0b7f13");
        Guid Gallery_ThemeAlbumInfo_6 = Guid.Parse("41aec750-9233-4cb8-ace2-88f92a11a28c");
        modelBuilder.Entity<ThemeAlbumInfo>().HasData(
           new ThemeAlbumInfo { id = Gallery_ThemeAlbumInfo_1, GalleryThemeInfoId = Gallery_GalleryThemeInfo_1, title = "Album_1", sequence = 1 },
           new ThemeAlbumInfo { id = Gallery_ThemeAlbumInfo_2, GalleryThemeInfoId = Gallery_GalleryThemeInfo_1, title = "Album_2", sequence = 2 },
           new ThemeAlbumInfo { id = Gallery_ThemeAlbumInfo_3, GalleryThemeInfoId = Gallery_GalleryThemeInfo_2, title = "Album_3", sequence = 3 },
           new ThemeAlbumInfo { id = Gallery_ThemeAlbumInfo_4, GalleryThemeInfoId = Gallery_GalleryThemeInfo_3, title = "Album_4", sequence = 4 },
           new ThemeAlbumInfo { id = Gallery_ThemeAlbumInfo_5, GalleryThemeInfoId = Gallery_GalleryThemeInfo_4, title = "Album_5", sequence = 5 },
           new ThemeAlbumInfo { id = Gallery_ThemeAlbumInfo_6, GalleryThemeInfoId = Gallery_GalleryThemeInfo_4, title = "Album_6", sequence = 6 }
        );
    }
}
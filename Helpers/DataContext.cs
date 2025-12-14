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
        Guid Gallery_Guid_1 = Guid.Parse("630e5ef0-cf44-4b82-b4e1-9838cee24e4d");
        modelBuilder.Entity<Gallery>().HasData(
           new Gallery { id = Gallery_Guid_1, name = "gallery_1" }
        );

        // GalleryThemeInfo
        Guid Gallery_GalleryThemeInfo_1 = Guid.Parse("ba11a7ef-ddcb-4545-a40a-fc3262801f96");
        Guid Gallery_GalleryThemeInfo_2 = Guid.Parse("56bbe3de-8d3f-4630-b0c1-21a49c64c97b");
        Guid Gallery_GalleryThemeInfo_3 = Guid.Parse("1b56daf8-2992-479f-acec-c34838c91898");
        Guid Gallery_GalleryThemeInfo_4 = Guid.Parse("9f45fc55-2d8f-4008-a4ec-f6526ef280e1");
        modelBuilder.Entity<GalleryThemeInfo>().HasData(
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_1, GalleryId= Gallery_Guid_1, title = "NATURE", description= "this is nature theme", coverImage="", sequence=1 },
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_2, GalleryId = Gallery_Guid_1, title = "CHARACTER", description= "this is character theme", coverImage="", sequence=2 },
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_3, GalleryId = Gallery_Guid_1, title = "EVENT", description= "this is event theme", coverImage="", sequence=3 },
           new GalleryThemeInfo { id = Gallery_GalleryThemeInfo_4, GalleryId = Gallery_Guid_1, title = "BUSINESS", description= "this is business theme", coverImage="", sequence=4 }
        );


    }
}
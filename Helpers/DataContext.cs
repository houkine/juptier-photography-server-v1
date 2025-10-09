namespace jupter_server.Helpers;

using Microsoft.EntityFrameworkCore;
using jupter_server.Models.UserModel;

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

    public DbSet<User> User { get; set; }
    //public DbSet<Order> Order { get; set; }
    //public DbSet<Item> Item { get; set; }
    //public DbSet<UserAlbum> UserAlbum { get; set; }
    //public DbSet<Photo> Photo { get; set; }
    //public DbSet<Gallery> Gallery { get; set; }
    //public DbSet<GalleryAlbum> GalleryAlbum { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Post>()
        //    .HasMany(e => e.Tags)
        //    .WithMany();
    }
}
using Microsoft.EntityFrameworkCore;
using SitePustok.Models;

namespace SitePustok.Contexts;

public class PustokDBContext : DbContext
{
    public PustokDBContext(DbContextOptions opt):base(opt){}
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Blog> Blog { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<BlogTag> BlogTag { get; set; }
    public DbSet<ProductImage> ProductImage { get; set; }

}

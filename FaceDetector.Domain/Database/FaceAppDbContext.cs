using FaceDetector.Domain.Models.Entities;

using Microsoft.EntityFrameworkCore;

namespace FaceDetector.Domain.Database
{
    public class FaceAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FaceAppImage> Images { get; set; }
        public DbSet<ImageFolder> Folders { get; set; }

        public FaceAppDbContext()
        {
        }

        public FaceAppDbContext(DbContextOptions<FaceAppDbContext> options) : base(options)
        {
        }
    }
}

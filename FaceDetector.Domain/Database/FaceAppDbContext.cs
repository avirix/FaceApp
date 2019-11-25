using System.Diagnostics.CodeAnalysis;
using FaceDetector.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FaceDetector.Domain.Database
{
    public class FaceAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FaceAppImage> Faces { get; set; }


        public FaceAppDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected FaceAppDbContext()
        {
        }
    }
}


using System.Diagnostics.CodeAnalysis;
using FaceDetector.Domain.Models.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FaceDetector.Domain.Database
{
    public class FaceAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FaceAppImage> Faces { get; set; }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ImageFolder> ImageFolders { get; set; }
        public DbSet<FaceDetected> FaceDetecteds { get; set; }

        public FaceAppDbContext()
        {
        }

        public FaceAppDbContext(DbContextOptions<FaceAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderUserProfile>()
                .HasKey(bc => new { bc.FolderId, bc.ProfileId });
            modelBuilder.Entity<FolderUserProfile>()
                .HasOne(bc => bc.Profile)
                .WithMany(b => b.UserFolders)
                .HasForeignKey(bc => bc.FolderId);
            modelBuilder.Entity<FolderUserProfile>()
                .HasOne(bc => bc.Folder)
                .WithMany(c => c.UsersProfiles)
                .HasForeignKey(bc => bc.ProfileId);
        }
    }
}

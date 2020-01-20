using DLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DLayer.Context
{
    public partial class BlogWebAppContext : DbContext
    {
        public BlogWebAppContext()
        {
        }

        public BlogWebAppContext(DbContextOptions<BlogWebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleCategories> ArticleCategories { get; set; }
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1JE7IKV;Initial Catalog=BlogWebApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ArticleCategories>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ArticleId });

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleCategories)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleCategories_Article");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ArticleCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleCategories_Category");
            });

            modelBuilder.Entity<ArticleTags>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.ArticleId });

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleTags_Article");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleTags_Tag");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

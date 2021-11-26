using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryNews.Models;

#nullable disable

namespace LibraryNews.Data
{
    public partial class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Source> Sources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdAritcle)
                    .HasName("pk_idArticle");

                entity.ToTable("article");

                entity.Property(e => e.IdAritcle).HasColumnName("idAritcle");

                entity.Property(e => e.ArticleUrl)
                    .IsUnicode(false)
                    .HasColumnName("articleUrl");

                entity.Property(e => e.Author)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Idcategory).HasColumnName("IDcategory");

                entity.Property(e => e.Idcountry)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IDcountry");

                entity.Property(e => e.Idsource).HasColumnName("IDsource");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("date")
                    .HasColumnName("publicationDate");

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_article_category_idCategory");

                entity.HasOne(d => d.IdcountryNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Idcountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_article_country_codeCountry");

                entity.HasOne(d => d.IdsourceNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Idsource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_article_source_idSource");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("pk_idCategory");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Namecategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CodeCountry)
                    .HasName("PK_codeCountry");

                entity.ToTable("country");

                entity.Property(e => e.CodeCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codeCountry");

                entity.Property(e => e.Namecountry)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => e.IdSource)
                    .HasName("pk_idSource");

                entity.ToTable("source");

                entity.Property(e => e.IdSource).HasColumnName("idSource");

                entity.Property(e => e.Namesource)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

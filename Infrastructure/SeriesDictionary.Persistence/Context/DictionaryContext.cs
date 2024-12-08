using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Persistence.Context
{
    public class DictionaryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BGIVHPE\\SQLEXPRESS;Database=DbSeriesDictionary;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryWord> CategoryWords { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<UserStatistics> UserStatistics { get; set; }
        public DbSet<UserWord> UserWords { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordEpisode> WordEpisodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CategoryWord için birincil anahtar tanımlandı
            modelBuilder.Entity<CategoryWord>()
                .HasKey(cw => cw.CategoryWordId);

            // Category ile ilişkiyi tanımladık
            modelBuilder.Entity<CategoryWord>()
                .HasOne(cw => cw.Category)
                .WithMany(c => c.CategoryWords) // Category'de CategoryWords koleksiyonu tanımlı
                .HasForeignKey(cw => cw.CategoryId);

            // Word ile ilişkiyi tanımladık
            modelBuilder.Entity<CategoryWord>()
                .HasOne(cw => cw.Word)
                .WithMany(w => w.CategoryWords) // Word'de CategoryWords koleksiyonu tanımlı
                .HasForeignKey(cw => cw.WordId);

            // WordEpisode için birleşik anahtar (composite key) tanımlandı
            modelBuilder.Entity<WordEpisode>()
                .HasKey(we => new { we.WordId, we.EpisodeId });

            // Word ve Episode ile ilişkileri tanımladık
            modelBuilder.Entity<WordEpisode>()
                .HasOne(we => we.Word)
                .WithMany(w => w.WordEpisodes)
                .HasForeignKey(we => we.WordId);

            modelBuilder.Entity<WordEpisode>()
                .HasOne(we => we.Episode)
                .WithMany(e => e.WordEpisodes)
                .HasForeignKey(we => we.EpisodeId);

            // UserWord için birleşik anahtar (composite key) tanımlandı
            modelBuilder.Entity<UserWord>()
                .HasKey(uw => new { uw.UserId, uw.WordId });

            // User ve Word ile ilişkileri tanımladık
            modelBuilder.Entity<UserWord>()
                .HasOne(uw => uw.User)
                .WithMany(u => u.UserWords)
                .HasForeignKey(uw => uw.UserId);

            modelBuilder.Entity<UserWord>()
                .HasOne(uw => uw.Word)
                .WithMany(w => w.UserWords)
                .HasForeignKey(uw => uw.WordId);

            // UserProgress için ilişkileri tanımladık
            modelBuilder.Entity<UserProgress>()
                .HasKey(up => up.Id);

            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProgresses)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.Episode)
                .WithMany(e => e.UserProgresses)
                .HasForeignKey(up => up.EpisodeId);

            // Ek model yapılandırmalarını burada eklemeyi unutmayın
        }
    }

}

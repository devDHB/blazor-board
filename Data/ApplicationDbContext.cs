using Microsoft.EntityFrameworkCore;
using Blazor_Board.Models; // Post モデル取得

namespace Blazor_Board.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // "Posts" の名でDBに Post テーブル生成
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Author = "admin", Title = "1番目", Content = "掲示板が開かれました！", CreatedAt = new DateTime(2025, 7, 5) },
                new Post { Id = 2, Author = "admin", Title = "初めまして!", Content = "初めまして", CreatedAt = new DateTime(2025, 7, 10) },
                new Post { Id = 3, Author = "admin", Title = "Blazor Board Site", Content = "Blazor", CreatedAt = new DateTime(2025, 7, 11) },
                new Post { Id = 4, Author = "admin", Title = "いい天気です", Content = "いいですね！", CreatedAt = new DateTime(2025, 7, 11) },
                new Post { Id = 5, Author = "kim", Title = "おはようございます!", Content = "初めてですね", CreatedAt = new DateTime(2025, 7, 14) },
                new Post { Id = 6, Author = "bang", Title = "質問があります", Content = "質問！", CreatedAt = new DateTime(2025, 7, 15) }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "1234", Name = "管理者", Role = "Admin" },
                new User { Id = 2, Username = "bang", Password = "1234", Name = "方斗賢", Role = "User" },
                new User { Id = 3, Username = "kim", Password = "1234", Name = "金", Role = "User" }
            );
        }
        
    }
}
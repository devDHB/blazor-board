using Microsoft.EntityFrameworkCore;
using Blazor_Board.Models; // Post 모델을 가져오기 위해 추가

namespace Blazor_Board.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // "Posts" 라는 이름으로 데이터베이스에 Post 테이블을 만들도록 설정
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Author = "Admin", Title = "1番目", Content = "掲示板が開かれました！", CreatedAt = new DateTime(2025, 7, 5) },
                new Post { Id = 2, Author = "Admin", Title = "初めまして!", Content = "初めまして", CreatedAt = new DateTime(2025, 7, 10) },
                new Post { Id = 3, Author = "Admin", Title = "Blazor Board Site", Content = "Blazor", CreatedAt = new DateTime(2025, 7, 11) },
                new Post { Id = 4, Author = "Admin", Title = "いい天気です", Content = "いいですね！", CreatedAt = new DateTime(2025, 7, 11) },
                new Post { Id = 5, Author = "Kim", Title = "おはようございます!", Content = "初めてですね", CreatedAt = new DateTime(2025, 7, 14) },
                new Post { Id = 6, Author = "Bang", Title = "質問があります", Content = "質問！", CreatedAt = new DateTime(2025, 7, 15) }
            );
        }
        public DbSet<User> Users { get; set; }
    }
}
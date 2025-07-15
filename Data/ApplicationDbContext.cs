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
                new Post { Id = 1, Author = "Admin", Title = "첫 번째 공지사항", Content = "게시판이 열렸습니다!", CreatedAt = new DateTime(2025, 7, 13) },
                new Post { Id = 2, Author = "Gildong", Title = "안녕하세요!", Content = "처음으로 글을 남깁니다.", CreatedAt = new DateTime(2025, 7, 14) },
                new Post { Id = 3, Author = "Chunhyang", Title = "질문 있습니다.", Content = "Blazor는 어떻게 사용하나요?", CreatedAt = new DateTime(2025, 7, 15) }
            );
        }
        public DbSet<User> Users { get; set; }
    }
}
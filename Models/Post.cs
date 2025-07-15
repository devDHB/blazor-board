namespace Blazor_Board.Models; // 이 부분은 프로젝트 이름에 맞게 자동으로 설정됩니다.

public class Post
{
    public int Id { get; set; } // 글 번호 (자동으로 1씩 증가)
    public string Title { get; set; } // 글 제목
    public string Content { get; set; } // 글 내용
    public string Author { get; set; } // 작성자
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; // 작성 날짜 (자동으로 현재 시간 저장)
}
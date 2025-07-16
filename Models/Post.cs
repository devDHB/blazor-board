namespace Blazor_Board.Models;

public class Post
{
    public int Id { get; set; } 
    public string Title { get; set; } // タイトル
    public string Content { get; set; } // 内容
    public string Author { get; set; } // 作成者
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; // 日付
}
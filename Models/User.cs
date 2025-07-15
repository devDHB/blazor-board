using System.ComponentModel.DataAnnotations;

namespace Blazor_Board.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "IDを入力してください。.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "パスワードを入力してください。")]
    public string Password { get; set; } // 暗号化なし

    [Required(ErrorMessage = "名前入力してください。")]
    public string Name { get; set; }

    public string Role { get; set; } = "User"; // 기본값은 "User"
}
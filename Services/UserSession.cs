using Blazor_Board.Models;
using Blazored.LocalStorage; // 👈 추가

namespace Blazor_Board.Services;

public class UserSession
{
    private readonly ILocalStorageService _localStorage;
    private const string UserKey = "currentUser"; // 👈 Local Storage에 저장될 키 이름

    public User? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;
    public event Action? OnChange;

    public UserSession(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    // 앱 시작 시 Local Storage에서 로그인 정보 불러오기
    public async Task LoadUserFromStorage()
    {
        if (await _localStorage.ContainKeyAsync(UserKey))
        {
            CurrentUser = await _localStorage.GetItemAsync<User>(UserKey);
            NotifyStateChanged(); // 👈 이 신호를 보내는 코드를 추가하세요!
        }
    }

    public async Task Login(User user)
    {
        CurrentUser = user;
        await _localStorage.SetItemAsync(UserKey, user); // 👈 Local Storage에 저장
        NotifyStateChanged();
    }

    public async Task Logout()
    {
        CurrentUser = null;
        await _localStorage.RemoveItemAsync(UserKey); // 👈 Local Storage에서 삭제
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
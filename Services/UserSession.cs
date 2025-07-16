using Blazor_Board.Models;
using Blazored.LocalStorage;

namespace Blazor_Board.Services;

public class UserSession
{
    private readonly ILocalStorageService _localStorage;
    private const string UserKey = "currentUser"; // Local Storageに保存されるキー名

    public User? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;
    public event Action? OnChange;

    public UserSession(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    // アプリ起動時にLocal Storageからログイン情報を読み込む
    public async Task LoadUserFromStorage()
    {
        if (await _localStorage.ContainKeyAsync(UserKey))
        {
            CurrentUser = await _localStorage.GetItemAsync<User>(UserKey);
            NotifyStateChanged();
        }
    }

    public async Task Login(User user)
    {
        CurrentUser = user;
        await _localStorage.SetItemAsync(UserKey, user); // Local Storageに保存
        NotifyStateChanged();
    }

    public async Task Logout()
    {
        CurrentUser = null;
        await _localStorage.RemoveItemAsync(UserKey); // Local Storageから削除
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
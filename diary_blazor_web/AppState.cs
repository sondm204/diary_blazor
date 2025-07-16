using diary_blazor_web.Models;

namespace diary_blazor_web
{
    public class AppState
    {
        public string ShareData { get; set; }
        public User CurrentUser { get; set; }

        public event Action? OnChange;

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void ClearCurrentUser()
        {
            CurrentUser = null;
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

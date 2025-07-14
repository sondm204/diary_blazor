using diary_blazor_web.Models;

namespace diary_blazor_web.Services
{
    public class ToastService
    {
        private readonly List<Toast> _toasts = new();
        private readonly int _maxToasts = 1;
        public event Func<Task>? OnToastsChanged;

        public IReadOnlyList<Toast> Toasts => _toasts.AsReadOnly();

        public async Task ShowToast(string message, ToastType type = ToastType.Info, int duration = 5000)
        {
            while (_toasts.Count >= _maxToasts)
            {
                _toasts.RemoveAt(0);
            }
            var toast = new Toast
            {
                Message = message,
                Type = type,
                Duration = duration
            };

            _toasts.Add(toast);
            await NotifyStateChanged();

            //Auto - remove after duration
            if (duration > 0)
            {
                _ = Task.Delay(duration).ContinueWith(async _ => await RemoveToast(toast.Id));
            }
        }

        private async Task NotifyStateChanged()
        {
            if (OnToastsChanged != null)
            {
                await OnToastsChanged.Invoke();
            }
        }

        public async Task ShowSuccess(string message, int duration = 5000)
            => await ShowToast(message, ToastType.Success, duration);

        public async Task ShowError(string message, int duration = 5000)
            => await ShowToast(message, ToastType.Error, duration);

        public async Task ShowWarning(string message, int duration = 5000)
            => await ShowToast(message, ToastType.Warning, duration);

        public async Task ShowInfo(string message, int duration = 5000)
            => await ShowToast(message, ToastType.Info, duration);

        public async Task RemoveToast(string id)
        {
            var toast = _toasts.FirstOrDefault(t => t.Id == id);
            if (toast != null)
            {
                _toasts.Remove(toast);
                await NotifyStateChanged();
            }
        }

        public async Task ClearAll()
        {
            _toasts.Clear();
            await NotifyStateChanged();
        }
    }
}

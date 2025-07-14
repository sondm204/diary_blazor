namespace diary_blazor_web.Models
{
    public class Toast
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Message { get; set; } = string.Empty;
        public ToastType Type { get; set; } = ToastType.Info;
        public int Duration { get; set; } = 5000; // milliseconds
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsVisible { get; set; } = true;
    }

    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }
}

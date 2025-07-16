using System.ComponentModel.DataAnnotations;

namespace diary_blazor_web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng điền tên đăng nhập")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string? Password { get; set; }
    }
}

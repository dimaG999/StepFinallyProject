using packstation.Enums;

namespace packstation.Dtos
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}

namespace HotelRu.Contracts
{
    public class GetUserResponse
    {
            public int Id { get; set; }
            public string Firstname { get; set; } = null!;
            public string Lastname { get; set; } = null!;
            public string Login { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string PasswordHash { get; set; } = null!;
        
    
    }
}

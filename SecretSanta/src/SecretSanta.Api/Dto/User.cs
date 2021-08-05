namespace SecretSanta.Api.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public static User? ToDto(Data.User? user)
        {
            if (user is null) return null;
            return new User
            {
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static Data.User? FromDto(User? user)
        {
            if (user is null) return null;
            return new Data.User
            {
                Id = user.Id,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email ?? ""
            };
        }
    }
}

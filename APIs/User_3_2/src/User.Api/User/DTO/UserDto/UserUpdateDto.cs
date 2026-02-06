namespace User.Api.User.DTO.UserDto
{
    public class UserUpdateDto
    {
       
        public string LastName { get; set; }  // familiya
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
    }

}

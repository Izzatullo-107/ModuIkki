namespace User.Api.User.DTO.UserDto
{
    public class UserGetDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public bool UserBlocked { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        //----------------------------------------------------------------


        /*
        public Guid UserId { get; set; }
        public string LastName { get; set; }  // familiya
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Position { get; set; }
        */
    }
}

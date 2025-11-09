namespace WebApiShop
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Password { get; set; }
    }
    public class ExistingUser
    {
        public string Email { get; set; }
        public int Password { get; set; }
    }
}

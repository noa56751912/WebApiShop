namespace Entity;

public class User
{

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
}
public class ExistingUser
{
    public string Email { get; set; }
    public string Password { get; set; }
}

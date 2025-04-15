using System.ComponentModel.DataAnnotations;

namespace Business_Layer;
public class User
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(20)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(20)]
    [Required]
    public string Email { get; set; }
    [MaxLength(20)]
    [Required]
    public string Password { get; set; }
    [Range(10,80)]
    [Required]
    public int Age { get; set; }
    public List<Game> Games { get; set; }
    [MaxLength(20)]
    [Required]
    public string UserName { get; set; }
    public List<User> Friends { get; set; }

    public User(string firstName, string lastName, string email, string password, int age, string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Age = age;
        UserName = userName;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Business_Layer;

public class GameType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<User> Users { get; set; }

    public GameType(string name)
    {
        Name = name;
    }
}

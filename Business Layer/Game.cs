using System.ComponentModel.DataAnnotations;

namespace Business_Layer;

public class Game
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<GameType> GameTypes { get; set; }

    public Game(string name)
    {
        Name = name;
    }
}

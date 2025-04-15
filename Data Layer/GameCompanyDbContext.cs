namespace Data_Layer;

public class GameCompanyDbContext : DbContext
{
    internal static GameCompanyDbContext _dbContext;
    public DbSet<GameType> GameTypes { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public GameCompanyDbContext(): base(){}
    public GameCompanyDbContext(DbContextOptions options): base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) base.OnConfiguring(optionsBuilder.UseSqlite("Data Source=GameCompanyDb.db3"));
    }

}

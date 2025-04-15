using System.Reflection.Metadata.Ecma335;

namespace Data_Layer;

public class GameContext: IDb<Game,int>
{
    private readonly GameCompanyDbContext _dbContext;

    public GameContext(GameCompanyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(Game entity)
    {
        _dbContext.Games.Add(entity);
        _dbContext.SaveChanges();
    }

    public Game Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Game> query = _dbContext.Games;
        if (useNavigationalProperties) query = query.Include(q => q.GameTypes);
        if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
        Game game = query.FirstOrDefault(x => x.Id == key);
        if (game is null) throw new KeyNotFoundException();
        return game;
    }

    public IEnumerable<Game> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Game> query = _dbContext.Games;
        if (useNavigationalProperties) query = query.Include(q => q.GameTypes);
        if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
        return query.ToList();
    }

    public void Update(Game entity, bool useNavigationalProperties = false)
    {
        Game game = Read(entity.Id, useNavigationalProperties);
        game.Name = entity.Name;
        if (useNavigationalProperties)
        {
            List<GameType> gameTypes = new List<GameType>();
            foreach (var type in entity.GameTypes)
            {
                GameType newGameType = _dbContext.GameTypes.FirstOrDefault(x => x.Id == type.Id);
                if(newGameType == null) gameTypes.Add(type);
                else gameTypes.Add(newGameType);
            }
            game.GameTypes = entity.GameTypes;
        }        
        _dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        Game game = Read(key,false);
        _dbContext.Games.Remove(game);
        _dbContext.SaveChanges();
    }
}

namespace Data_Layer;

public class GameTypeContext:IDb<GameType,int>
{
    private readonly GameCompanyDbContext _dbContext;
    public GameTypeContext(GameCompanyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(GameType entity)
    {
        _dbContext.GameTypes.Add(entity);
        _dbContext.SaveChanges();
    }

    public GameType Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<GameType> query = _dbContext.GameTypes;
        if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
        GameType gameType = query.FirstOrDefault(x => x.Id == key);
        if (gameType is null) throw new KeyNotFoundException();
        return gameType;
    }

    public IEnumerable<GameType> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<GameType> query = _dbContext.GameTypes;
        if (useNavigationalProperties) query = query.Include(q => q.Users);
        if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
        return query.ToList();
    }

    public void Update(GameType entity, bool useNavigationalProperties = false)
    {
        GameType gameType = Read(entity.Id, useNavigationalProperties);
        gameType.Name = entity.Name;
        if (useNavigationalProperties)
        {
            List<User> users = new List<User>();
            foreach (var user in entity.Users)
            {
                User newUser = _dbContext.Users.FirstOrDefault(x => x.Id == user.Id);
                if(newUser == null) users.Add(user);
                else users.Add(newUser);
            }
            gameType.Users = entity.Users;
        }        
        _dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        throw new NotImplementedException();
    }
}

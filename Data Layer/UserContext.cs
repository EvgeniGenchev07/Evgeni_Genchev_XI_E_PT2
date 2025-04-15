namespace Data_Layer;

public class UserContext : IDb<User,int>
{
    private readonly GameCompanyDbContext _dbContext;

    public UserContext(GameCompanyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(User entity)
    {
        _dbContext.Users.Add(entity);
        _dbContext.SaveChanges();
    }

    public User Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<User> query = _dbContext.Users;
        if(useNavigationalProperties) query = query.Include(q=>q.Friends).Include(q=>q.Games);
        if(isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
        User user = query.FirstOrDefault(x => x.Id == key);
        if (user is null) throw new KeyNotFoundException();
        return user;
    }

    public IEnumerable<User> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<User> query = _dbContext.Users;
        if(useNavigationalProperties) query = query.Include(q=>q.Friends).Include(q=>q.Games);
        if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
        return query.ToList();
    }

    public void Update(User entity, bool useNavigationalProperties = false)
    {
        User user = Read(entity.Id, useNavigationalProperties);
        _dbContext.Entry(user).CurrentValues.SetValues(entity);
        if (useNavigationalProperties)
        {
            List<User> users = new List<User>();
            foreach (var fr in entity.Friends)
            {
                User friend = _dbContext.Users.FirstOrDefault(x => x.Id == fr.Id);
                if(friend == null) users.Add(fr);
                else users.Add(friend);
            }
            user.Friends = entity.Friends;
            
            List<Game> games = new List<Game>();
            foreach (var gm in entity.Games)
            {
                Game game = _dbContext.Games.FirstOrDefault(x => x.Id == gm.Id);
                if(game == null) games.Add(gm);
                else games.Add(game);
            }
            user.Games = entity.Games;
        }        
        _dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        User user = Read(key,false);
        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
    }
}

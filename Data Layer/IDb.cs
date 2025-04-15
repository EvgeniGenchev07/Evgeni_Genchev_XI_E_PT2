namespace Data_Layer;

public interface IDb<T,K>
{
    void Create(T entity);
    T Read(K key,bool useNavigationalProperties=false,bool isReadOnly=false);
    IEnumerable<T> ReadAll(bool useNavigationalProperties= false,bool isReadOnly = false);
    void Update(T entity,bool useNavigationalProperties=false);
    void Delete(K key);
}

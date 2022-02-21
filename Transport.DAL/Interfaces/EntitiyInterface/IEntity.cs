namespace Transport.DAL.Interfaces.EntitiyInterface
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

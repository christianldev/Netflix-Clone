namespace Netflix.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Declaracion o matricula de nuestras interfaces de repositorios
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
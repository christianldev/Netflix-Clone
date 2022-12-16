using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Declaracion o matricula de nuestras interfaces de repositorios
        ICategoryRepository Category { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
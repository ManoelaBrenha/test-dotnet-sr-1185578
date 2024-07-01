using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracking.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Remove(T obj);
        void Edit(T obj);
        void Dispose();

    }
}

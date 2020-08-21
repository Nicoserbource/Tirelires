using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tirelires.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Create(T item);
        T Delete(T item);
        T Edit(T item);
        T Get(int id);
        T Get(string id);
        IEnumerable<T> GetAll();
    }
}

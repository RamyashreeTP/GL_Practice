using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectmanagement.Models
{
    public interface ICrudOperations<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T obj);
        IEnumerable<T> Update(T obj);
        bool Delete(int id);
    }
}

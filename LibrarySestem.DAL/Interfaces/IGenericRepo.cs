using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.DAL.Interfaces
{
    public interface IGenericRepo<T> where T:class
    {
        void Add(T item);

        T Get(Func<T, bool> predicate);

        void Update(T item);

        void Delete(Func<T, bool> predicate);

        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
    }
}

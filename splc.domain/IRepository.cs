using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splc.domain
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T GetById(Guid id);
        T GetAll();
    }
}

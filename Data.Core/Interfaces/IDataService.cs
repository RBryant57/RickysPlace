using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Interfaces
{
    public interface IDataService : IDisposable
    {
        int Add(IEntity entity);

        void Edit(IEntity entity);

        void Delete(IEntity entity);

        IEntity FindById(object id);

        List<IEntity> GetAll();

    }
}
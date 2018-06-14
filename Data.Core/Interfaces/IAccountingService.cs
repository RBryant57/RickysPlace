using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Interfaces
{
    public interface IAccountingService
    {
        void AddCost(IAccountingEntity entity);
        void EditCost(IAccountingEntity entity);
        void DeleteCost(IAccountingEntity entity);
        IAccountingEntity FindCostById(object id);
        List<IAccountingEntity> GetAllCosts();
    }
}

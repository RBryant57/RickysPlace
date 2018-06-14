using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Interfaces
{
    public interface IAccountingEntity : IDisposable
    {
        int Id { get; set; }
        int Quantity { get; set; }
        decimal Cost { get; set; }
        int EntityId { get; set; }
        int QuantityUnitId { get; set; }
        DateTime Date { get; set; }
    }
}
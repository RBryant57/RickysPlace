using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using Music.Entities.Models;

namespace Music.Service.Interfaces
{
    public interface IInstrumentService : IDataService
    {
        void AddAsync(Instrument instrument);
        
        void EditAsync(Instrument instrument);

        Task<Instrument> FindByIdAsync(int id);

        Task<List<Instrument>> GetAllAsync();
    }
}
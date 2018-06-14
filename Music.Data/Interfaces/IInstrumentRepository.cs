using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using Music.Entities.Models;

namespace Music.Data.Interfaces
{
    public interface IInstrumentRepository : IRepository<Instrument>
    {

    }
}
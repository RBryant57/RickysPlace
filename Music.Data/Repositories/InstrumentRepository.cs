using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using Music.Data.Interfaces;
using Music.Entities.Models;

namespace Music.Data.Repositories
{
    public class InstrumentRepository : Repository<MusicContext, Instrument>, IInstrumentRepository
    {

    }
}
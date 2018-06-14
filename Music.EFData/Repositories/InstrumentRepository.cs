using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using Music.Entities.Models;
using Music.Repositories.Interfaces;

namespace Music.EFData.Repositories
{
    public class InstrumentRepository : Repository<MusicContext, Instrument>, IInstrumentRepository
    {

    }
}
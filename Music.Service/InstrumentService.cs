using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using Music.EFData.Repositories;
using Music.Entities.Models;
using Music.Repositories.Interfaces;
using Music.Service.Interfaces;

namespace Music.Service
{
    public class InstrumentService : IInstrumentService
    {
        private IInstrumentRepository repository;

        public InstrumentService(IInstrumentRepository iRepository)
        {
            this.repository = iRepository;
        }

        public int Add(IEntity entity)
        {
            this.repository.Add((Instrument)entity);
            this.repository.Save();

            return 0;
        }

        public async void AddAsync(Instrument entity)
        {
            this.repository.Add((Instrument)entity);
            this.repository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Instrument)entity);
            this.repository.Save();
        }

        public async void EditAsync(Instrument entity)
        {
            this.repository.Edit(entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((Instrument)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public void Dispose()
        {

        }
        public async Task<Instrument> FindByIdAsync(int id)
        {
            using (var instruments = new InstrumentRepository())
            {
                return await (from instrument in instruments.GetAll()
                              where instrument.Id == id
                              select instrument).FirstAsync();
            }
        }

        public List<IEntity> GetAll()
        {
            List<IEntity> list = new List<IEntity>();

            foreach (var entity in this.repository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public async Task<List<Instrument>> GetAllAsync()
        {
            using (var instruments = new InstrumentRepository())
            {
                return await (from instrument in instruments.GetAll()
                              select instrument).ToListAsync();
            }
        }
    }
}
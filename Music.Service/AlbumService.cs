using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Music.Entities.Models;
using Music.Repositories.Interfaces;
using Music.Service.Interfaces;

namespace Music.Service
{
    public class AlbumService : IAlbumService
    {
        private IAlbumRepository albumRepository;

        public AlbumService(IAlbumRepository repository)
        {
            this.albumRepository = repository;
        }

        public void Add(Album album)
        {
            this.albumRepository.Add(album);
            this.albumRepository.Save();
        }

        public void Edit(Album album)
        {
            this.albumRepository.Edit(album);
            this.albumRepository.Save();
        }

        public void Delete(Album album)
        {
            this.albumRepository.Delete(album);
            this.albumRepository.Save();
        }

        public Album FindById(int id)
        {
            return this.albumRepository.FindById(id);
        }

        public List<Album> GetAll()
        {
            return this.albumRepository.GetAll().ToList();
        }

        public List<Song> GetSongs()
        {
            return this.albumRepository.GetSongs();
        }

    }
}
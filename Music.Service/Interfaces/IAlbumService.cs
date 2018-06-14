using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Music.Entities.Models;

namespace Music.Service.Interfaces
{
    public interface IAlbumService
    {
        void Add(Album album);

        void Edit(Album album);

        void Delete(Album album);

        Album FindById(int id);

        List<Album> GetAll();

        List<Song> GetSongs();
    }
}
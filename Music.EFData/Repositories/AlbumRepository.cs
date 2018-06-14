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
    public class AlbumRepository : Repository<MusicContext, Album>, IAlbumRepository
    {
        public List<Song> GetSongs()
        {
            var songs = from song in this.Context.Songs
                        join albumSong in this.Context.AlbumsSongs on song.Id equals albumSong.SongId
                        join album in this.Context.Albums on albumSong.AlbumId equals this.Entity.Id
                        select song;

            return songs.ToList();
            
        }
    }
}
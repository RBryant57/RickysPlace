using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Music.EFData.Mapping;
using Music.Entities.Models;

namespace Music.EFData
{
    public partial class MusicContext : DbContext
    {
        static MusicContext()
        {
            Database.SetInitializer<MusicContext>(null);
        }

        public MusicContext()
            : base("Name=MusicContext")
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumsAward> AlbumsAwards { get; set; }
        public DbSet<AlbumsGroup> AlbumsGroups { get; set; }
        public DbSet<AlbumsPAlbum> AlbumsPAlbums { get; set; }
        public DbSet<AlbumsProducer> AlbumsProducers { get; set; }
        public DbSet<AlbumsSong> AlbumsSongs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistsAward> ArtistsAwards { get; set; }
        public DbSet<ArtistsGroup> ArtistsGroups { get; set; }
        public DbSet<ArtistsMusician> ArtistsMusicians { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<CompositionsComposer> CompositionsComposers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusiciansGroup> MusiciansGroups { get; set; }
        public DbSet<MusiciansInstrument> MusiciansInstruments { get; set; }
        public DbSet<PhysicalAlbum> PhysicalAlbums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongsArtist> SongsArtists { get; set; }
        public DbSet<SongsAward> SongsAwards { get; set; }
        public DbSet<SongsGroup> SongsGroups { get; set; }
        public DbSet<SongsProducer> SongsProducers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Album1> Albums1 { get; set; }
        public DbSet<AlbumsWithSong> AlbumsWithSongs { get; set; }
        public DbSet<ArtistsWithMusician> ArtistsWithMusicians { get; set; }
        public DbSet<MusiciansWithInstrument> MusiciansWithInstruments { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song1> Songs1 { get; set; }
        public DbSet<ViewSong> ViewSongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new AlbumsAwardMap());
            modelBuilder.Configurations.Add(new AlbumsGroupMap());
            modelBuilder.Configurations.Add(new AlbumsPAlbumMap());
            modelBuilder.Configurations.Add(new AlbumsProducerMap());
            modelBuilder.Configurations.Add(new AlbumsSongMap());
            modelBuilder.Configurations.Add(new ArtistMap());
            modelBuilder.Configurations.Add(new ArtistsAwardMap());
            modelBuilder.Configurations.Add(new ArtistsGroupMap());
            modelBuilder.Configurations.Add(new ArtistsMusicianMap());
            modelBuilder.Configurations.Add(new CompositionMap());
            modelBuilder.Configurations.Add(new CompositionsComposerMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new InstrumentMap());
            modelBuilder.Configurations.Add(new LabelMap());
            modelBuilder.Configurations.Add(new MusicianMap());
            modelBuilder.Configurations.Add(new MusiciansGroupMap());
            modelBuilder.Configurations.Add(new MusiciansInstrumentMap());
            modelBuilder.Configurations.Add(new PhysicalAlbumMap());
            modelBuilder.Configurations.Add(new SongMap());
            modelBuilder.Configurations.Add(new SongsArtistMap());
            modelBuilder.Configurations.Add(new SongsAwardMap());
            modelBuilder.Configurations.Add(new SongsGroupMap());
            modelBuilder.Configurations.Add(new SongsProducerMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new Album1Map());
            modelBuilder.Configurations.Add(new AlbumsWithSongMap());
            modelBuilder.Configurations.Add(new ArtistsWithMusicianMap());
            modelBuilder.Configurations.Add(new MusiciansWithInstrumentMap());
            modelBuilder.Configurations.Add(new ProducerMap());
            modelBuilder.Configurations.Add(new Song1Map());
            modelBuilder.Configurations.Add(new ViewSongMap());
        }
    }
}

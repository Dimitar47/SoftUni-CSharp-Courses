namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                        .Where(x => x.ProducerId == producerId)
                        .AsEnumerable()
                         .Select(x => new
                         {
                             AlbumName = x.Name,
                             AlbumReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                             AlbumProducerName = x.Producer.Name,
                             AlbumSongs = x.Songs
                             .OrderByDescending(x => x.Name).ThenBy(x => x.Writer.Name)
                             .Select(y => new
                             {
                                 SongName = y.Name,
                                 SongPrice = $"{y.Price:f2}",
                                 SongWriterName = y.Writer.Name,

                             }).ToList(),
                             AlbumPrice = $"{x.Price:f2}"

                         })

                       .OrderByDescending(x => decimal.Parse(x.AlbumPrice))
            .ToList();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var album in albums)
            {
                stringBuilder.AppendLine($"-AlbumName: {album.AlbumName}");
                stringBuilder.AppendLine($"-ReleaseDate: {album.AlbumReleaseDate}");
                stringBuilder.AppendLine($"-ProducerName: {album.AlbumProducerName}");

                stringBuilder.AppendLine("-Songs:");
                int i = 1;
                foreach (var song in album.AlbumSongs)
                {
                    stringBuilder.AppendLine($"---#{i++}");
                    stringBuilder.AppendLine($"---SongName: {song.SongName}");
                    stringBuilder.AppendLine($"---Price: {song.SongPrice}");
                    stringBuilder.AppendLine($"---Writer: {song.SongWriterName}");

                }

                stringBuilder.AppendLine($"-AlbumPrice: {album.AlbumPrice}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {

            var songs = context.Songs
            .AsEnumerable()
            .Where(x => x.Duration.TotalSeconds > (duration * 1.0))
            .Select(song => new
            {
                SongName = song.Name,
                SongPerformersSelected = song.SongPerformers
                .Select(x => new
                {
                    PerformerFullName = x.Performer.FirstName + " " + x.Performer.LastName
                }).ToList(),
                WriterName = song.Writer.Name,
                AlbumProducer = song.Album.Producer.Name,
                SongDuration = song.Duration.ToString("c"),

            })
            .OrderBy(x => x.SongName).ThenBy(x => x.WriterName).ToList();
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;
            foreach (var song in songs)
            {
                stringBuilder.AppendLine($"-Song #{i++}");
                stringBuilder.AppendLine($"---SongName: {song.SongName}");
                stringBuilder.AppendLine($"---Writer: {song.WriterName}");
                var songPerformersSelected = song.SongPerformersSelected;
                if (songPerformersSelected.Count > 0)
                {
                    if (songPerformersSelected.Count > 1)
                    {

                        foreach (var songPerformer in songPerformersSelected.OrderBy(x => x.PerformerFullName))
                        {

                            stringBuilder.AppendLine($"---Performer: {songPerformer.PerformerFullName}");
                        }
                    }
                    else
                    {
                        foreach (var songPerformer in songPerformersSelected)
                        {

                            stringBuilder.AppendLine($"---Performer: {songPerformer.PerformerFullName}");
                        }
                    }
                }
                stringBuilder.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                stringBuilder.AppendLine($"---Duration: {song.SongDuration}");

            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}

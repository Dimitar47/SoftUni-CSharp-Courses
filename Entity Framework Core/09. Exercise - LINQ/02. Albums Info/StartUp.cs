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

            Console.WriteLine(ExportAlbumsInfo(context, 4));
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
            throw new NotImplementedException();
        }
    }
}

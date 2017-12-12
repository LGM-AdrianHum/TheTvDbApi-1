using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TheTvDbApi.Series.DataTypes
{
    public class ImageInfo
    {
        public int Id { get; set; }
        public string KeyType { get; set; }
        public string SubKey { get; set; }
        public string FileName { get; set; }
        public string Resolution { get; set; }
        public Ratingsinfo RatingsInfo { get; set; }
        public string Thumbnail { get; set; }

        public override string ToString()
        {
            return $"{Id}, {FileName} ({KeyType}, {SubKey}";
        }


        public async Task<string> GetImage(string folder)
        {
            try
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                var finalpath = Path.Combine(folder, FileName.Replace("/", "\\"));
                var finalfolder = Path.GetDirectoryName(finalpath);
                if (!string.IsNullOrEmpty(finalfolder) && !Directory.Exists(finalfolder))
                    Directory.CreateDirectory(finalfolder);
                if (!File.Exists(finalpath))
                {
                    var uri = new Uri("https://www.thetvdb.com/banners/" + FileName);
                    var wc = new WebClient();
                    await wc.DownloadFileTaskAsync(uri, finalpath);
                }
                return finalpath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                return null;
            }
    }
    }
}
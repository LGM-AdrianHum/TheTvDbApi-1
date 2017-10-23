//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi.Mvvm/MediaFiles.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-24-8:11 AM
// Modified : 2017-10-24-8:11 AM

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TheTvDbApi.Mvvm
{
    public class MediaFiles
    {
        public MediaFiles(string s)
        {
            DirInfo = new DirectoryInfo(s);
            if (!DirInfo.Exists) return;
            Setup(s);
        }

        public List<MediaFile> AllMedia { get; set; }

        public DirectoryInfo DirInfo { get; set; }

        private async void Setup(string s)
        {
            var res = await Task.Run(() =>
            {
                var r = Directory.GetFiles(s, "*.*", SearchOption.AllDirectories);
                return r;
            });
            var resultCollection = new ConcurrentBag<MediaFile>();
            Parallel.ForEach(res, file => { resultCollection.Add(new MediaFile(file)); });
            AllMedia = resultCollection.ToList();
        }

        public MediaFile Find(int s, int e)
        {
            return new MediaFile();
        }
    }
}
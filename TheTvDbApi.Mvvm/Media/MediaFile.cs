//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi.Mvvm/MediaFile.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-24-8:11 AM
// Modified : 2017-10-24-8:12 AM

using System.Collections.Generic;

namespace TheTvDbApi.Mvvm
{
    public class MediaFile
    {
        public MediaFile(string file)
        {
            Fullname = file;
            FileKey = file;
            Season = 0;
            Episodes = new List<int>();
            Episode = 0;
        }

        public MediaFile()
        {
        }

        public int Episode { get; set; }
        public int Season { get; set; }
        public List<int> Episodes { get; set; }
        public string FileKey { get; set; }
        public string Fullname { get; set; }
    }
}
//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi/EpisodeResponse.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:20 AM
// Modified : 2017-10-27-7:21 AM

using System.Collections.Generic;

namespace TheTvDbApi.Series.DataTypes
{
    internal class EpisodeResponse
    {
        public Links Links { get; set; }
        public IEnumerable<EpisodeInfo> data { get; set; }
    }

    internal class Links
    {
        public int First { get; set; }
        public int Last { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }
    }
}
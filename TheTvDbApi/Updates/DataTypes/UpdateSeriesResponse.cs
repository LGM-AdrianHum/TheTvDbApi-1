//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi/UpdateSeriesResponse.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:40 AM
// Modified : 2017-10-27-7:50 AM

using System;

namespace TheTvDbApi.Updates.DataTypes
{
    public class UpdateSeriesResponse
    {
        public UpdatedSeries[] data { get; set; }
        public long ToEpochTime { get; set; }
        public long FromEpochTime { get; set; }

        public DateTime FromDateTime => FromEpochTime.FromUnixTime();
        public DateTime ToDateTime => ToEpochTime.FromUnixTime();
    }

    
}
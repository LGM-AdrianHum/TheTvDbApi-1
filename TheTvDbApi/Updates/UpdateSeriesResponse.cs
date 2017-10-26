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
using TheTvDbApi.Updates.DataTypes;

namespace TheTvDbApi.Updates
{
    public class UpdateSeriesResponse
    {
        public UpdatedSeries[] Data { get; set; }

        //Store the references to when the records were created.
        public long ToEpochTime { get; set; }

        public long FromEpochTime { get; set; }

        //Added some references that allow us to see time 
        //in DateTime format instead of epoch. Decided it
        //was the wrong place to do it in my WPF/UWP form
        //as a converter.
        public DateTime FromDateTime => FromEpochTime.FromUnixTime();

        public DateTime ToDateTime => ToEpochTime.FromUnixTime();
    }
}
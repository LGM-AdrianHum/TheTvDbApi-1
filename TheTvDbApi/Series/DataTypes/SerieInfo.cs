//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// File: RollThroughLibrary/TheTvDbApi/SerieInfo.cs
// User: Adrian Hum/
// 
// Created:  2017-10-23 5:16 PM
// Modified: 2017-10-28 9:39 AM

using System;
using TheTvDbApi.Updates;

namespace TheTvDbApi.Series.DataTypes
{
    public class SerieInfo
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string[] Aliases { get; set; }
        public string Banner { get; set; }
        public string SeriesId { get; set; } // Please check this data against your collections, 
        public string Status { get; set; }
        public string FirstAired { get; set; }
        public string Network { get; set; }
        public string NetworkId { get; set; }
        public string Runtime { get; set; }
        public string[] Genre { get; set; }
        public string Overview { get; set; }

        /// <summary>
        ///     <see cref="UpdatedSeries.LastUpdated" />
        ///     Epoch datetime when this record was last updated.
        /// </summary>
        public DateTime LastUpdatedDateTime => LastUpdated.FromUnixTime();

        public long LastUpdated { get; set; }
        public string AirsDayOfWeek { get; set; }
        public string AirsTime { get; set; }
        public string Rating { get; set; }
        public string ImdbId { get; set; }
        public string Zap2ItId { get; set; }
        public string Added { get; set; }
        public decimal SiteRating { get; set; }
        public int SiteRatingCount { get; set; }
    }
}
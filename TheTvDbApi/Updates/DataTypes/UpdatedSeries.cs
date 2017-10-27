//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi/UpdatedSeries.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:48 AM
// Modified : 2017-10-27-7:48 AM

using System;

namespace TheTvDbApi.Updates.DataTypes
{
    /// <summary>
    /// Implementation of the update series data as per the api.
    /// Swagger Source: https://api.thetvdb.com/swagger#!/Updates/get_updated_query
    /// </summary>
    public class UpdatedSeries
    {
        public int Id { get; set; }

        /// <summary>
        /// Epoch Since The Data Was Last Updated.
        /// <see cref="TheTvDbApi.Series.DataTypes.SerieInfo.LastUpdated"/>
        /// </summary>
        public long LastUpdated { get; set; }

        //Added for clarity.
        public DateTime LastUpdateDateTime => LastUpdated.FromUnixTime();
    }
}
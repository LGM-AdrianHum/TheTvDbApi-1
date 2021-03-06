﻿namespace TheTvDbApi.Series.DataTypes {
    public class SerieInfo {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string[] Aliases { get; set; }
        public string Banner { get; set; }
        public int? SeriesId { get; set; }
        public string Status { get; set; }
        public string FirstAired { get; set; }
        public string Network { get; set; }
        public string NetworkId { get; set; }
        public string Runtime { get; set; }
        public string[] Genre { get; set; }
        public string Overview { get; set; }
        
        /// <summary>
        /// <see cref="TheTvDbApi.Updates.DataTypes.UpdatedSeries.LastUpdated"/>
        /// Epoch datetime when this record was last updated.
        /// </summary>
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
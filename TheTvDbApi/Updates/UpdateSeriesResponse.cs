using System;

namespace TheTvDbApi.Updates
{
    public class UpdateSeriesResponse
    {
        public UpdatedSeries[] Data { get; set; }
        public long ToEpochTime { get; set; }
        public long FromEpochTime { get; set; }

        public DateTime FromDateTime => FromEpochTime.FromUnixTime();
        public DateTime ToDateTime => ToEpochTime.FromUnixTime();
    }
}
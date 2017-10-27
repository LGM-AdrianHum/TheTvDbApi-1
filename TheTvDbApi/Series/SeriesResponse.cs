using TheTvDbApi.Series.DataTypes;

namespace TheTvDbApi.Series {
    internal class SeriesResponse {
        public SerieInfo Data { get; set; }
        public SerieError SerieError { get; set; }
    }
}
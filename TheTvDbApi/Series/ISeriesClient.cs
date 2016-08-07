using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;

namespace TheTvDbApi.Series {
    public interface ISeriesClient {
        SerieInfo Get( int id );
        IEnumerable<ImageInfo> GetImages( int id, ImageTypes type);
    }
}
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;
using System.Threading.Tasks;
using TheTvDbApi.Series.DataTypes;

namespace TheTvDbApi.Series {
    public interface ISeriesClient {
        SerieInfo Get( int id );
        IEnumerable<ImageInfo> GetImages( int id, ImageTypes type);
        IEnumerable<SeasonInfo> GetSeasonsAndEpisodes(int id);
    }
}
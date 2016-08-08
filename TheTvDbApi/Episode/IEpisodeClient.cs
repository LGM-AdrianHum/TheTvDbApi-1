using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;
using TheTvDbApi.Episode.DataTypes;
using TheTvDbApi.Series.DataTypes;

namespace TheTvDbApi.Episode {
    public interface IEpisodeClient {
        EpisodeFullInfo Get( int id );
    }
}
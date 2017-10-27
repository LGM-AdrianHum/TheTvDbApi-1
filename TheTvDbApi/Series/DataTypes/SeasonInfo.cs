using System.Collections.Generic;

namespace TheTvDbApi.Series.DataTypes {
    public class SeasonInfo {
        public int AiredNumber { get; set; }
        public int DvdNumber { get; set; }
        public List<EpisodeInfo> EpisodeList { get; set; }

        public SeasonInfo() {
            EpisodeList = new List<EpisodeInfo>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTvDbApi.Series.DataTypes {
    class EpisodeResponse {
        public Links Links { get; set; }
        public List<EpisodeInfo> data { get; set; }
    }

    class Links {
        public int First { get; set; }
        public int Last { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }
    }
}

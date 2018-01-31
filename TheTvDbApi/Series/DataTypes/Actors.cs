using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTvDbApi.Series.DataTypes
{
    internal class ActorsResponse
    {
        public List<Actors> Data { get; set; }
    }

    [Serializable]
    public class Actors
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int SortOrder { get; set; }
        public string Image { get; set; }
        public int ImageAuthor { get; set; }
        public string ImageAdded { get; set; }
        public string LastUpdated { get; set; }
    }

}

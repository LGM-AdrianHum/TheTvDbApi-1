using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTvDbApi.Episode.DataTypes {
    public class EpisodeFullInfo {
        public int Id { get; set; }
        public int AiredSeason { get; set; }
        public int AiredEpisodeNumber { get; set; }
        public string EpisodeName { get; set; }
        public string FirstAired { get; set; }
        public List<string> GuestStars { get; set; }
        public string Director { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Writers { get; set; }
        public string Overview { get; set; }
        public string ProductionCode { get; set; }
        public string ShowUrl { get; set; }
        public long LastUpdated { get; set; }
        public string DvdDiscid { get; set; }
        public int DvdSeason { get; set; }
        public int DvdEpisodeNumber { get; set; }
        public int DvdChapter { get; set; }
        public int AbsoluteNumber { get; set; }
        public string Filename { get; set; }
        public string SeriesId { get; set; }
        public string LastUpdatedBy { get; set; }
        public int AirsAfterSeason { get; set; }
        public int AirsBeforeSeason { get; set; }
        public int AirsBeforeEpisode { get; set; }
        public int ThumbAuthor { get; set; }
        public string ThumbAdded { get; set; }
        public string ThumbWidth { get; set; }
        public string ThumbHeight { get; set; }
        public string ImdbId { get; set; }
        public decimal SiteRating { get; set; }
        public int SiteRatingCount { get; set; }

        public EpisodeFullInfo() {
            
        }
    }
}

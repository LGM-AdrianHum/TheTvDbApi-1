namespace TheTvDbApi.Series.DataTypes {
    public class ImageInfo {
        public int Id { get; set; }
        public string KeyType { get; set; }
        public string SubKey { get; set; }
        public string FileName { get; set; }
        public string Resolution { get; set; }
        public Ratingsinfo RatingsInfo { get; set; }
        public string Thumbnail { get; set; }
    }
}
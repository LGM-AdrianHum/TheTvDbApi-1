namespace TheTvDbApi.Series.DataTypes {
    public class SerieError {
        public string[] InvalidFilters { get; set; }
        public string InvalidLanguage { get; set; }
        public string[] InvalidQueryParams { get; set; }
    }
}
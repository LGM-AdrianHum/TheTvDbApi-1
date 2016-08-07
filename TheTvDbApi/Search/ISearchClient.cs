using System.Collections.Generic;

namespace TheTvDbApi.Search {
    public interface ISearchClient {
        IEnumerable<SearchResult> Search( string name );
    }
}
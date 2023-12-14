namespace GrpcServer_PI_21_01.Models
{
    // возможные улучшения:
    // - сделать проверку последних пуллов не только на страницы, но и на фильтры
    // - расширить функционал интерфейса IRepository, чтобы упростить методы в DataService и убрать постоянные повторения
    public class DataCacheProxy<T> : IRepository<T>
    {
        public DataCacheProxy(IRepository<T> repository, int cacheDurationMs)
        {
            InitialRepository = repository;
            CacheDurationMs = cacheDurationMs;
        }

        public IRepository<T> InitialRepository { get; }
        public int CacheDurationMs { get; }

        public List<T> GetAll(DataRequest request)
        {
            if (requests.ContainsKey(request.Page))
            {
                var pastRequest = requests[request.Page];
                var newFilter = new Filter<T>(request.Filter);
                if (pastRequest.IsValid(CacheDurationMs, newFilter))
                    return pastRequest.RequestedItems;

                requests.Remove(request.Page);
            }

            var results = InitialRepository.GetAll(request);
            var memo = new RequestMemo(request, results);
            requests.Add(request.Page, memo);

            return results;
        }

        public void Reset()
        {
            requests.Clear();
        }

        readonly Dictionary<int, RequestMemo> requests = new();

        private class RequestMemo
        {
            public RequestMemo(DataRequest request, List<T> results)
            {
                RequestedItems = results;
                UsedFilter = new Filter<T>(request.Filter);
                Page = request.Page;
                LastPullTime = DateTime.Now;
            }

            public DateTime LastPullTime { get; }
            public List<T> RequestedItems { get; }
            public Filter<T> UsedFilter { get; }
            public int Page { get; set; }

            public bool IsValid(int outdateTimeMs, Filter<T> newFilter)
            {
                return !IsOutdated(outdateTimeMs) && UsedFilter.Equals(newFilter);
            }

            public bool IsOutdated(int outdateTimeMs)
            {
                return LastPullTime.AddMilliseconds(outdateTimeMs) < DateTime.Now;
            }
        }
    }
}

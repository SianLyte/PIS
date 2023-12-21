namespace GrpcServer_PI_21_01.Models
{
    public class ObserverArguments<T>
    {
        public ActionType ActionType { get; set; }
        public DataCacheProxy<T> CacheProxy { get; set; }
        public string TableName { get; set; }
        public UserReply User { get; set; }
        public int ModifiedObjectId { get; set; }
    }
}

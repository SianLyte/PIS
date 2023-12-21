namespace GrpcServer_PI_21_01.Models
{
    public interface IRepository<T>
    {
        const int CacheDurationMs = 60000;
        List<T> GetAll(DataRequest request);
    }
}

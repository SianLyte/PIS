namespace GrpcServer_PI_21_01.Models
{
    public interface IRepository<T>
    {
        List<T> GetAll(DataRequest request);
    }
}

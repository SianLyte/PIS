using Npgsql;
using GrpcServer_PI_21_01.Services;
using GrpcServer_PI_21_01.Data;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("city_contract")]
    public class Location_Contract
    {
        public int Id { get; set; }
        [Filterable("city_id")]
        public Location Locality { get; set; }
        [Filterable("cost")]
        public decimal Price { get; set; }
        [Filterable("contract_id")]
        public Contract Contract { get; set; }
        public Location_Contract(int id, Location locality, decimal price, Contract contract)
        {
            Id = id;
            Locality = locality;
            Price = price;
            Contract = contract;
        }

        public static Location_Contract GetAnimalCost(int localityId, int ContractId, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM city_contract WHERE contract_id = {ContractId} AND city_id = {localityId}") { Connection = cn };
            string[] arr = { "0", "0", "0", "0"};
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                arr[0] = reader[0].ToString(); //id
                arr[1] = reader[1].ToString(); //cost
                arr[2] = reader[2].ToString(); //contract id
                arr[3] = reader[3].ToString(); //city id
            }
            reader.Close();
            cn.Close();
            return new Location_Contract(
                int.Parse(arr[0]),
                LocationRepository.GetLocation(int.Parse(arr[3])),
                decimal.Parse(arr[1]),
                ContractRepository.GetContract(int.Parse(arr[2])));
        }

        public LocationContractReply ToReply()
        {
            return new LocationContractReply()
            {
                Id = Id,
                Location = Locality.ToReply(),
                Contract = Contract.ToReply(),
                Price = (double)Price,
            };
        }
    }
}

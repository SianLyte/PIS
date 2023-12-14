using GrpcServer_PI_21_01.Models;
using Npgsql;

namespace GrpcServer_PI_21_01.Data
{
    public class OperationRepository : IRepository<Operation>
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);
        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Operation>(req.Filter).GenerateSQLForCount();
                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {

                    cn.Open();
                    string count = "";
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count = reader[0].ToString();
                    }
                    reader.Close();
                    cn.Close();
                    var a = Math.Ceiling((decimal)int.Parse(count) / req.Page);
                    return (int)a;
                };
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static List<Operation> GetOperations(DataRequest r)
        {
            try
            {
                var query = new Filter<Operation>(r.Filter).GenerateSQL(r.Page);
                List<Operation> operations = new();
                List<string?[]> operationsEmpty = new();

                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        operationsEmpty.Add(new string?[6] {
                    reader[0].ToString(), //id
                    reader[1].ToString(), //type
                    reader[2].ToString(), //objectid
                    reader[3].ToString(), //tablename
                    reader[4].ToString(), //userid
                    reader[5].ToString() //date
                    });
                    }
                    reader.Close();
                    cn.Close();
                    for (int i = 0; i < operationsEmpty.Count; i++)
                    {
                        var operationEmpty = operationsEmpty[i];
                        Operation operation = new Operation(int.Parse(operationEmpty[0]),
                            Enum.Parse<ActionType>(operationEmpty[1]),
                            operationEmpty[2],
                            operationEmpty[3],
                            User.GetById(int.Parse(operationEmpty[4]), cn),
                            DateTime.Parse(operationEmpty[5]));
                        operations.Add(operation);
                    }

                };
                return operations;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static bool AddOperation(OperationReply op)
        {
            try
            {
                var cmdString = $"INSERT INTO operation " +
    $"(actiontype, modifiedobjectid, modifiedtablename, userid, date) " +
    $"VALUES ('{op.Action}', {op.ModifiedObjectId}, '{op.ModifiedTableName}', {op.User.UserId}, '{op.Date}') RETURNING operationid";
                using NpgsqlCommand cmd = new(cmdString) { Connection = cn };
                cn.Open();
                var returnedVal = cmd.ExecuteScalar();
                if (returnedVal is not int id)
                    return false;
                op.OperationId = id;
                cn.Close();
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static Operation GetOperation(int id)
        {

            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM operation WHERE id = {id}") { Connection = cn };
                cmd.Connection = cn;
                cn.Open();
                var reader = cmd.ExecuteReader();
                string?[] arr = { "0", "0", "0", "0", "0" };
                while (reader.Read())
                {
                    arr[0] = (reader[1].ToString()); //actiontype
                    arr[1] = reader[2].ToString(); //modifiedobject
                    arr[2] = reader[3].ToString(); //modifiedtable
                    arr[3] = reader[4].ToString(); //userid
                    arr[4] = reader[5].ToString(); //date
                }
                reader.Close();
                cn.Close();
                return new Operation(id, Enum.Parse<ActionType>(arr[0]), arr[1], arr[2], User.GetById(int.Parse(arr[3]), cn), DateTime.Parse(arr[4]));
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Operation> GetAll(DataRequest request)
        {
            return GetOperations(request);
        }
    }
}

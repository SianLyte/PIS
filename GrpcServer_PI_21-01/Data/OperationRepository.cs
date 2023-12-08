using GrpcServer_PI_21_01.Models;
using Npgsql;

namespace GrpcServer_PI_21_01.Data
{
    public class OperationRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);
        public static int GetMaxPage(DataRequest req)
        {
            var query = new Filter<Operation>(req.Filter).GenerateSQLForCount();
            using (NpgsqlCommand cmd = new("SELECT count(*) from operation") { Connection = cn })
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

        public static List<Operation> GetOperations(DataRequest r)
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

        public static bool AddOperation(OperationReply op)
        {
            string action = "";
            if (op.Action == ActionType.ActionAdd)
            {
                action = "ACTION_ADD";
            }
            if (op.Action == ActionType.ActionUpdate)
            {
                action = "ACTION_UPDATE";
            }
            if (op.Action == ActionType.ActionDelete)
            {
                action = "ACTION_DELETE";
            }


            var cmdString = $"INSERT INTO operation " +
                $"(actiontype, modifiedobjectid, modifiedtablename, userid, date) " +
                $"VALUES ('{action}', {op.ModifiedObjectId}, '{op.ModifiedTableName}', {op.User.UserId}, '{op.Date}') RETURNING operationid";
            using NpgsqlCommand cmd = new(cmdString) { Connection = cn };
            try
            {
                cn.Open();
                var returnedVal = cmd.ExecuteScalar();
                if (returnedVal is not int id)
                    return false;
                op.OperationId = id;
                
                cn.Close();
                return true;
            }
            catch { return false; }
        }
    }
}

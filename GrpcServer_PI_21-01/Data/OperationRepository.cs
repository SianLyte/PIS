using Npgsql;

namespace GrpcServer_PI_21_01.Data
{
    public class OperationRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static List<OperationReply> GetOperations()
        {
            List<OperationReply> ops = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM operation") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OperationReply op = new();
                    op.Action = (ActionType)Enum.Parse(typeof(ActionType), reader["ActionType"].ToString());
                    op.ModifiedObjectId = Convert.ToInt32(reader["ModifiedObjectId"].ToString());
                    op.ModifiedTableName = reader["ModifiedTableName"].ToString();
                    op.User = UserRepository.GetUserById(int.Parse(reader["UserId"].ToString())).ToReply();

                    ops.Add(op);
                }
                reader.Close();
                cn.Close();
            };
            return ops;
        }

        public static bool AddOperation(OperationReply op)
        {
            var cmdString = $"INSERT INTO operation " +
                $"(operation.Action, operation.ModifiedObjectId, operation.ModifiedTableName) " +
                $"VALUES ({op.Action}, {op.ModifiedObjectId}, {op.ModifiedTableName}) RETURNING operationId";
            using NpgsqlCommand cmd = new(cmdString) { Connection = cn };
            try
            {
                cn.Open();
                var id = cmd.ExecuteNonQuery();
                op.OperationId = id;
                return true;
                cn.Close();
            }
            catch { return false; }
        }
    }
}

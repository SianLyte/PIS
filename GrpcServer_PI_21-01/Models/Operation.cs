//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GrpcServer_PI_21_01.Models
//{
//    public class Operation
//    {
//        public int IdOperation { get; set; }
//        public string actionType { get; set; }
//        public string modifiedObjectId { get; set; }
//        public string modifiedTableName { get; set; }
//        public User A { get; set; }

//        public Operation(int IdOperation, string actionType, string modifiedObjectId, string modifiedTableName, User user)
//        {
//            this.IdOperation = IdOperation;
//            this.actionType = actionType;
//            this.modifiedObjectId = modifiedObjectId;
//            this.modifiedTableName = modifiedTableName;
//            this.user = user;
//        }

//        public static Operation GetById(int id, NpgsqlConnection cn)
//        {

//            NpgsqlCommand cmd = new($"SELECT * FROM operation WHERE id = {id}") { Connection = cn };
//            string[] arr = { "0", "0", "0", "0"};

//            var reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {
//                arr[0] = reader[1].ToString(); //actiontype
//                arr[1] = reader[2].ToString(); //modifiedobjectid
//                arr[2] = reader[3].ToString(); //modifiedtablename
//                arr[3] = reader[4].ToString(); //userid
//            }
//            reader.Close();
//            return new Operation(id, arr[0], arr[1], arr[2], arr[3]);
//        }
//    }
//}

using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("operation")]
    public class Operation
    {
        public int IdOperation { get; set; }
        [Filterable("actiontype")]
        public ActionType ActionType { get; set; }
        [Filterable("modifiedobjectid")]
        public string ModifiedObjectId { get; set; }
        [Filterable("modifiedtablename")]
        public string ModifiedTableName { get; set; }
        [Filterable("user_id")]
        public User Actor { get; set; }
        [Filterable("date")]
        public DateTime ActionDate { get; set; }

        public Operation(int IdOperation, ActionType actionType, string modifiedObjectId,
            string modifiedTableName, User user, DateTime date)
        {
            this.IdOperation = IdOperation;
            this.ActionType = actionType;
            this.ModifiedObjectId = modifiedObjectId;
            this.ModifiedTableName = modifiedTableName;
            this.Actor = user;
            this.ActionDate = date;
        }

        //public static Operation GetById(int id, NpgsqlConnection cn)
        //{
            
        //    NpgsqlCommand cmd = new($"SELECT * FROM operation WHERE id = {id}") { Connection = cn };
        //    cmd.Connection = cn;
        //    cn.Open();
        //    var reader = cmd.ExecuteReader();
        //    string?[] arr = { "0", "0", "0", "0", "0" };
        //    while (reader.Read())
        //    {
        //        arr[0] = (reader[1].ToString()); //actiontype
        //        arr[1] = reader[2].ToString(); //modifiedobject
        //        arr[2] = reader[3].ToString(); //modifiedtable
        //        arr[3] = reader[4].ToString(); //userid
        //        arr[4] = reader[5].ToString(); //date
        //    }
        //    reader.Close();
        //    cn.Close();
        //    return new Operation(id, Enum.Parse<ActionType>(arr[0]), arr[1], arr[2], User.GetById(int.Parse(arr[3]), cn), DateTime.Parse(arr[4]));
        //}
    }
}

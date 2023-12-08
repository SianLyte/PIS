namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class Operation
    {
        public int IdOperation { get; set; }
        [Filterable("actiontype")]
        public ActionType ActionType { get; set; }
        [Filterable("modifiedobjectid")]
        public int ModifiedObjectId { get; set; }
        [Filterable("modifiedtablename")]
        public string ModifiedTableName { get; set; }
        [Filterable("user_id")]
        public User Actor { get; set; }
        [Filterable("date")]
        public DateTime ActionDate { get; set; }

        public Operation(int IdOperation, ActionType actionType, int modifiedObjectId,
            string modifiedTableName, User user, DateTime date)
        {
            this.IdOperation = IdOperation;
            this.ActionType = actionType;
            this.ModifiedObjectId = modifiedObjectId;
            this.ModifiedTableName = modifiedTableName;
            this.Actor = user;
            this.ActionDate = date;
        }
    }
}

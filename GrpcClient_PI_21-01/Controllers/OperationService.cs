using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace GrpcClient_PI_21_01.Controllers
{
    public class OperationService
    {
        public static async Task<List<Operation>> GetOperations(int page = -1, Filter<Operation>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetOperations(UserService.GenerateDataRequest(page, filter));
            var responseStream = serverData.ResponseStream;
            var ops = new List<Operation>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                ops.Add(response.FromReply());
            }
            return ops;
        }

        public static async Task<int> GetPageCount(int pageSize, Filter<Operation>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetOperationsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static async Task<bool> RemoveOperation(int operationId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var request = new IdRequest()
            {
                Actor = UserService.CurrentUser?.ToReply(),
                Id = operationId,
            };
            var operationResult = await client.RemoveOperationAsync(request);
            return operationResult.Successful;
        }

        public static string[] ToDataArray(Operation operation)
        {
            return new string[11] { operation.Actor.Surname.ToString(),
                                    operation.Actor.Name.ToString(),
                                    operation.Actor.Patronymic.ToString(),
                                    operation.Actor.Organization.name.ToString(),
                                    operation.Actor.PrivelegeLevel.ToString(),
                                    operation.Actor.Login.ToString(),
                                    operation.ActionDate.ToString(),
                                    operation.ModifiedObjectId.ToString(),
                                    operation.ActionType.ToString(),
                                    operation.ModifiedTableName.ToString(),
                                    operation.IdOperation.ToString()};
        }

        public static void FillDataGrid(List<Operation> operations, DataGridView dgv)
        {
            static Expression<Func<Operation, object>> exp(Expression<Func<Operation, object>> exp) => exp;
            static Expression<Func<User, object>> expActor(Expression<Func<User, object>> exp) => exp;
            static Expression<Func<Organization, object>> expOrg(Expression<Func<Organization, object>> exp) => exp;

            SortOrder memorizedSort = SortOrder.None;
            DataGridViewColumn? memorizedColumn = null;

            // memorizing current glyph direction
            foreach (DataGridViewColumn c in dgv.Columns)
                if (c.HeaderCell.SortGlyphDirection != SortOrder.None)
                {
                    memorizedSort = c.HeaderCell.SortGlyphDirection;
                    memorizedColumn = c;
                    break;
                }

            // creating columns
            dgv.Columns.Clear();
            dgv.Columns.Add("Surname", "Фамилия");
            dgv.Columns.Add("Name", "Имя");
            dgv.Columns.Add("Patronymic", "Отчество");
            dgv.Columns.Add("Organization","Организация");
            dgv.Columns.Add("PrevilegeLevel", "Должность");
            dgv.Columns.Add("Login", "Логин");
            dgv.Columns.Add("ActionDate", "Дата и время");
            dgv.Columns.Add("ModifiedObjectID", "Идетификационный номер экземляра объекта");
            dgv.Columns.Add("ActionType", "Вид действия");
            dgv.Columns.Add("ModifiedTableName", "Наименование таблицы, в которой произошло изменение");
            dgv.Columns.Add("Id", "Id");

            // preparting columns
            dgv.Columns[0].Tag = expActor(a => a.Surname);
            dgv.Columns[1].Tag = expActor(a => a.Name);
            dgv.Columns[2].Tag = expActor(a => a.Patronymic);
            dgv.Columns[3].Tag = expOrg(o => o.name);
            dgv.Columns[4].Tag = expActor(a => a.PrivelegeLevel);
            dgv.Columns[5].Tag = expActor(a => a.Login);
            dgv.Columns[6].Tag = exp(a => a.ActionDate);
            dgv.Columns[7].Tag = exp(a => a.ModifiedObjectId);
            dgv.Columns[8].Tag = exp(a => a.ActionType);
            dgv.Columns[9].Tag = exp(a => a.ModifiedTableName);
            dgv.Columns[10].Tag = exp(a => a.IdOperation);

            foreach (DataGridViewColumn c in dgv.Columns)
                c.SortMode = DataGridViewColumnSortMode.Programmatic;

            // filling in data
            operations.ForEach(a => dgv.Rows.Add(ToDataArray(a)));

            // setting the glyph direction
            if (memorizedColumn != null)
                dgv.Columns[memorizedColumn.Index].HeaderCell.SortGlyphDirection = memorizedSort;
        }
    }
}

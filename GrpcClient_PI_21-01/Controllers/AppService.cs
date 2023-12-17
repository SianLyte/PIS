//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;
using Grpc.Core;
using System.Linq.Expressions;

namespace GrpcClient_PI_21_01.Controllers
{
    internal static class AppService
    {
        public static App GetApplicationFromReply(ApplicationReply reply)
        {
            return new App(
                reply.Date.ToDateTime(),
                reply.Number,
                reply.Locality.FromReply(),
                reply.Territory,
                reply.AnimalHabitat,
                reply.UrgencyOfExecution,
                reply.AnimalDescription,
                reply.ApplicantCategory,
                reply.Status,
                reply.Organization.FromReply(),
                reply.AnimalCount);
        }

        public static string[] ToDataArray(App app)
        {
            return new string[]
            {
                    app.date.ToString(),
                    app.number.ToString(),
                    app.locality.City,
                    app.territory,
                    app.animalHabiat,
                    app.urgencyOfExecution,
                    app.animaldescription,
                    app.applicantCategory,
                    app.status.ToString()
            };
        }

        public static void FillDataGrid(List<App> apps, DataGridView dgv)
        {
            static Expression<Func<App, object>> exp(Expression<Func<App, object>> exp) => exp;
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

            // clearing data grid
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // creating columns
            dgv.Columns.Add("ApplicationDate", "Дата подачи");
            dgv.Columns.Add("ID", "Номер");
            dgv.Columns.Add("Locality", "Населенный пункт");
            dgv.Columns.Add("Territory", "Территория");
            dgv.Columns.Add("Area", "Место обитания");
            dgv.Columns.Add("Urgency", "Срочность исполнения");
            dgv.Columns.Add("Description", "Описание животного");
            dgv.Columns.Add("ApplicantCategory", "Категория заявителя");

            // preparing columns
            dgv.Columns["ApplicationDate"].Tag = exp(a => a.date);
            dgv.Columns["ID"].Tag = exp(a => a.number);
            dgv.Columns["Locality"].Tag = exp(a => a.locality);
            dgv.Columns["Territory"].Tag = exp(a => a.territory);
            dgv.Columns["Area"].Tag = exp(a => a.animalHabiat);
            dgv.Columns["Urgency"].Tag = exp(a => a.urgencyOfExecution);
            dgv.Columns["Description"].Tag = exp(a => a.animaldescription);
            dgv.Columns["ApplicantCategory"].Tag = exp(a => a.applicantCategory);
            foreach (DataGridViewColumn c in dgv.Columns)
                c.SortMode = DataGridViewColumnSortMode.Programmatic;

            // filling in data
            apps.ForEach(a => dgv.Rows.Add(ToDataArray(a)));
            
            // setting the glyph direction
            if (memorizedColumn != null)
                dgv.Columns[memorizedColumn.Index].HeaderCell.SortGlyphDirection = memorizedSort;
        }

        public static async Task<List<App>> GetApplications(int page = -1, Filter<App>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetApps(UserService.GenerateDataRequest(page, filter));
            var responseStream = serverData.ResponseStream;
            var apps = new List<App>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                apps.Add(GetApplicationFromReply(response));
            }
            return apps;
        }

        public static async Task<int> GetPageCount(int pageSize, Filter<App>? filter)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetAppsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static async Task<App> GetApplication(int appId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var app = await client.GetAppAsync(new IdRequest()
            {
                Id = appId,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return app.FromReply();
        }

        public static async Task<bool> RemoveApplication(int appId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.RemoveAppAsync(new IdRequest()
            {
                Id = appId,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return response.Successful;
        }

        public static async Task<bool> UpdateApplication(App app)
        {
            var reply = app.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.UpdateAppAsync(reply);
            return response.Successful;
        }

        public static async Task<bool> AddApplication(App app)
        {
            app.number = -1;
            var reply = app.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddAppAsync(reply);
            app.number = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static string[] GetApplicantTypes()
        {
            return new string[]
            {
                "Физ. лицо",
                "Юр. лицо",
                "Гос. лицо",
            };
        }
    }
}

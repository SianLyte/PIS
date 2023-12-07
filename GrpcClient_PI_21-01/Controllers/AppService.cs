//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;
using Grpc.Core;

namespace GrpcClient_PI_21_01.Controllers
{
    internal class AppService
    {
        //public static void AddApplication(App App)
        //{
        //    AppRepository.SaveAdd(App);
        //}

        //public static void EditApplication(App app)
        //{
        //    AppRepository.Save(app);
        //}

        //public static List<string[]> FilterByDate(string filter, string filter2)
        //{
        //    return AppRepository.FilterByDate(filter, filter2);
        //}

        //public static void DeleteApplication(int app)
        //{
        //    foreach (App applic in AppRepository.Applicatiions)
        //    {
        //        if (Convert.ToInt32(applic.number) == app)
        //        {
        //            AppRepository.Del(applic);
        //            break; 
        //        }
        //    }
        //}

        //public static List<string[]> ShowApplication()
        //{
        //    List<string[]> apps = new List<string[]>();
        //    foreach (App app in AppRepository.Applicatiions)
        //    {
        //        var tempApp = new List<string>
        //        {
        //            app.date.ToString(),
        //            app.number.ToString(),
        //            app.locality,
        //            app.territory,
        //            app.animalHabiat,
        //            app.urgencyOfExecution,
        //            app.animaldescription,
        //            app.applicantCategory
        //        };
        //        apps.Add(tempApp.ToArray());
        //    }
        //    return apps;
        //}

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
                reply.Status);
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
                    app.applicantCategory
            };
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

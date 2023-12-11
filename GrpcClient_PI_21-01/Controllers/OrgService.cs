//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Core;
using Grpc.Net.Client;
using System.Linq.Expressions;

namespace GrpcClient_PI_21_01.Controllers
{
    internal static class OrgService
    {
        //public static List<string[]> ShowOrganizations()
        //{
        //    List<string[]> orgs = new List<string[]>();
        //    foreach (Organization org in OrgRepository.Organizations)
        //    {
        //        var tempOrg = new List<string>
        //        {
        //            org.idOrg.ToString(),
        //            org.name,
        //            org.INN,
        //            org.KPP,
        //            org.registrationAdress,
        //            org.type,
        //            org.status
        //        };
        //        orgs.Add(tempOrg.ToArray());
        //    }
        //    return orgs;
        //}

        //public static void AddOrganization(Organization Org)
        //{
        //    OrgRepository.SaveAdd(Org);
        //}

        //public static void EditOrganization(Organization Org)
        //{
        //    OrgRepository.Save(Org);
        //}

        //public static void DeleteOrganization(string org)
        //{
        //    foreach (Organization organization in OrgRepository.Organizations)
        //    {
        //        if (organization.INN == Convert.ToString(org))
        //        {
        //            OrgRepository.Del(organization);
        //            break;
        //        }

        //    }
        //}

        public static Organization GetOrganizationFromReply(OrganizationReply reply)
        {
            return new Organization(reply.IdOrganization,
                reply.Name,
                reply.INN,
                reply.KPP,
                reply.RegistrationAddress.FromReply(),
                reply.Type,
                reply.Status);
        }

        public static string[] ToDataArray(Organization org)
        {
            return new string[] {
                    org.idOrg.ToString(),
                    org.name,
                    org.INN,
                    org.KPP,
                    org.registrationAdress.City,
                    org.type.Translate(),
                    org.status
            };
        }

        public static void FillDataGrid(List<Organization> orgs, DataGridView dgv)
        {
            static Expression<Func<Organization, object>> exp(Expression<Func<Organization, object>> exp) => exp;
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

            // clearing datagrid
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // creating columns
            dgv.Columns.Add("ID", "Номер");
            dgv.Columns.Add("Name", "Наименование");
            dgv.Columns.Add("INN", "ИНН");
            dgv.Columns.Add("KPP", "КПП");
            dgv.Columns.Add("RegAddress", "Адрес регистрации");
            dgv.Columns.Add("Type", "Тип");
            dgv.Columns.Add("Status", "Статус");

            // preparing columns
            dgv.Columns["ID"].Tag = exp(o => o.idOrg);
            dgv.Columns["Name"].Tag = exp(o => o.name);
            dgv.Columns["INN"].Tag = exp(o => o.INN);
            dgv.Columns["KPP"].Tag = exp(o => o.KPP);
            dgv.Columns["RegAddress"].Tag = exp(o => o.registrationAdress);
            dgv.Columns["Type"].Tag = exp(o => o.type);
            dgv.Columns["Status"].Tag = exp(o => o.status);
            foreach (DataGridViewColumn c in dgv.Columns)
                c.SortMode = DataGridViewColumnSortMode.Programmatic;

            // filling in data
            orgs.ForEach(o => dgv.Rows.Add(ToDataArray(o)));

            // setting the glyph direction
            if (memorizedColumn != null)
                dgv.Columns[memorizedColumn.Index].HeaderCell.SortGlyphDirection = memorizedSort;
        }

        public static async Task<List<Organization>> GetOrganizations(int page = -1, Filter<Organization>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetOrganizations(UserService.GenerateDataRequest(page, filter));
            var responseStream = serverData.ResponseStream;
            var orgs = new List<Organization>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                orgs.Add(GetOrganizationFromReply(response));
            }
            return orgs;
        }

        public static async Task<int> GetPageCount(int pageSize, Filter<Organization>? filter)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetOrganizationsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static async Task<Organization> GetOrganization(int orgId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var org = await client.GetOrganizationAsync(new IdRequest()
            {
                Id = orgId,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return org.FromReply();
        }

        public static async Task<bool> RemoveOrganization(int orgId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.RemoveOrganizationAsync(new IdRequest()
            {
                Id = orgId,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return response.Successful;
        }

        public static async Task<bool> AddOrganization(Organization org)
        {
            org.idOrg = -1;
            var reply = org.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddOrganizationAsync(reply);
            org.idOrg = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> UpdateOrganization(Organization org)
        {
            var reply = org.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.UpdateOrganizationAsync(reply);
            return response.Successful;
        }
    }
}

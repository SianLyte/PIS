using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Models;

namespace GrpcServer_PI_21_01.Services
{
    public class DataService : DataRetriever.DataRetrieverBase
    {
        const int CacheDurationMs = 60000;
        private readonly ILogger<DataService> _logger;
        public DataService(ILogger<DataService> logger)
        {
            _logger = logger;
        }

        private static Task<OperationResult> CRUD(int modifiedId, bool successful)
        {
            var result = new OperationResult()
            {
                ModifiedId = modifiedId,
                Successful = successful,
            };
            return Task.FromResult(result);
        }
        //private static Task<OperationResult> CRUD(int modifiedId, string error)
        //{
        //    var result = new OperationResult()
        //    {
        //        ModifiedId = modifiedId,
        //        Successful = successful,
        //    };
        //    return Task.FromResult(result);
        //}

        public void Log(ActionType actType, string tableName, int modifId, UserReply actor)
        {
            var operation = new OperationReply()
            {
                Action = actType,
                ModifiedObjectId = modifId,
                ModifiedTableName = tableName,
                OperationId = -1,
                User = actor,
                Date = DateTime.Now.ToUtc().ToTimestamp(),
            };
            var logged = OperationRepository.AddOperation(operation);
            if (!logged)
            {
                _logger.LogError("Error has occured during operation log. Please debug this log:" +
                    "\n{Username} has made changes to {tableName} table at index {modifId}." +
                    " Action type: {actType}.",
                    string.Join(" ", actor.Surname, actor.Name, actor.Patronymic), tableName, modifId, actType);
            }
            else operationProxy.Reset();
        }

        #region Contracts
        private readonly DataCacheProxy<Contract> contractCacheProxy = new(new ContractRepository(), CacheDurationMs);
        public override Task<ContractReply> GetContract(IdRequest request, ServerCallContext context)
        {
            Contract? contr = ContractRepository.GetContract(request.Id);

            if (contr is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Contract with ID {request.Id} does not exist"));

            return Task.FromResult(contr.ToReply());
        }

        public override Task<ContractsReply> GetContracts(DataRequest request, ServerCallContext context)
        {
            var filter = new Filter<Contract>();
            if (request.Actor.PrivelegeLevel != "Admin")
            {
                filter.AddOrFilter(c => c.Costumer, request.Actor.Organization.IdOrganization.ToString());
                filter.AddOrFilter(c => c.Executer, request.Actor.Organization.IdOrganization.ToString());
            }
            filter.ExtendReply(request.Filter);
            var contracts = contractCacheProxy.GetAll(request).Select(c => c.ToReply());

            var reply = new ContractsReply();
            reply.Contracts.AddRange(contracts);
            return Task.FromResult(reply);
        }

        public override Task<PageCount> GetContractsPageCount(DataRequest req, ServerCallContext ctx)
            => Task.FromResult(new PageCount() { Count = ContractRepository.GetMaxPage(req) });

        public override Task<OperationResult> AddContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.AddContract(contract);
            if (successful)
            {
                contractCacheProxy.Reset();
                Log(ActionType.ActionAdd, "Contract", contract.IdContract, request.Actor);
            }
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> UpdateContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.UpdateContract(contract);
            if (successful)
            {
                contractCacheProxy.Reset();
                Log(ActionType.ActionUpdate, "Contract", contract.IdContract, request.Actor);
            }
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> RemoveContract(IdRequest id, ServerCallContext ctx)
        {
            var successful = ContractRepository.DeleteContract(id.Id);
            if (successful)
            {
                contractCacheProxy.Reset();
                Log(ActionType.ActionDelete, "Contract", id.Id, id.Actor);
            }
            return CRUD(id.Id, successful);
        }
        #endregion
        #region Locations
        private readonly DataCacheProxy<Location> locationCacheProxy = new(new LocationRepository(), CacheDurationMs);
        public override Task<LocationReply> GetLocation(IdRequest request, ServerCallContext context)
        {
            Location? loc = LocationRepository.GetLocation(request.Id);

            if (loc is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(loc.ToReply());
        }

        public override async Task GetLocations(DataRequest r,
            IServerStreamWriter<LocationReply> responseStream,
            ServerCallContext context)
        {
            foreach (var loc in locationCacheProxy.GetAll(r))
            {
                await responseStream.WriteAsync(loc.ToReply());
            }
        }

        public override Task<PageCount> GetLocationsPageCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = LocationRepository.GetMaxPage(request) });

        public override Task<OperationResult> AddLocation(LocationReply request, ServerCallContext ctx)
        {
            var location = request.FromReply();
            var successful = LocationRepository.AddLocation(location);
            if (successful)
            {
                locationCacheProxy.Reset();
                Log(ActionType.ActionAdd, "Location", location.IdLocation, request.Actor);
            }
            return CRUD(location.IdLocation, successful);
        }

        public override Task<OperationResult> RemoveLocation(IdRequest request, ServerCallContext ctx)
        {
            var successful = LocationRepository.RemoveLocation(request.Id);
            if (successful)
            {
                locationCacheProxy.Reset();
                Log(ActionType.ActionDelete, "Location", request.Id, request.Actor);
            }
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateLocation(LocationReply request, ServerCallContext ctx)
        {
            var location = request.FromReply();
            var successful = LocationRepository.UpdateLocation(location);
            if (successful)
            {
                locationCacheProxy.Reset();
                Log(ActionType.ActionUpdate, "Location", location.IdLocation, request.Actor);
            }
            return CRUD(location.IdLocation, successful);
        }
        #endregion
        #region Organizations
        private readonly DataCacheProxy<Organization> orgCacheProxy = new(new OrgRepository(), CacheDurationMs);
        public override Task<OrganizationReply> GetOrganization(IdRequest request, ServerCallContext context)
        {
            Organization? org = OrgRepository.GetOrganization(request.Id);

            if (org is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(org.ToReply());
        }

        public override async Task GetOrganizations(DataRequest request,
            IServerStreamWriter<OrganizationReply> responseStream,
            ServerCallContext context)
        {
            foreach (var org in orgCacheProxy.GetAll(request))
                await responseStream.WriteAsync(org.ToReply());
        }

        public override Task<PageCount> GetOrganizationsPageCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = OrgRepository.GetMaxPage(request) });

        public override Task<OperationResult> AddOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.AddOrganization(org);
            if (successful)
            {
                orgCacheProxy.Reset();
                Log(ActionType.ActionAdd, "Organization", org.idOrg, reply.Actor);
            }
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> UpdateOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.UpdateOrganization(org);
            if (successful)
            {
                orgCacheProxy.Reset();
                Log(ActionType.ActionUpdate, "Organization", org.idOrg, reply.Actor);
            }
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> RemoveOrganization(IdRequest id, ServerCallContext ctx)
        {
            var successful = OrgRepository.RemoveOrganization(id.Id);
            if (successful)
            {
                orgCacheProxy.Reset();
                Log(ActionType.ActionDelete, "Organization", id.Id, id.Actor);
            }
            return CRUD(id.Id, successful);
        }
        #endregion
        #region Acts
        private readonly DataCacheProxy<Act> actCacheProxy = new(new ActRepository(), CacheDurationMs);
        public override Task<ActReply> GetAct(IdRequest request, ServerCallContext context)
        {
            Act? act = ActRepository.GetAct(request.Id);

            if (act is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(act.ToReply());
        }

        public override async Task GetActs(DataRequest request,
            IServerStreamWriter<ActReply> responseStream,
            ServerCallContext ctx)
        {
            var filter = new Filter<Act>();
            if (request.Actor.PrivelegeLevel != "Admin")
                filter.AddFilter(act => act.Organization, request.Actor.Organization.IdOrganization.ToString());
            filter.ExtendReply(request.Filter);

            foreach (var act in actCacheProxy.GetAll(request))
                await responseStream.WriteAsync(act.ToReply());
        }

        public override Task<PageCount> GetActsPageCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = ActRepository.GetMaxPage(request) });

        public override Task<OperationResult> AddAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.AddAct(act);
            if (successful)
            {
                actCacheProxy.Reset();
                Log(ActionType.ActionAdd, "Act Capture", act.ActNumber, request.Actor);
            }
            return CRUD(act.ActNumber, successful);
        }

        public override Task<OperationResult> RemoveAct(IdRequest request, ServerCallContext ctx)
        {
            var successful = ActRepository.RemoveAct(request.Id);
            if (successful)
            {
                actCacheProxy.Reset();
                Log(ActionType.ActionDelete, "Act Capture", request.Id, request.Actor);
            }
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.UpdateAct(act);
            if (successful)
            {
                actCacheProxy.Reset();
                Log(ActionType.ActionUpdate, "Act Capture", act.ActNumber, request.Actor);
            }
            return CRUD(act.ActNumber, successful);
        }
        #endregion
        #region Applications
        private readonly DataCacheProxy<App> appCacheProxy = new(new AppRepository(), CacheDurationMs);
        public override Task<ApplicationReply> GetApp(IdRequest request, ServerCallContext ctx)
        {
            App? app = AppRepository.GetApplication(request.Id);

            if (app is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(app.ToReply());
        }

        public override async Task GetApps(DataRequest request,
            IServerStreamWriter<ApplicationReply> responseStream,
            ServerCallContext ctx)
        {
            var filter = new Filter<App>(request.Filter);
            foreach (var app in appCacheProxy.GetAll(request))
                // у заявки на отлов нет организации, хотя по суди должна быть
                // пока не меняю, но потом из этого могут вырасти проблемы
                // например, сейчас не могу отфильтровать заявки для пользователя
                await responseStream.WriteAsync(app.ToReply());
        }

        public override Task<PageCount> GetAppsPageCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = AppRepository.GetMaxPage(request) });

        public override Task<OperationResult> AddApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.AddApplication(app);
            if (successful)
            {
                appCacheProxy.Reset();
                Log(ActionType.ActionAdd, "Application", app.number, reply.Actor);
            }
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> UpdateApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.UpdateApplication(app);
            if (successful)
            {
                appCacheProxy.Reset();
                Log(ActionType.ActionUpdate, "Application", app.number, reply.Actor);
            }
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> RemoveApp(IdRequest request, ServerCallContext ctx)
        {
            var successful = AppRepository.RemoveApplication(request.Id);
            if (successful)
            {
                appCacheProxy.Reset();
                Log(ActionType.ActionDelete, "Application", request.Id, request.Actor);
            }
            return CRUD(request.Id, successful);
        }
        #endregion
        #region AnimalCards
        private readonly DataCacheProxy<AnimalCard> animalCardCacheProxy = new(new AnimalRepository(), CacheDurationMs);
        public override Task<AnimalCardReply> GetAnimalCard(IdRequest request, ServerCallContext context)
        {
            AnimalCard? animalCard = AnimalRepository.GetAnimalCard(request.Id);

            if (animalCard is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(animalCard.ToReply());
        }

        public override async Task GetAnimalCards(DataRequest r,
            IServerStreamWriter<AnimalCardReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var animalCard in animalCardCacheProxy.GetAll(r))
                await responseStream.WriteAsync(animalCard.ToReply());
        }

        public override Task<PageCount> GetAnimalCardsPageCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = AnimalRepository.GetMaxPage(request) });

        public override Task<OperationResult> AddAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.AddAnimalCard(animalCard);
            if (successful)
            {
                animalCardCacheProxy.Reset();
                Log(ActionType.ActionAdd, "Animal Card", animalCard.IdAnimalCard, request.Actor);
            }
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> UpdateAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.UpdateAnimalCard(animalCard);
            if (successful)
            {
                animalCardCacheProxy.Reset();
                Log(ActionType.ActionUpdate, "Animal Card", animalCard.IdAnimalCard, request.Actor);
            }
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> RemoveAnimalCard(IdRequest request, ServerCallContext ctx)
        {
            var successful = AnimalRepository.RemoveAnimalCard(request.Id);
            if (successful)
            {
                animalCardCacheProxy.Reset();
                Log(ActionType.ActionDelete, "Animal Card", request.Id, request.Actor);
            }
            return CRUD(request.Id, successful);
        }
        #endregion
        #region Operations
        private readonly DataCacheProxy<Operation> operationProxy = new(new OperationRepository(), CacheDurationMs);
        public override async Task GetOperations(DataRequest r,
            IServerStreamWriter<OperationReply> responseStream,
            ServerCallContext ctx)
        {
            if (r.Actor.PrivelegeLevel != "Admin")
                throw new RpcException(new Status(StatusCode.PermissionDenied, "You are not permitted to watch operations."));
            foreach (var op in operationProxy.GetAll(r))
                await responseStream.WriteAsync(op.ToReply());
        }

        public override Task<PageCount> GetOperationsPageCount(DataRequest req, ServerCallContext ctx)
            => Task.FromResult(new PageCount() { Count = OperationRepository.GetMaxPage(req) });
        #endregion
        #region ActApps
        public override Task<ActAppReply> GetActApp(IdRequest request, ServerCallContext context)
        {
            ActApp r = ActRepository.GetActApp(request.Id);

            if (r is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(r.ToReply());
        }

        public override async Task GetActApps(DataRequest r,
            IServerStreamWriter<ActAppReply> responseStream,
            ServerCallContext context)
        {

            foreach (var actApp in ActRepository.GetActApps(r))
                await responseStream.WriteAsync(actApp.ToReply());
        }

        public override Task<PageCount> GetActAppsCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = ActRepository.GetActAppMaxPage(request) });

        public override Task<OperationResult> AddActApps(ActAppReply request, ServerCallContext context)
        {
            var actApp = request.FromReply();
            var successful = ActRepository.AddActApp(actApp);
            Log(ActionType.ActionAdd, "Act Application", actApp.ActAppNumber, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> RemoveActApps(IdRequest request, ServerCallContext context)
        {
            var successful = ActRepository.RemoveActAppp(request.Id);
            Log(ActionType.ActionDelete, "Act Application", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateActApps(ActAppReply request, ServerCallContext context)
        {
            var actApp = request.FromReply();
            var successful = ActRepository.UpdateActApp(actApp);
            Log(ActionType.ActionUpdate, "Act Application", actApp.ActAppNumber, request.Actor);
            return CRUD(request.Id, successful);
        }
        #endregion
        #region LocationContracts
        public override Task<LocationContractReply> GetLocationContract(IdRequest request, ServerCallContext context)
        {
            Location_Contract lc = LocationRepository.GetLocationContract(request.Id);

            if (lc is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(lc.ToReply());
        }

        public override async Task GetLocationContracts(DataRequest r,
            IServerStreamWriter<LocationContractReply> responseStream,
            ServerCallContext context)
        {
            foreach (var locationContract in LocationRepository.GetLocationContracts(r))
                await responseStream.WriteAsync(locationContract.ToReply());
        }

        public override Task<PageCount> GetLocationContractsPageCount(DataRequest request, ServerCallContext context)
            => Task.FromResult(new PageCount() { Count = LocationRepository.GetLocationContractMaxPage(request) });

        public override Task<OperationResult> AddLocationContract(LocationContractReply request, ServerCallContext context)
        {
            var lc = request.FromReply();
            var successful = LocationRepository.AddLocationContract(lc);
            Log(ActionType.ActionAdd, "Location Contract", lc.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateLocationContract(LocationContractReply request, ServerCallContext context)
        {
            var lc = request.FromReply();
            var successful = LocationRepository.UpdateLocationContract(lc);
            Log(ActionType.ActionUpdate, "Location Contract", lc.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> RemoveLocationContract(IdRequest request, ServerCallContext context)
        {
            var successful = LocationRepository.RemoveLocationContract(request.Id);
            Log(ActionType.ActionDelete, "Location Contract", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }
        #endregion
    }

    public static class DataExtensions
    {
        public static DateTime ToUtc(this DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }

        public static OperationReply ToReply(this Operation operation)
        {
            return new OperationReply
            {
                OperationId = operation.IdOperation,
                Action = operation.ActionType, 
                ModifiedObjectId = int.Parse(operation.ModifiedObjectId), 
                ModifiedTableName = operation.ModifiedTableName,
                User = operation.Actor.ToReply(),
                Date = operation.ActionDate.ToUtc().ToTimestamp(),
            };
        }

        public static AnimalCardReply ToReply(this AnimalCard card)
        {
            return new AnimalCardReply
            {
                Breed = card.Breed,
                Gender = card.Gender,
                CaptureAct = card.ActCapture.ToReply(),
                Category = card.Category,
                Color = card.Color,
                IdAnimalCard = card.IdAnimalCard,
                Ears = card.Ears,
                FurType = card.FurType,
                IdentificationLabel = card.IdentificationLabel,
                Size = card.Size,
                Locality = card.Locality.ToReply(),
                SpecialSigns = card.SpicialSigns,
                Tail = card.Tail,
            };
        }

        public static LocationReply ToReply(this Location loc)
        {
            return new LocationReply()
            {
                City = loc.City,
                IdLocation = loc.IdLocation,
            };
        }

        public static ActReply ToReply(this Act act)
        {
            return new ActReply()
            {
                Contract = act.Contracts.ToReply(),
                ActNumber = act.ActNumber,
                CountCats = act.CountCats,
                CountDogs = act.CountDogs,
                Date = Timestamp.FromDateTime(act.Date.ToUtc()),
                Organization = act.Organization.ToReply(),
                TargetCapture = act.TargetCapture,
            };
        }

        public static ActAppReply ToReply(this ActApp actapp)
        {
            return new ActAppReply()
            {
                Id = actapp.ActAppNumber,
                Act = actapp.Act.ToReply(),
                App = actapp.Application.ToReply()
            };
        }

        public static ApplicationReply ToReply(this App app)
        {
            return new ApplicationReply()
            {
                AnimalDescription = app.animaldescription,
                AnimalHabitat = app.animalHabiat,
                ApplicantCategory = app.applicantCategory,
                Date = Timestamp.FromDateTime(app.date.ToUtc()),
                Locality = app.locality.ToReply(),
                Number = app.number,
                Territory = app.territory,
                UrgencyOfExecution = app.urgencyOfExecution,
                Organization = app.organization.ToReply()
            };
        }

        public static ContractReply ToReply(this Contract contr)
        {
            return new ContractReply
            { 
                ActionDate = Timestamp.FromDateTime(contr.ActionDate.ToUtc()),
                Costumer = contr.Costumer.ToReply(),
                DateConclusion = Timestamp.FromDateTime(contr.DateConclusion.ToUtc()),
                Executer = contr.Executer.ToReply(),
                IdContract = contr.IdContract
            };
        }

        public static OrganizationReply ToReply(this Organization org)
        {
            return new OrganizationReply()
            {
                IdOrganization = org.idOrg,
                INN = org.INN,
                KPP = org.KPP,
                Status = org.status,
                Name = org.name,
                RegistrationAddress = org.registrationAdress.ToReply(),
                Type = org.type,
            };
        }

        public static Contract FromReply(this ContractReply reply)
        {
            return new Contract(
                reply.IdContract,
                reply.DateConclusion.ToDateTime(),
                reply.ActionDate.ToDateTime(),
                reply.Executer.FromReply(),
                reply.Costumer.FromReply());
        }

        public static Organization FromReply(this OrganizationReply reply)
        {
            return new Organization(
                reply.IdOrganization,
                reply.Name,
                reply.INN,
                reply.KPP,
                reply.RegistrationAddress.FromReply(),
                reply.Type,
                reply.Status);
        }

        public static Location FromReply(this LocationReply reply)
        {
            return new Location(
                reply.IdLocation,
                reply.City);
        }

        public static Act FromReply(this ActReply reply)
        {
            return new Act(
                reply.ActNumber,
                reply.CountDogs,
                reply.CountCats,
                reply.Organization.FromReply(),
                reply.Date.ToDateTime(),
                reply.TargetCapture,
                reply.Contract.FromReply());
        }

        public static ActApp FromReply(this ActAppReply reply)
        {
            return new ActApp(
                reply.Id,
                reply.Act.FromReply(),
                reply.App.FromReply());
        }

        public static App FromReply(this ApplicationReply reply)
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
                reply.Organization.FromReply());
        }

        public static AnimalCard FromReply(this AnimalCardReply reply)
        {
            return new AnimalCard(
                reply.IdAnimalCard,
                reply.Category,
                reply.Gender,
                reply.Breed,
                reply.Size,
                reply.FurType,
                reply.Color,
                reply.Ears,
                reply.Tail,
                reply.SpecialSigns,
                reply.IdentificationLabel,
                reply.Locality.FromReply(),
                reply.CaptureAct.FromReply(),
                null);
        }

        public static Location_Contract FromReply(this LocationContractReply r)
        {
            return new Location_Contract(r.Id, r.Location.FromReply(), (decimal)r.Price, r.Contract.FromReply());
        }
    }
}

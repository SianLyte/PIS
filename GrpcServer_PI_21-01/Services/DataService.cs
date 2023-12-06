using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Models;

namespace GrpcServer_PI_21_01.Services
{
    public class DataService : DataRetriever.DataRetrieverBase
    {
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
        }

        #region Contracts
        public override Task<ContractReply> GetContract(IdRequest request, ServerCallContext context)
        {
            Contract? contr = ContractRepository.GetContract(request.Id);

            if (contr is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Contract with ID {request.Id} does not exist"));

            return Task.FromResult(contr.ToReply());
        }

        public override Task<ContractsReply> GetContracts(DataRequest request, ServerCallContext context)
        {
            //IEnumerable<ContractReply> contracts;
            //if (user.PrivelegeLevel == "Admin")
            //    contracts = ContractRepository.GetContracts()
            //        .Select(c => c.ToReply());
            //else contracts = ContractRepository.GetContracts()
            //        .Where(c => c.Costumer.idOrg == user.Organization.IdOrganization
            //        || c.Executer.idOrg == user.Organization.IdOrganization)
            //        .Select(c => c.ToReply());
            var filter = new Filter<Contract>();
            // gotta add filters for different roles, will need to add 'OR' function to Filter.cs
            filter.ExtendReply(request.Filter);
            var contracts = ContractRepository.GetContracts(request).Select(c => c.ToReply());

            var reply = new ContractsReply();
            reply.Contracts.AddRange(contracts);
            return Task.FromResult(reply);
        }

        public override Task<OperationResult> AddContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.AddContract(contract);
            Log(ActionType.ActionAdd, "Contract", contract.IdContract, request.Actor);
            return CRUD(contract.IdContract, successful);
        }
        //public override Task<OperationResult> AddLocationContract(LocationContractReply request, ServerCallContext ctx)
        //{
        //    var locationcontract = request.FromReply();

        //}

        public override Task<OperationResult> UpdateContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.UpdateContract(contract);
            Log(ActionType.ActionUpdate, "Contract", contract.IdContract, request.Actor);
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> RemoveContract(IdRequest id, ServerCallContext ctx)
        {
            var successful = ContractRepository.DeleteContract(id.Id);
            Log(ActionType.ActionDelete, "Contract", id.Id, id.Actor);
            return CRUD(id.Id, successful);
        }
        #endregion
        #region Locations
        public override Task<LocationReply> GetLocation(IdRequest request, ServerCallContext context)
        {
            Location? loc = LocationRepository.GetLocations()
                .FirstOrDefault(l => l.IdLocation == request.Id);

            if (loc is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(loc.ToReply());
        }

        public override async Task GetLocations(UserReply user,
            IServerStreamWriter<LocationReply> responseStream,
            ServerCallContext context)
        {
            foreach (var loc in LocationRepository.GetLocations())
            {
                await responseStream.WriteAsync(loc.ToReply());
            }
        }

        public override Task<OperationResult> AddLocation(LocationReply request, ServerCallContext ctx)
        {
            var location = request.FromReply();
            var successful = LocationRepository.AddLocation(location);
            Log(ActionType.ActionAdd, "Location", location.IdLocation, request.Actor);
            return CRUD(location.IdLocation, successful);
        }

        public override Task<OperationResult> RemoveLocation(IdRequest request, ServerCallContext ctx)
        {
            var successful = LocationRepository.RemoveLocation(request.Id);
            Log(ActionType.ActionDelete, "Location", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateLocation(LocationReply request, ServerCallContext ctx)
        {
            var location = request.FromReply();
            var successful = LocationRepository.UpdateLocation(location);
            Log(ActionType.ActionUpdate, "Location", location.IdLocation, request.Actor);
            return CRUD(location.IdLocation, successful);
        }
        #endregion
        #region Organizations
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
            var filter = new Filter<Organization>(request.Filter);
            foreach (var org in OrgRepository.GetOrganizations(request))
                await responseStream.WriteAsync(org.ToReply());
        }

        public override Task<OperationResult> AddOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.AddOrganization(org);
            Log(ActionType.ActionAdd, "Organization", org.idOrg, reply.Actor);
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> UpdateOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.UpdateOrganization(org);
            Log(ActionType.ActionUpdate, "Organization", org.idOrg, reply.Actor);
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> RemoveOrganization(IdRequest id, ServerCallContext ctx)
        {
            var successful = OrgRepository.RemoveOrganization(id.Id);
            Log(ActionType.ActionDelete, "Organization", id.Id, id.Actor);
            return CRUD(id.Id, successful);
        }
        #endregion
        #region Acts
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
            var filter = new Filter<Act>(request.Filter);
            if (request.Actor.PrivelegeLevel != "Admin")
                filter.AddFilter(act => act.Organization, request.Actor.Organization.IdOrganization.ToString());
            filter.ExtendReply(request.Filter);
            foreach (var act in ActRepository.GetActs(request))
                //.Where(a => user.PrivelegeLevel == "Admin"
                //|| a.Organization.idOrg == user.Organization.IdOrganization))
                await responseStream.WriteAsync(act.ToReply());
        }

        public override Task<OperationResult> AddAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.AddAct(act);
            Log(ActionType.ActionAdd, "Act Capture", act.ActNumber, request.Actor);
            return CRUD(act.ActNumber, successful);
        }

        public override Task<OperationResult> RemoveAct(IdRequest request, ServerCallContext ctx)
        {
            var successful = ActRepository.RemoveAct(request.Id);
            Log(ActionType.ActionDelete, "Act Capture", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.UpdateAct(act);
            Log(ActionType.ActionUpdate, "Act Capture", act.ActNumber, request.Actor);
            return CRUD(act.ActNumber, successful);
        }
        #endregion
        #region Applications
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
            foreach (var app in AppRepository.GetApplications(request))
                // у заявки на отлов нет организации, хотя по суди должна быть
                // пока не меняю, но потом из этого могут вырасти проблемы
                // например, сейчас не могу отфильтровать заявки для пользователя
                await responseStream.WriteAsync(app.ToReply());
        }

        public override Task<OperationResult> AddApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.AddApplication(app);
            Log(ActionType.ActionAdd, "Application", app.number, reply.Actor);
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> UpdateApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.UpdateApplication(app);
            Log(ActionType.ActionUpdate, "Application", app.number, reply.Actor);
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> RemoveApp(IdRequest request, ServerCallContext ctx)
        {
            var successful = AppRepository.RemoveApplication(request.Id);
            Log(ActionType.ActionDelete, "Application", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }
        #endregion
        #region AnimalCards
        public override Task<AnimalCardReply> GetAnimalCard(IdRequest request, ServerCallContext context)
        {
            AnimalCard? animalCard = AnimalRepository.GetAnimalCards()
                .FirstOrDefault(a => a.IdAnimalCard == request.Id);

            if (animalCard is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(animalCard.ToReply());
        }

        public override async Task GetAnimalCards(UserReply user,
            IServerStreamWriter<AnimalCardReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var animalCard in AnimalRepository.GetAnimalCards()
                .Where(ac => user.PrivelegeLevel == "Admin"
                || ac.ActCapture.Organization.idOrg == user.Organization.IdOrganization))
                await responseStream.WriteAsync(animalCard.ToReply());
        }

        public override Task<OperationResult> AddAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.AddAnimalCard(animalCard);
            Log(ActionType.ActionAdd, "Animal Card", animalCard.IdAnimalCard, request.Actor);
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> UpdateAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.UpdateAnimalCard(animalCard);
            Log(ActionType.ActionUpdate, "Animal Card", animalCard.IdAnimalCard, request.Actor);
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> RemoveAnimalCard(IdRequest request, ServerCallContext ctx)
        {
            var successful = AnimalRepository.RemoveAnimalCard(request.Id);
            Log(ActionType.ActionDelete, "Animal Card", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }
        #endregion
        #region Operations
        public override async Task GetOperations(UserReply user,
            IServerStreamWriter<OperationReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var op in OperationRepository.GetOperations())
                await responseStream.WriteAsync(op.ToReply());
        }
        #endregion
        #region ActApps
        public override Task<ActAppReply> GetActApp(IdRequest request, ServerCallContext context)
        {
            ActApp r = ActRepository.GetActApp(request.Id);

            if (r is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(r.ToReply());
        }

        public override async Task GetActApps(UserReply request,
            IServerStreamWriter<ActAppReply> responseStream,
            ServerCallContext context)
        {

            foreach (var actApp in ActRepository.GetActApps())
                await responseStream.WriteAsync(actApp.ToReply());
        }

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

        public override async Task GetLocationContracts(UserReply request,
            IServerStreamWriter<LocationContractReply> responseStream,
            ServerCallContext context)
        {
            foreach (var locationContract in LocationRepository.GetLocationContracts())
                await responseStream.WriteAsync(locationContract.ToReply());
        }

        public override Task<OperationResult> AddLocationContract(LocationContractReply request, ServerCallContext context)
        {
            var successful = LocationRepository.AddLocationContract(request.FromReply());
            Log(ActionType.ActionAdd, "Location Contract", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateLocationContract(LocationContractReply request, ServerCallContext context)
        {
            var successful = LocationRepository.UpdateLocationContract(request.FromReply());
            Log(ActionType.ActionUpdate, "Location Contract", request.Id, request.Actor);
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
                Action = ActionType.ActionAdd, 
                ModifiedObjectId = int.Parse(operation.modifiedObjectId), 
                ModifiedTableName = operation.modifiedTableName,
                User = operation.user.ToReply(),
                Date = operation.date.ToUtc().ToTimestamp(),
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
                RegistrationAddress = org.registrationAdress,
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
                reply.RegistrationAddress,
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
                reply.Status);
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

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

        public static void Log(ActionType actType, string tableName, int modifId, UserReply actor)
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
            OperationRepository.AddOperation(operation);
        }

        #region Contracts
        public override Task<ContractReply> GetContract(IdRequest request, ServerCallContext context)
        {
            Contract? contr = ContractRepository.GetContracts()
                .FirstOrDefault(c => c.IdContract == request.Id);

            if (contr is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(contr.ToReply());
        }

        public override Task<ContractsReply> GetContracts(UserReply user, ServerCallContext context)
        {
            IEnumerable<ContractReply> contracts;
            if (user.PrivelegeLevel == "Admin")
                contracts = ContractRepository.GetContracts()
                    .Select(c => c.ToReply());
            else contracts = ContractRepository.GetContracts()
                    .Where(c => c.Costumer.idOrg == user.Organization.IdOrganization
                    || c.Executer.idOrg == user.Organization.IdOrganization)
                    .Select(c => c.ToReply());

            var reply = new ContractsReply();
            reply.Contracts.AddRange(contracts);
            return Task.FromResult(reply);
        }

        public override Task<OperationResult> AddContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.AddContract(contract);
            Log(ActionType.ACTION_ADD, "Contract", contract.IdContract, request.Actor);
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> UpdateContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.UpdateContract(contract);
            Log(ActionType.ACTION_UPDATE, "Contract", contract.IdContract, request.Actor);
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> RemoveContract(IdRequest id, ServerCallContext ctx)
        {
            var successful = ContractRepository.DeleteContract(id.Id);
            Log(ActionType.ACTION_DELETE, "Contract", id.Id, id.Actor);
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
            Log(ActionType.ACTION_ADD, "Location", location.IdLocation, request.Actor);
            return CRUD(location.IdLocation, successful);
        }

        public override Task<OperationResult> RemoveLocation(IdRequest request, ServerCallContext ctx)
        {
            var successful = LocationRepository.RemoveLocation(request.Id);
            Log(ActionType.ACTION_DELETE, "Location", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateLocation(LocationReply request, ServerCallContext ctx)
        {
            var location = request.FromReply();
            var successful = LocationRepository.UpdateLocation(location);
            Log(ActionType.ACTION_UPDATE, "Location", location.IdLocation, request.Actor);
            return CRUD(location.IdLocation, successful);
        }
        #endregion
        #region Organizations
        public override Task<OrganizationReply> GetOrganization(IdRequest request, ServerCallContext context)
        {
            Organization? org = OrgRepository.GetOrganizations().FirstOrDefault(o => o.idOrg == request.Id);

            if (org is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(org.ToReply());
        }

        public override async Task GetOrganizations(UserReply user,
            IServerStreamWriter<OrganizationReply> responseStream,
            ServerCallContext context)
        {
            foreach (var org in OrgRepository.GetOrganizations())
                await responseStream.WriteAsync(org.ToReply());
        }

        public override Task<OperationResult> AddOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.AddOrganization(org);
            Log(ActionType.ACTION_ADD, "Organization", org.idOrg, reply.Actor);
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> UpdateOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.UpdateOrganization(org);
            Log(ActionType.ACTION_UPDATE, "Organization", org.idOrg, reply.Actor);
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> RemoveOrganization(IdRequest id, ServerCallContext ctx)
        {
            var successful = OrgRepository.RemoveOrganization(id.Id);
            Log(ActionType.ACTION_DELETE, "Organization", id.Id, id.Actor);
            return CRUD(id.Id, successful);
        }
        #endregion
        #region Acts
        public override Task<ActReply> GetAct(IdRequest request, ServerCallContext context)
        {
            Act? act = ActRepository.GetActs()
                .FirstOrDefault(a => a.ActNumber == request.Id);

            if (act is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(act.ToReply());
        }

        public override async Task GetActs(UserReply user,
            IServerStreamWriter<ActReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var act in ActRepository.GetActs()
                .Where(a => user.PrivelegeLevel == "Admin"
                || a.Organization.idOrg == user.Organization.IdOrganization))
                await responseStream.WriteAsync(act.ToReply());
        }

        public override Task<OperationResult> AddAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.AddAct(act);
            Log(ActionType.ACTION_ADD, "Act Capture", act.ActNumber, request.Actor);
            return CRUD(act.ActNumber, successful);
        }

        public override Task<OperationResult> RemoveAct(IdRequest request, ServerCallContext ctx)
        {
            var successful = ActRepository.RemoveAct(request.Id);
            Log(ActionType.ACTION_DELETE, "Act Capture", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.UpdateAct(act);
            Log(ActionType.ACTION_UPDATE, "Act Capture", act.ActNumber, request.Actor);
            return CRUD(act.ActNumber, successful);
        }
        #endregion
        #region Applications
        public override Task<ApplicationReply> GetApp(IdRequest request, ServerCallContext ctx)
        {
            App? app = AppRepository.GetApplications()
                .FirstOrDefault(a => a.number == request.Id);

            if (app is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(app.ToReply());
        }

        public override async Task GetApps(UserReply user,
            IServerStreamWriter<ApplicationReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var app in AppRepository.GetApplications())
                // у заявки на отлов нет организации, хотя по суди должна быть
                // пока не меняю, но потом из этого могут вырасти проблемы
                // например, сейчас не могу отфильтровать заявки для пользователя
                await responseStream.WriteAsync(app.ToReply());
        }

        public override Task<OperationResult> AddApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.AddApplication(app);
            Log(ActionType.ACTION_ADD, "Application", app.number, reply.Actor);
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> UpdateApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.UpdateApplication(app);
            Log(ActionType.ACTION_UPDATE, "Application", app.number, reply.Actor);
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> RemoveApp(IdRequest request, ServerCallContext ctx)
        {
            var successful = AppRepository.RemoveApplication(request.Id);
            Log(ActionType.ACTION_DELETE, "Application", request.Id, request.Actor);
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
            Log(ActionType.ACTION_ADD, "Animal Card", animalCard.IdAnimalCard, request.Actor);
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> UpdateAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.UpdateAnimalCard(animalCard);
            Log(ActionType.ACTION_UPDATE, "Animal Card", animalCard.IdAnimalCard, request.Actor);
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> RemoveAnimalCard(IdRequest request, ServerCallContext ctx)
        {
            var successful = AnimalRepository.RemoveAnimalCard(request.Id);
            Log(ActionType.ACTION_DELETE, "Animal Card", request.Id, request.Actor);
            return CRUD(request.Id, successful);
        }
        #endregion
        #region Operations
        public override async Task GetOperations(UserReply user,
            IServerStreamWriter<OperationReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var op in OperationRepository.GetOperations())
                await responseStream.WriteAsync(op);
        }
        #endregion
    }

    public static class DataExtensions
    {
        public static DateTime ToUtc(this DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
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
                App = act.Application.ToReply(),
                CountCats = act.CountCats,
                CountDogs = act.CountDogs,
                Date = Timestamp.FromDateTime(act.Date.ToUtc()),
                Organization = act.Organization.ToReply(),
                TargetCapture = act.TargetCapture,
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
                Locality = app.locality,
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
                reply.App.FromReply(),
                reply.Contract.FromReply());
        }

        public static App FromReply(this ApplicationReply reply)
        {
            return new App(
                reply.Date.ToDateTime(),
                reply.Number,
                reply.Locality,
                reply.Territory,
                reply.AnimalHabitat,
                reply.UrgencyOfExecution,
                reply.AnimalDescription,
                reply.ApplicantCategory);
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
    }
}

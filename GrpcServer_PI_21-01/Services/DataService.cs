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

        #region Contracts
        public override Task<ContractReply> GetContract(IdRequest request, ServerCallContext context)
        {
            Contract? contr = ContractRepository.GetContracts()
                .FirstOrDefault(c => c.IdContract == request.Id);

            if (contr is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(contr.ToReply());
        }

        public override Task<ContractsReply> GetContracts(Empty empty, ServerCallContext context)
        {
            var contracts = ContractRepository.GetContracts()
                .Select(c => c.ToReply());

            var reply = new ContractsReply();
            reply.Contracts.AddRange(contracts);
            return Task.FromResult(reply);
        }

        public override Task<OperationResult> AddContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.AddContract(contract);
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> UpdateContract(ContractReply request, ServerCallContext ctx)
        {
            var contract = request.FromReply();
            var successful = ContractRepository.UpdateContract(contract);
            return CRUD(contract.IdContract, successful);
        }

        public override Task<OperationResult> RemoveContract(IdRequest id, ServerCallContext ctx)
        {
            var successful = ContractRepository.DeleteContract(id.Id);
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

        public override async Task GetLocations(Empty request,
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
            return CRUD(location.IdLocation, successful);
        }

        public override Task<OperationResult> RemoveLocation(IdRequest request, ServerCallContext ctx)
        {
            var successful = LocationRepository.RemoveLocation(request.Id);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateLocation(LocationReply request, ServerCallContext ctx)
        {
            var location = request.FromReply();
            var successful = LocationRepository.UpdateLocation(location);
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

        public override async Task GetOrganizations(Empty request,
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
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> UpdateOrganization(OrganizationReply reply, ServerCallContext ctx)
        {
            var org = reply.FromReply();
            var successful = OrgRepository.UpdateOrganization(org);
            return CRUD(org.idOrg, successful);
        }

        public override Task<OperationResult> RemoveOrganization(IdRequest id, ServerCallContext ctx)
        {
            var successful = OrgRepository.RemoveOrganization(id.Id);
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

        public override async Task GetActs(Empty e,
            IServerStreamWriter<ActReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var act in ActRepository.GetActs())
                await responseStream.WriteAsync(act.ToReply());
        }

        public override Task<OperationResult> AddAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.AddAct(act);
            return CRUD(act.ActNumber, successful);
        }

        public override Task<OperationResult> RemoveAct(IdRequest request, ServerCallContext ctx)
        {
            var successful = ActRepository.RemoveAct(request.Id);
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateAct(ActReply request, ServerCallContext ctx)
        {
            var act = request.FromReply();
            var successful = ActRepository.UpdateAct(act);
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

        public override async Task GetApps(Empty e,
            IServerStreamWriter<ApplicationReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var app in AppRepository.GetApplications())
                await responseStream.WriteAsync(app.ToReply());
        }

        public override Task<OperationResult> AddApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.AddApplication(app);
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> UpdateApp(ApplicationReply reply, ServerCallContext ctx)
        {
            var app = reply.FromReply();
            var successful = AppRepository.UpdateApplication(app);
            return CRUD(app.number, successful);
        }

        public override Task<OperationResult> RemoveApp(IdRequest request, ServerCallContext ctx)
        {
            var successful = AppRepository.RemoveApplication(request.Id);
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

        public override async Task GetAnimalCards(Empty e,
            IServerStreamWriter<AnimalCardReply> responseStream,
            ServerCallContext ctx)
        {
            foreach (var animalCard in AnimalRepository.GetAnimalCards())
                await responseStream.WriteAsync(animalCard.ToReply());
        }

        public override Task<OperationResult> AddAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.AddAnimalCard(animalCard);
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> UpdateAnimalCard(AnimalCardReply request, ServerCallContext ctx)
        {
            var animalCard = request.FromReply();
            var successful = AnimalRepository.UpdateAnimalCard(animalCard);
            return CRUD(animalCard.IdAnimalCard, successful);
        }

        public override Task<OperationResult> RemoveAnimalCard(IdRequest request, ServerCallContext ctx)
        {
            var successful = AnimalRepository.RemoveAnimalCard(request.Id);
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
                Cost = contr.Cost,
                Costumer = contr.Costumer.ToReply(),
                DateConclusion = Timestamp.FromDateTime(contr.DateConclusion.ToUtc()),
                Executer = contr.Executer.ToReply(),
                IdContract = contr.IdContract,
                LocationCost = contr.LocationCost.ToReply(),
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
                reply.LocationCost.FromReply(),
                reply.Cost,
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

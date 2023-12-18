using Google.Protobuf.WellKnownTypes;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Controllers;

namespace GrpcClient_PI_21_01
{
    public static class DataExtensions
    {
        public static ReportReply ToReply(this Report rep)
        {
            return new ReportReply()
            {
                Id = rep.Id,
                CreatedAt = rep.CreatedAt.ToTimestamp(),
                UpdatedAt = rep.UpdatedAt.ToTimestamp(),
                StartDate = rep.StartDate.ToTimestamp(),
                EndDate = rep.EndDate.ToTimestamp(),
                Profit
                = rep.Profit,
                ClosedAppsCount = rep.ClosedAppsCount,
                AnimalsCount = rep.AnimalsCount,
                Status = rep.Status,
                User = rep.User.ToReply(),
            };
        }

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
                Actor = UserService.CurrentUser?.ToReply(),
            };
        }

        public static LocationReply ToReply(this Location loc)
        {
            var reply = loc.ToReplyWithoutActor();
            reply.Actor = UserService.CurrentUser?.ToReply();
            return reply;
        }

        public static LocationReply ToReplyWithoutActor(this Location loc)
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
                //App = act.Application.ToReply(),
                CountCats = act.CountCats,
                CountDogs = act.CountDogs,
                Date = Timestamp.FromDateTime(act.Date.ToUtc()),
                Organization = act.Organization.ToReply(),
                TargetCapture = act.TargetCapture,
                Actor = UserService.CurrentUser?.ToReply(),
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
                Actor = UserService.CurrentUser?.ToReply(),
                Organization = app.organization.ToReply(),
                AnimalCount = app.animalCount,
                Status = app.status
                
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
                IdContract = contr.IdContract,
                Actor = UserService.CurrentUser?.ToReply(),
            };
        }

        public static OrganizationReply ToReply(this Organization org)
        {
            var reply = org.ToReplyWithoutActor();
            reply.Actor = UserService.CurrentUser?.ToReply();
            reply.RegistrationAddress = org.registrationAdress.ToReply();
            return reply;
        }

        public static OrganizationReply ToReplyWithoutActor(this Organization org)
        {
            return new OrganizationReply()
            {
                IdOrganization = org.idOrg,
                INN = org.INN,
                KPP = org.KPP,
                Status = org.status,
                Name = org.name,
                RegistrationAddress = org.registrationAdress.ToReplyWithoutActor(),
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
                //reply.App.FromReply(),
                reply.Contract.FromReply());
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
                reply.Organization.FromReply(), 
                reply.AnimalCount);
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

        public static ActApp FromReply(this ActAppReply r)
        {
            return new ActApp(r.Id, r.Act.FromReply(), r.App.FromReply(), r.CountDogs, r.CountCats);
        }

        public static Operation FromReply(this OperationReply r)
        {
            return new Operation(
                r.OperationId,
                r.Action,
                r.ModifiedObjectId,
                r.ModifiedTableName,
                User.FromReply(r.User),
                r.Date.ToDateTime());
        }

        public static Report FromReply(this ReportReply r)
        {
            return new Report(
                r.Id,
                r.CreatedAt.ToDateTime(),
                r.UpdatedAt.ToDateTime(),
                r.StartDate.ToDateTime(),
                r.EndDate.ToDateTime(),
                r.Profit,
                r.ClosedAppsCount,
                r.AnimalsCount,
                User.FromReply(r.User),
                r.Status);
        }
    }
}
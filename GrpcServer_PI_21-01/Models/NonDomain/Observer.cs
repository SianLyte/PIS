namespace GrpcServer_PI_21_01.Models
{
    public interface IObserver
    {
        void Update(object ob);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public class StatusReportObserver : IObserver
    {
        public List<ReportStatus> Statuses { get; }
        public StatusReportObserver()
        {
            Statuses = new List<ReportStatus>();
        }
        public void Update(object obj)
        {
            Statuses.Clear();
            var role  = (Roles)obj;
            if (role == Roles.Admin)
            {
                foreach (var rol in Enum.GetValues(typeof(ReportStatus)))
                    Statuses.Add((ReportStatus)rol);
            }
            if (role == Roles.OperatorPoOtlovy)
            {
                Statuses.Add(ReportStatus.ApprovalFromMunicipalContractExecutor);
            }
            else if (role == Roles.CuratorPoOtlovy)
            {
                Statuses.Add(ReportStatus.ApprovedByMunicipalContractExecutor);
                Statuses.Add(ReportStatus.Revision);
            }
            else if (role == Roles.PodpisantPoOtlovy)
            {
                Statuses.Add(ReportStatus.AgreedWithMunicipalContractExecutor);
                Statuses.Add(ReportStatus.Revision);
            }
            else if (role == Roles.CuratorOmsy)
            {
                Statuses.Add(ReportStatus.Revision);
                Statuses.Add(ReportStatus.ApprovedByOmsy);
            }
        }
    }

    public class StatusReportSubject : ISubject
    {
        private Roles _role;
        private List<IObserver> _observers;
        public Roles Role
        {
            get { return _role; }
            set 
            {
                _role = value;
                NotifyObservers();
            } 
        }
        public StatusReportSubject()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_role);
            }
        }
    }
}

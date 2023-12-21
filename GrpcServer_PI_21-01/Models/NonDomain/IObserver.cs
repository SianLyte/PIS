using System.Data;

namespace GrpcServer_PI_21_01.Models
{
    public interface IObserver
    {
        void Update<T>(ObserverArguments<T> ob);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers<T>(ObserverArguments<T> arguments);
    }
}

//    public enum ReportActions
//    {
//        Add = 0,
//        Remove = 1,
//        Update = 2,
//    }

//    public class StatusReportObserver : IObserver
//    {
//        public List<ReportStatus> Statuses { get; }
//        public List<ReportActions> AvailableActions { get; }

//        public StatusReportObserver()
//        {
//            Statuses = new List<ReportStatus>();
//            AvailableActions = new List<ReportActions>();
//        }
//        public void Update(object obj)
//        {
//            var subj = obj as SubjectInfo;
//            SetAvailableStatuses(subj);
//            if (subj.currentStatus != null && subj.actionType != null)
//                SetAvailableActions(subj.role);
//        }

//        public void SetAvailableActions(Roles role)
//        {
//            AvailableActions.Clear();
//            if (role == Roles.OperatorPoOtlovy || role == Roles.Admin)
//            {
//                foreach (var rol in Enum.GetValues(typeof(ReportActions)))
//                    AvailableActions.Add((ReportActions)rol);
//            }
//            else if (role == Roles.CuratorPoOtlovy ||
//                     role == Roles.PodpisantPoOtlovy ||
//                     role == Roles.CuratorOmsy)
//            {
//                AvailableActions.Add(ReportActions.Update);
//            }
//        }

//        public void SetAvailableStatuses(SubjectInfo obj)
//        {
//            Statuses.Clear();

//            if (obj.role == Roles.Admin)
//                foreach (var rol in Enum.GetValues(typeof(ReportStatus)))
//                    Statuses.Add((ReportStatus)rol);

//            if (obj.role == Roles.OperatorPoOtlovy)
//            {
//                if (obj.actionType == ActionType.ActionAdd)
//                {
//                    Statuses.Add(ReportStatus.ApprovalFromMunicipalContractExecutor);
//                }
//                else
//                {
//                    if (obj.currentStatus ==  ReportStatus.Revision || obj.currentStatus == ReportStatus.ApprovalFromMunicipalContractExecutor)
//                    {
//                        Statuses.Add(ReportStatus.ApprovalFromMunicipalContractExecutor);
//                    }
//                }
//            }

//            if (obj.role == Roles.CuratorPoOtlovy)
//            {
//                if (obj.actionType == ActionType.ActionUpdate)
//                {
//                    if (obj.currentStatus == ReportStatus.ApprovalFromMunicipalContractExecutor)
//                    {
//                        Statuses.Add(ReportStatus.Revision);
//                        Statuses.Add(ReportStatus.ApprovedByMunicipalContractExecutor);
//                    }
//                }
//            }

//            if (obj.role == Roles.PodpisantPoOtlovy)
//            {
//                if (obj.actionType == ActionType.ActionUpdate)
//                {
//                    if (obj.currentStatus == ReportStatus.ApprovedByMunicipalContractExecutor)
//                    {
//                        Statuses.Add(ReportStatus.Revision);
//                        Statuses.Add(ReportStatus.AgreedWithMunicipalContractExecutor);
                        
//                    }
//                }
//            }

//            if (obj.role == Roles.CuratorOmsy)
//            {
//                if (obj.actionType == ActionType.ActionUpdate)
//                {
//                    if (obj.currentStatus == ReportStatus.AgreedWithMunicipalContractExecutor)
//                    {
//                        Statuses.Add(ReportStatus.Revision);
//                        Statuses.Add(ReportStatus.ApprovedByOmsy);
//                    }
//                }
//            }
//        }
//    }

//    public class SubjectInfo
//    {
//        public Roles role;
//        public ActionType actionType;
//        public ReportStatus currentStatus;
//        public SubjectInfo() 
//        {
//        }
//    }

//    public class StatusReportSubject : ISubject
//    {
//        SubjectInfo _subjectInfo;
//        //private Roles _role;
//        //private ActionType _actionType;
//        //private ReportStatus _currentStatus;

//        private List<IObserver> _observers;
//        public Roles Role
//        {
//            get { return _subjectInfo.role; }
//            set 
//            {
//                _subjectInfo.role = value;
//                NotifyObservers();
//            } 
//        }
//        public ActionType ActionType
//        {
//            get { return _subjectInfo.actionType; }
//            set
//            {
//                _subjectInfo.actionType = value;
//                NotifyObservers();
//            }
//        }

//        public ReportStatus CurrentStatus
//        {
//            get { return _subjectInfo.currentStatus; }
//            set
//            {
//                _subjectInfo.currentStatus = value;
//                NotifyObservers();
//            }
//        }
//        public StatusReportSubject()
//        {
//            _observers = new List<IObserver>();
//            _subjectInfo = new SubjectInfo();
//        }

//        public void RegisterObserver(IObserver o)
//        {
//            _observers.Add(o);
//        }

//        public void RemoveObserver(IObserver o)
//        {
//            _observers.Remove(o);
//        }

//        public void NotifyObservers()
//        {
//            foreach (var observer in _observers)
//            {
//                observer.Update(_subjectInfo);
//            }
//        }
//    }
//}

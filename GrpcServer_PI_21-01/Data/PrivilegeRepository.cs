using GrpcServer_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class PrivilegeRepository
    {
        private readonly static Dictionary<string, Dictionary<NameMdels, bool>> rols = new()
        {
            // этот ужас желательно исправить, но мне лень
            {
                Roles.Operator_Po_Otlovy.ToString(),
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, true},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                Roles.Operator_Veterinary_Service.ToString(),
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, true},
                                                                    {NameMdels.Report, false},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                Roles.Operator_OMSY.ToString(),
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, true},
                                                                    {NameMdels.Contract, true},
                                                                    {NameMdels.Org, true},
                                                                    {NameMdels.Report, true},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                "Сотрудник вет. службы",
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                "Сотрудник отлова",
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                "Сотрудник ОМСУ",
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                "Сотрудник приюта",
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, false},
                                                                    {NameMdels.App, false},
                                                                    {NameMdels.Contract, false},
                                                                    {NameMdels.Org, false},
                                                                    {NameMdels.Report, false},
                                                                    {NameMdels.History, false },
                                                                }
            },
            {
                Roles.Admin.ToString(),
                new Dictionary<NameMdels, bool>()
                                                                {
                                                                    {NameMdels.Act, true},
                                                                    {NameMdels.App, true},
                                                                    {NameMdels.Contract, true},
                                                                    {NameMdels.Org, true},
                                                                    {NameMdels.Report, true},
                                                                    {NameMdels.History, true },
                                                                }
            }
        };

        public static bool SetPrivilege(string privelege, NameMdels model)
        {
            return rols[privelege][model];
            //var user = UserSessia.UserLog;
            //return user.Role.CheckPosibilitis[model];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class Previlege
    {
        public string DisplayName { get; }
        public string Name { get; }

        public Previlege(string name, string displayName)
        {
            DisplayName = displayName;
            Name = name;
        }
    }

    enum NameMdels
    {
        Act,
        App,
        Contract,
        Org,
        Report,
        History,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IWorkTeamActivities
    {
        void Comunicate();
        void Plan();
    }

    public interface IDevelopertActivities {
        void Develop();
    }

    public interface ITestActivities {
        void Test();
    }

    public interface IDesignActivities {
        void Design();
    }
}
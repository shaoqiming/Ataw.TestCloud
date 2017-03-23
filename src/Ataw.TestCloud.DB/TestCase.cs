using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.TestCloud.DB
{
    public class TestCase
    {
        public string FID;
        public string Name;
        public string Owner;
        public DateTime StartTime;
        public DateTime EndTime;
        public TimeSpan duration;
        public Boolean isSuccess;
        public string errorinfo;
    }

    public class TestCaseSteep
    {
        public string FID;
        public string TestCaseFID;
        public string Name;
        public string Owner;
        public DateTime StartTime;
        public DateTime EndTime;
        public TimeSpan duration;
        public Boolean isSuccess;
        public string errorinfo;
    }
}

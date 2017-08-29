using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBLabs.CybozuConnect;

namespace Cybozu.AppendScheduleDemo
{
    public class ApplicationCache
    {
        private static App app;

        public static App CybozuApp { get => app; set => app = value; }
    }
}

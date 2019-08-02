using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace CBLabs.CybozuConnect
{
    public class ApplicationCache
    {
        private static App app;

        public static App CybozuApp { get => app; set => app = value; }
    }
}

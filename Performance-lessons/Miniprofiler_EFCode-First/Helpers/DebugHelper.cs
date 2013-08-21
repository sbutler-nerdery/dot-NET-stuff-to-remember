using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miniprofiler.CodeFirst.Helpers
{
    public class DebugHelper
    {
        public static bool IsDebugging()
        {
            var isDebug = false;

#if DEBUG
            isDebug = true;
#endif

            return isDebug;
        }
    }
}
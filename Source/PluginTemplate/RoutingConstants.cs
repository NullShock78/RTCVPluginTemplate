using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginTemplate
{
    internal static class Endpoint
    {
        public const string PREFIX = "YOURPREFIX";
        public const string EMU_SIDE = PREFIX + "EMU";
        public const string RTC_SIDE = PREFIX + "RTC";
    }

    internal static class Commands
    {
        public const string SHOW_WINDOW = Endpoint.PREFIX + nameof(SHOW_WINDOW);
    }
}

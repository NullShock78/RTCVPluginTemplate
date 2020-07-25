using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginTemplate;
using RTCV.CorruptCore;
using RTCV.NetCore;

namespace PluginTemplate
{
    /// <summary>
    /// This lies on the RTC(Server) side
    /// </summary>
    class PluginConnectorRTC : IRoutable
    {
        public PluginConnectorRTC()
        {
            LocalNetCoreRouter.registerEndpoint(this, Endpoint.RTC_SIDE);
        }

        public object OnMessageReceived(object sender, NetCoreEventArgs e)
        {
            NetCoreAdvancedMessage message = e.message as NetCoreAdvancedMessage;
            switch (message.Type)
            {
                default:
                    break;
            }
            return e.returnMessage;
        }
    }
}

using NLog;
using PluginTemplate.UI;
using RTCV.Common;
using RTCV.NetCore;
using RTCV.PluginHost;
using RTCV.UI;
using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace PluginTemplate
{
    [Export(typeof(IPlugin))]
    public class Loader : IPlugin, IDisposable
    {
        public static RTCSide CurrentSide = RTCSide.Both;
        internal static PluginConnectorEMU connectorEMU = null;
        internal static PluginConnectorRTC connectorRTC = null;

        public string Name => "PluginTemplate";
        public string Description => "A template for RTC plugins";

        public string Author => "Your Name";

        public Version Version => new Version(0, 0, 0);

        public RTCSide SupportedSide => RTCSide.Both;

        public void Dispose()
        {
        }

        public bool Start(RTCSide side)
        {
            Logging.GlobalLogger.Info($"{Name} v{Version} initializing.");
            if (side == RTCSide.Client)
            {
                connectorEMU = new PluginConnectorEMU();
                S.SET<PluginForm>(new PluginForm());
            }
            else if (side == RTCSide.Server)
            {
                //Uncomment if needed
                //connectorRTC = new PluginConnectorRTC();
                S.GET<RTC_OpenTools_Form>().RegisterTool("Plugin Template", "Open Plugin Template", () => { 
                    //This is the method you use to route commands between the RTC side and the Emulator side
                    LocalNetCoreRouter.Route(Endpoint.EMU_SIDE, Commands.SHOW_WINDOW, true); 
                });
            }
            Logging.GlobalLogger.Info($"{Name} v{Version} initialized.");
            CurrentSide = side;
            return true;
        }

        public bool Stop()
        {
            if (Loader.CurrentSide == RTCSide.Client && !S.ISNULL<PluginForm>() && !S.GET<PluginForm>().IsDisposed)
            {
                S.GET<PluginForm>().Close();
            }
            return true;
        }
    }
}

using PluginTemplate.UI;
using NLog;
using RTCV.Common;
using RTCV.CorruptCore;
using RTCV.NetCore;
using System;
using System.Windows.Forms;

namespace PluginTemplate
{
    /// <summary>
    /// This lies on the Emulator(Client) side
    /// </summary>
    internal class PluginConnectorEMU : IRoutable
    {
        public PluginConnectorEMU()
        {
            LocalNetCoreRouter.registerEndpoint(this, Endpoint.EMU_SIDE);
        }

        public object OnMessageReceived(object sender, NetCoreEventArgs e)
        {
            NetCoreAdvancedMessage message = e.message as NetCoreAdvancedMessage;

            switch (message.Type)
            {
                case Commands.SHOW_WINDOW:
                    try
                    {
                        SyncObjectSingleton.FormExecute(() =>
                        {
                            if (S.GET<PluginForm>() == null || S.GET<PluginForm>().IsDisposed)
                            {
                                S.SET<PluginForm>(new PluginForm());
                            }
                            var form = S.GET<PluginForm>();
                            form.Show();
                            form.Activate();
                        });
                        break;
                    }
                    catch
                    {
                        Logging.GlobalLogger.Error($"Template command {Commands.SHOW_WINDOW} failed. Reason:\r\n" + e.ToString());
                        break;
                    }
            }
            return e.returnMessage;
        }
    }
}

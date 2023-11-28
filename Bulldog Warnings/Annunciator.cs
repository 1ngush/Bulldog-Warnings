using Exiled.API.Features;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace Bulldog_Warnings
{
    public class Annunciator
    {
        internal static CoroutineHandle Handle;

        internal static void Toggle(Player player)
        {
            if (Basic.AdminSettings.TryGetValue(player.UserId, out var adminSettings) && adminSettings.WarningsStatus)
            {
                Handle = Timing.RunCoroutine(Send(player));
            }
            else
            {
                Timing.KillCoroutines(Handle);
            }
        }

        internal static IEnumerator<float> Send(Player player)
        {
            while (true)
            {
                if (Basic.waitForUpdate)
                {
                    yield return Timing.WaitForSeconds(1f);
                }
                else
                {
                    if (Basic.Violators.Values.Any(v => v.Count > 0))
                    {
                        foreach (var pair in Basic.Violators.Where(v => IsWarningEnabled(player, v.Value.Reason)))
                        {
                            string message = $"{Basic.Configuration.ConsoleMessage.Replace("%name%", pair.Key.Nickname).Replace("%id%", pair.Key.Id.ToString()).Replace("%reason%", pair.Value.Reason).Replace("%count%", pair.Value.Count.ToString())}";
                            player.RemoteAdminMessage(message, true, "Bulldog Warnings");
                            if (Basic.AdminSettings[player.UserId].ShowHint && Basic.Configuration.ShowHint)
                                player.ShowHint(Basic.Configuration.HintMessage);
                        }
                    }
                    Basic.waitForUpdate = true;
                }
            }
        }
        private static bool IsWarningEnabled(Player admin, string reason)
        {
            return Basic.AdminSettings.TryGetValue(admin.UserId, out var adminSettings) &&
                   adminSettings?.GetType().GetProperty(reason)?.GetValue(adminSettings) is bool boolValue ? boolValue : true;
        }
    }
}



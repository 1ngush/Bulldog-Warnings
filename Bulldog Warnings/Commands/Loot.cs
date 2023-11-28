using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Loot : ICommand
    {
        internal static CoroutineHandle Handle;

        public string Command => "sloot";
        public string[] Aliases => new string[] { "sl" };
        public string Description => "Ограничивает видимость предметов в метрах";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.AdminChat))
            {
                response = "Вам не выдали доступа для использования этой команды.";
                return true;
            }

            if (!Player.TryGet(sender, out Player player))
            {
                response = "Не удалось получить игрока";
                return true;
            }
            if (arguments.Count > 0)
            {
                Basic.Configuration.IsItemsLimitingDistance = float.Parse(arguments.At(0));
                response = $"Вы установили новое ограничение: {Basic.Configuration.IsItemsLimitingDistance} метров.";
                return true;
            }
            response = Handler();
            return false;
        }

        private string Handler()
        {
            Basic.Configuration.IsItemsLimiting = !Basic.Configuration.IsItemsLimiting;

            if (Basic.Configuration.IsItemsLimiting)
            {
                Handle = Timing.RunCoroutine(T());
            }
            else
            {
                foreach (var pickup in Basic.disabledPickups)
                {
                    pickup.Spawn();
                }
                Basic.disabledPickups.Clear();

                Timing.KillCoroutines(Handle);
            }

            return string.Format("Вы успешно {0} лимит показа предметов.", Basic.Configuration.IsItemsLimiting ? "<color=green>включили</color>" : "<color=red>выключили</color>");
        }

        internal static IEnumerator<float> T()
        {
            while (true)
            {
                if (Basic.Configuration.IsItemsLimiting)
                {
                    foreach (var item in Pickup.List)
                    {
                        foreach (var player in Player.List)
                        {
                            if (Vector3.Distance(player.Position, item.Position) > Basic.Configuration.IsItemsLimitingDistance)
                            {
                                if (!Basic.disabledPickups.Contains(item))
                                {
                                    item.UnSpawn();
                                    Basic.disabledPickups.Add(item);
                                }
                            }
                            else
                            {
                                if (Basic.disabledPickups.Contains(item))
                                {
                                    item.Spawn();
                                    Basic.disabledPickups.Remove(item);
                                }
                            }
                        }
                    }
                }
                yield return Timing.WaitForOneFrame;
            }
        }
    }
}

using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using InventorySystem.Items.Pickups;
using System;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Clear : ICommand
    {
        public string Command => "wclear";
        public string[] Aliases => new string[] { "wc" };

        public string Description => "Очищает список жалоб.";

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

            Basic.Violators.Clear();
            Basic.killCounts.Clear();

            response = "<color=green>Список жалоб успешно очищен.";
            return false;
        }
    }
}

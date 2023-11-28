using CommandSystem;
using Exiled.API.Features;
using System;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Hint : ICommand
    {
        public string Command => "shint";
        public string[] Aliases => new string[] { "sh" };
        public string Description => "Локально переключает статус показывания подсказок.";

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

            if (!Basic.AdminSettings.ContainsKey(player.UserId))
            {
                Basic.AdminSettings[player.UserId] = new AdminSettings();
            }

            Basic.AdminSettings[player.UserId].ShowHint = !Basic.AdminSettings[player.UserId].ShowHint;
            response = string.Format("Вы успешно {0} показ подсказок. [GLOBAL] - {1}", Basic.AdminSettings[player.UserId].ShowHint ? "<color=green>включили</color>" : "<color=red>выключили</color>", Basic.Configuration.ShowHint ? "<color=green>Включены</color>" : "<color=red>Выключены</color>");
            return false;
        }
    }
}


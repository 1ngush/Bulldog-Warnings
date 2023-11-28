using CommandSystem;
using Exiled.API.Features;
using System;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Warnings : ICommand
    {
        public string Command => "warnings";

        public string[] Aliases => new string[] { "w" };

        public string Description => "Включает варнинги.";

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
            response = Handler(player);
            return false;
        }
        private string Handler(Player player)
        {
            if (!Basic.AdminSettings.ContainsKey(player.UserId))
            {
                Basic.AdminSettings[player.UserId] = new AdminSettings();
            }
            Basic.AdminSettings[player.UserId].WarningsStatus = !Basic.AdminSettings[player.UserId].WarningsStatus;
            Annunciator.Toggle(player);
            return Basic.AdminSettings[player.UserId].WarningsStatus ? "<color=green>Включено." : "<color=red>Выключено.";
        }
    }
}

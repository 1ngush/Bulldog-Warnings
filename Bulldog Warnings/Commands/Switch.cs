using CommandSystem;
using Exiled.API.Features;
using System;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Switch : ICommand
    {
        public string Command => "switch";
        public string[] Aliases => new string[] { "sw" };
        public string Description => "Локально переключает статусы обнаружения.";

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

            if (arguments.Count > 0 && (arguments.At(0).IndexOf("Off", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].SilentAim = false;
                Basic.AdminSettings[player.UserId].NoClipIteamStealer = false;
                Basic.AdminSettings[player.UserId].DoorManipulator = false;
                Basic.AdminSettings[player.UserId].ElevatorManipulator = false;
                Basic.AdminSettings[player.UserId].Genocide = false;
                Basic.AdminSettings[player.UserId].DoubleTap = false;
                Basic.AdminSettings[player.UserId].NoRecoil = false;

                response = "<color=red>Вы успешно выключили все локальные настройки.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("On", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].SilentAim = true;
                Basic.AdminSettings[player.UserId].NoClipIteamStealer = true;
                Basic.AdminSettings[player.UserId].DoorManipulator = true;
                Basic.AdminSettings[player.UserId].ElevatorManipulator = true;
                Basic.AdminSettings[player.UserId].Genocide = true;
                Basic.AdminSettings[player.UserId].DoubleTap = true;
                Basic.AdminSettings[player.UserId].NoRecoil = true;

                response = "<color=green>Вы успешно включили все локальные настройки.";
                return true;
            }

            if (arguments.Count <= 0)
            {
                response = $"Статус переключений [LOCAL]:\n{string.Format("Silent Aim = {0}\nNoClip IteamStealer = {1}\nDoor Manupulator = {2}\nElevator Manipulator = {3}\nGenocide = {4}\nDoubleTap = {5}\nNoRecoil = {6}\n\nИспользуйте: sw название", Basic.AdminSettings[player.UserId].SilentAim ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.AdminSettings[player.UserId].NoClipIteamStealer ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.AdminSettings[player.UserId].DoorManipulator ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.AdminSettings[player.UserId].ElevatorManipulator ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.AdminSettings[player.UserId].Genocide ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.AdminSettings[player.UserId].DoubleTap ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.AdminSettings[player.UserId].NoRecoil ? "<color=green>Включён</color>" : "<color=red>Выключен</color>")}";
                return true;
            }

            if (arguments.Count > 0 && (arguments.At(0).IndexOf("SilentAim", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("Silent", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("Salo", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].SilentAim = !Basic.AdminSettings[player.UserId].SilentAim;
                response = Basic.AdminSettings[player.UserId].SilentAim ? "[LOCAL] <color=green>Silent Aim успешно включён." : "[LOCAL] <color=red>Silent Aim успешно выключен.";
                return true;
            }

            if (arguments.Count > 0 && (arguments.At(0).IndexOf("NoClipIteamStealer", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("noclip", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("iteamstealer", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].NoClipIteamStealer = !Basic.AdminSettings[player.UserId].NoClipIteamStealer;
                response = Basic.AdminSettings[player.UserId].NoClipIteamStealer ? "[LOCAL] <color=green>NoClip IteamStealer успешно включён." : "[LOCAL] <color=red>NoClip IteamStealer успешно выключен.";
                return true;
            }

            if (arguments.Count > 0 && (arguments.At(0).IndexOf("DoorManipulator", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("door", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].DoorManipulator = !Basic.AdminSettings[player.UserId].DoorManipulator;
                response = Basic.AdminSettings[player.UserId].DoorManipulator ? "[LOCAL] <color=green>Door Manipulator успешно включён." : "[LOCAL] <color=red>Door Manipulator успешно выключен.";
                return true;
            }

            if (arguments.Count > 0 && (arguments.At(0).IndexOf("ElevatorManipulator", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("elevator", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].ElevatorManipulator = !Basic.AdminSettings[player.UserId].ElevatorManipulator;
                response = Basic.AdminSettings[player.UserId].ElevatorManipulator ? "[LOCAL] <color=green>Elevator Manipulator успешно включён." : "[LOCAL] <color=red>Elevator Manipulator успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("Genocide", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("gen", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].Genocide = !Basic.AdminSettings[player.UserId].Genocide;
                response = Basic.AdminSettings[player.UserId].Genocide ? "[LOCAL] <color=green>Genocide успешно включён." : "[LOCAL] <color=red>Genocide успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("DoubleTap", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("double", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].DoubleTap = !Basic.AdminSettings[player.UserId].DoubleTap;
                response = Basic.AdminSettings[player.UserId].DoubleTap ? "[LOCAL] <color=green>DoubleTap успешно включён." : "[LOCAL] <color=red>DoubleTap успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("NoRecoil", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("recoil", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.AdminSettings[player.UserId].NoRecoil = !Basic.AdminSettings[player.UserId].NoRecoil;
                response = Basic.AdminSettings[player.UserId].NoRecoil ? "[LOCAL] <color=green>NoRecoil успешно включён." : "[LOCAL] <color=red>NoRecoil успешно выключен.";
                return true;
            }
            response = "Вы ввели неправильное название.";
            return false;
        }
    }
}


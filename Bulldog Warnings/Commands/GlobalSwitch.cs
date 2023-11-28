using CommandSystem;
using Exiled.API.Features;
using System;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class GlobalSwitch : ICommand
    {
        public string Command => "globalswitch";
        public string[] Aliases => new string[] { "gsw" };
        public string Description => "Глобально переключает статусы обнаружения.";

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
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("Off", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.SilentAim = false;
                Basic.Configuration.NoClipIteamStealer = false;
                Basic.Configuration.DoorManipulator = false;
                Basic.Configuration.ElevatorManipulator = false;
                Basic.Configuration.Genocide = false;
                Basic.Configuration.DoubleTap = false;
                Basic.Configuration.NoRecoil = false;

                response = "<color=red>Вы успешно выключили все глобальные настройки.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("On", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.SilentAim = true;
                Basic.Configuration.NoClipIteamStealer = true;
                Basic.Configuration.DoorManipulator = true;
                Basic.Configuration.ElevatorManipulator = true;
                Basic.Configuration.Genocide = true;
                Basic.Configuration.DoubleTap = true;
                Basic.Configuration.NoRecoil = true;

                response = "<color=green>Вы успешно включили все глобальные настройки.";
                return true;
            }
            if (arguments.Count <= 0)
            {
                response = $"Статус переключений [GLOBAL]:\n<color=red>Имейте в виду, что настройки меняются только до рестарта.</color>\n{string.Format("Silent Aim = {0}\nNoClip IteamStealer = {1}\nDoor Manupulator = {2}\nElevator Manipulator = {3}\nGenocide = {4}\nDoubleTap = {5}\nNoRecoil = {6}\n\nИспользуйте: gsw название", Basic.Configuration.SilentAim ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.Configuration.NoClipIteamStealer ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.Configuration.DoorManipulator ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.Configuration.ElevatorManipulator ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.Configuration.Genocide ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.Configuration.DoubleTap ? "<color=green>Включён</color>" : "<color=red>Выключен</color>", Basic.Configuration.NoRecoil ? "<color=green>Включён</color>" : "<color=red>Выключен</color>")}";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("SilentAim", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("Silent", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("Salo", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.SilentAim = !Basic.Configuration.SilentAim;
                response = Basic.Configuration.SilentAim ? "[GLOBAL] <color=green>Silent Aim успешно включён." : "[GLOBAL] <color=red>Silent Aim успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("NoClipIteamStealer", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("noclip", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("iteamstealer", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.NoClipIteamStealer = !Basic.Configuration.NoClipIteamStealer;
                response = Basic.Configuration.NoClipIteamStealer ? "[GLOBAL] <color=green>NoClip IteamStealer успешно включён." : "[GLOBAL] <color=red>NoClip IteamStealer успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("DoorManipulator", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("door", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.DoorManipulator = !Basic.Configuration.DoorManipulator;
                response = Basic.Configuration.DoorManipulator ? "[GLOBAL] <color=green>Door Manipulator успешно включён." : "[GLOBAL] <color=red>Door Manipulator успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("ElevatorManipulator", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("elevator", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.ElevatorManipulator = !Basic.Configuration.ElevatorManipulator;
                response = Basic.Configuration.ElevatorManipulator ? "[GLOBAL] <color=green>Elevator Manipulator успешно включён." : "[GLOBAL] <color=red>Elevator Manipulator успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("Genocide", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("gen", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.Genocide = !Basic.Configuration.Genocide;
                response = Basic.Configuration.Genocide ? "[GLOBAL] <color=green>Genocide успешно включён." : "[GLOBAL] <color=red>Genocide успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("DoubleTap", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("double", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.DoubleTap = !Basic.Configuration.DoubleTap;
                response = Basic.Configuration.DoubleTap ? "[GLOBAL] <color=green>DoubleTap успешно включён." : "[GLOBAL] <color=red>DoubleTap успешно выключен.";
                return true;
            }
            if (arguments.Count > 0 && (arguments.At(0).IndexOf("NoRecoil", StringComparison.OrdinalIgnoreCase) != -1 || arguments.At(0).IndexOf("recoil", StringComparison.OrdinalIgnoreCase) != -1))
            {
                Basic.Configuration.NoRecoil = !Basic.Configuration.NoRecoil;
                response = Basic.Configuration.NoRecoil ? "[GLOBAL] <color=green>NoRecoil успешно включён." : "[GLOBAL] <color=red>NoRecoil успешно выключен.";
                return true;
            }
            response = "Вы ввели неправильное название.";
            return false;
        }
    }
}

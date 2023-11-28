using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Bulldog_Warnings.Configs
{
    public class Config : IConfig
    {
        [Description("Указывает, включён ли плагин.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Debug-mode")]
        public bool Debug { get; set; } = false;

        [Description("Указывает, нужно ли ограничивать дальность видимости предметов.")]
        public bool IsItemsLimiting { get; set; } = false;
        [Description("Дистанция в метрах ограничения видимости предметов.")]
        public float IsItemsLimitingDistance { get; set; } = 30f;
        [Description("Указывает, нужно ли получать варнинги от администрации.")]
        public string ConsoleMessage { get; set; } = $"У игрока %name%[%id%] подозрение на %reason%, на него уже %count% жалоб!";
        [Description("Показывать ли подсказку для варнинга.")]
        public bool ShowHint { get; set; } = true;
        [Description("Текст для показа администрации в виде подсказки.")]
        public string HintMessage { get; set; } = "Пришёл варнинг. Проверьте админ-консоль.";
        [Description("Автоматические очищение жалоб после завершения раунда.")]
        public bool AutoClearReportsAfterRound { get; set; } = true;
        [Description("Статус варнингов Silent Aim.")]
        public bool SilentAim { get; set; } = true;
        [Description("Статус варнингов NoClip IteamStealer.")]
        public bool NoClipIteamStealer { get; set; } = true;
        [Description("Статус варнингов Door Manipulator.")]
        public bool DoorManipulator { get; set; } = true;
        [Description("Статус варнингов Elevator Manipulator.")]
        public bool ElevatorManipulator { get; set; } = true;
        [Description("Статус варнингов Genocide.")]
        public bool Genocide { get; set; } = true;
        [Description("Количество убийств для варнинга.")]
        public int GenocideCount { get; set; } = 3;
        [Description("Время, за которое должны произойти убийства для варнинга.")]
        public float GenocideTimeInSec { get; set; } = 30f;
        [Description("Статус варнингов DoubleTap.")]
        public bool DoubleTap { get; set; } = true;
        [Description("Порог времени выстрела для срабатывания.")]
        public float DoubleTapThreshold { get; set; } = 0.01f;
        [Description("Статус варнингов NoRecoil.")]
        public bool NoRecoil { get; set; } = true;
    }
}

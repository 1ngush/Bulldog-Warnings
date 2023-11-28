// Basic.cs
using Bulldog_Warnings.Commands;
using Bulldog_Warnings.Configs;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Events.Commands.Config;
using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bulldog_Warnings
{
    public class ViolationInfo
    {
        public string Reason { get; set; }
        public int Count { get; set; }
    }

    public class AdminSettings
    {
        public bool WarningsStatus { get; set; } = false;
        public bool ShowHint { get; set; } = true;
        public bool SilentAim { get; set; } = true;
        public bool NoClipIteamStealer { get; set; } = true;
        public bool DoorManipulator { get; set; } = true;
        public bool ElevatorManipulator { get; set; } = true;
        public bool Genocide { get; set; } = true;
        public bool DoubleTap { get; set; } = true;
        public bool NoRecoil { get; set; } = true;
    }
    public class ShotInfo
    {
        public DateTime LastTime { get; set; }
        public int ShotCount { get; set; }
        public Quaternion LastShooterCameraRotation { get; set; }
    }

    public class Basic : Plugin<Config>
    {
        internal static EventHandlers EventHandlers;
        // perems
        internal static bool waitForUpdate = true;
        //arrays
        internal static Dictionary<string, AdminSettings> AdminSettings = new();
        internal static Dictionary<Player, ViolationInfo> Violators = new();
        //
        internal static Dictionary<Player, (int count, float lastKillTime)> killCounts = new();
        internal static readonly Dictionary<Player, ShotInfo> doubleTapInfo = new();
        internal static readonly Dictionary<Player, ShotInfo> noRecoilInfo = new();
        //
        internal static readonly List<Pickup> disabledPickups = new();
        //config
        internal static Config Configuration = new();

        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers();

            Exiled.Events.Handlers.Player.Hurting += EventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.PickingUpItem += EventHandlers.OnPickingUpItem;
            Exiled.Events.Handlers.Player.InteractingDoor += EventHandlers.OnInteractingDoor;
            Exiled.Events.Handlers.Player.InteractingElevator += EventHandlers.OnInteractingElevator;
            Exiled.Events.Handlers.Player.Died += EventHandlers.OnDied;
            Exiled.Events.Handlers.Player.Shooting += EventHandlers.OnShooting;

            Exiled.Events.Handlers.Server.ReloadedConfigs += OnReloadedConfigs;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += EventHandlers.OnRoundEnded;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Hurting -= EventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.PickingUpItem -= EventHandlers.OnPickingUpItem;
            Exiled.Events.Handlers.Player.InteractingDoor -= EventHandlers.OnInteractingDoor;
            Exiled.Events.Handlers.Player.InteractingElevator -= EventHandlers.OnInteractingElevator;
            Exiled.Events.Handlers.Player.Died -= EventHandlers.OnDied;
            Exiled.Events.Handlers.Player.Shooting -= EventHandlers.OnShooting;

            Exiled.Events.Handlers.Server.ReloadedConfigs -= OnReloadedConfigs;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= EventHandlers.OnRoundEnded;

            EventHandlers = null;
            base.OnDisabled();
        }
        public void OnRoundStarted()
        {
            Configuration = Config;
            if (Configuration.IsItemsLimiting)
            {
                Timing.RunCoroutine(Loot.T());
            }
        }
        public void OnReloadedConfigs()
        {
            Configuration = Config;
        }
    }
}

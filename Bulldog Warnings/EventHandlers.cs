using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;
using System;
using System.Linq;
using UnityEngine;

namespace Bulldog_Warnings
{
    public class EventHandlers
    {
        internal static DamageType[] WeaponsCheck =
        {
            DamageType.Com15, DamageType.Com18, DamageType.Com45,
            DamageType.AK, DamageType.Fsp9, DamageType.Crossvec,
            DamageType.Shotgun, DamageType.Revolver, DamageType.Logicer,
            DamageType.E11Sr, DamageType.A7, DamageType.Frmg0
        };

        public void OnHurting(HurtingEventArgs ev)
        {
            if (WeaponsCheck.Contains(ev.DamageHandler.Type) && Basic.Configuration.SilentAim)
            {
                Timing.CallDelayed(Timing.WaitForOneFrame, () =>
                {
                    var hits = Physics.RaycastAll(ev.Attacker.CameraTransform.position, ev.Attacker.CameraTransform.forward)
                                    .OrderBy(hit => hit.distance);

                    bool playerHit = hits.Any(hit => Player.TryGet(hit.collider, out var player) && player != ev.Attacker);

                    if (!playerHit)
                        HandleViolation(ev.Attacker, "Silent Aim");
                });
            }
        }

        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (Basic.Configuration.NoClipIteamStealer)
            {
                var hits = Physics.RaycastAll(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward);
                Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
                bool collidedWithItem = false;

                foreach (var hit in hits)
                {
                    if (Player.TryGet(hit.collider, out _))
                        continue;
                    try
                    {
                        Pickup.Get(hit.rigidbody.gameObject);
                        collidedWithItem = true;
                        break;
                    } catch { }
                }
                if (!collidedWithItem)
                    HandleViolation(ev.Player, "NoClip ItemStealer");
            }
        }
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (Basic.Configuration.DoorManipulator)
            {
                var hits = Physics.RaycastAll(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward);
                Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
                bool collidedWithDoor = false;

                foreach (var hit in hits)
                {
                    if (Player.TryGet(hit.collider, out _))
                        continue;

                    if (hit.collider.name.Contains("Door") || hit.collider.tag.Contains("Door") || hit.collider.tag.Contains("DoorButton") || hit.collider.name == "collider")
                    {
                        collidedWithDoor = true;
                        break;
                    }
                }
                if (!collidedWithDoor)
                    HandleViolation(ev.Player, "Door Manipulator");
            }
        }

        public void OnInteractingElevator(InteractingElevatorEventArgs ev)
        {
            if (Basic.Configuration.ElevatorManipulator)
            {
                var hits = Physics.RaycastAll(ev.Player.CameraTransform.position, ev.Player.CameraTransform.forward);
                Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
                bool collidedWithElevator = false;

                foreach (var hit in hits)
                {
                    if (Player.TryGet(hit.collider, out _))
                        continue;

                    if (hit.collider.name.Contains("Panel"))
                    {
                        collidedWithElevator = true;
                        break;
                    }
                }
                if (!collidedWithElevator)
                    HandleViolation(ev.Player, "Elevator Manipulator");
            }
        }

        public void OnDied(DiedEventArgs ev)
        {
            if (ev.Attacker == null)
                return;

            if (Basic.Configuration.Genocide)
            {
                if (Basic.killCounts.TryGetValue(ev.Attacker, out var killInfo))
                {
                    if (Time.time - killInfo.lastKillTime < Basic.Configuration.GenocideTimeInSec)
                    {
                        Basic.killCounts[ev.Attacker] = (killInfo.count + 1, Time.time);

                        if (killInfo.count + 1 >= Basic.Configuration.GenocideCount)
                        {
                            HandleViolation(ev.Attacker, "Genocide");
                        }
                    }
                    else
                    {
                        Basic.killCounts[ev.Attacker] = (1, Time.time);
                    }
                }
                else
                {
                    Basic.killCounts[ev.Attacker] = (1, Time.time);
                }
            }
        }

        public void OnShooting(ShootingEventArgs ev)
        {
            if (Basic.Configuration.DoubleTap)
            {
                if (!Basic.doubleTapInfo.TryGetValue(ev.Player, out var shotInfo))
                {
                    shotInfo ??= new ShotInfo();
                    Basic.doubleTapInfo[ev.Player] = shotInfo;
                }
                if ((DateTime.Now - shotInfo.LastTime).TotalSeconds < Basic.Configuration.DoubleTapThreshold)
                {
                    shotInfo.ShotCount++;
                    if (shotInfo.ShotCount >= 2)
                    {
                        HandleViolation(ev.Player, "DoubleTap");
                        shotInfo.ShotCount = 0;
                    }
                }
                else
                {
                    shotInfo.ShotCount = 1;
                }
                shotInfo.LastTime = DateTime.Now;
            }
            if (Basic.Configuration.NoRecoil)
            {
                if (!Basic.noRecoilInfo.TryGetValue(ev.Player, out var shotInfo))
                {
                    shotInfo ??= new ShotInfo();
                    Basic.noRecoilInfo[ev.Player] = shotInfo;
                }
                if (Basic.noRecoilInfo.TryGetValue(ev.Player, out shotInfo) && Equals(ev.ShotMessage.ShooterCameraRotation, shotInfo.LastShooterCameraRotation))
                {
                    HandleViolation(ev.Player, "NoRecoil");
                }
                if (Basic.noRecoilInfo.TryGetValue(ev.Player, out shotInfo))
                {
                    shotInfo.LastShooterCameraRotation = ev.ShotMessage.ShooterCameraRotation;
                }
            }
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (Basic.Configuration.AutoClearReportsAfterRound)
            {
                Basic.Violators.Clear();
            }
            Basic.killCounts.Clear();
        }
       

        private void HandleViolation(Player player, string reason)
        {
            if (Basic.Violators.TryGetValue(player, out var violationInfo))
            {
                violationInfo.Count++;
                violationInfo.Reason = reason;
            }
            else
            {
                Basic.Violators[player] = new ViolationInfo { Reason = reason, Count = 1 };
            }

            Basic.waitForUpdate = false;
        }
    }
}

using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;

namespace Bulldog_Warnings.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Debug : ICommand
    {
        private readonly Dictionary<string, string> savedData = new();

        public string Command => "debug";
        public string[] Aliases => new string[] { "db" };
        public string Description => "debug";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.AdminChat))
            {
                response = "Вам не выдали доступа для использования этой команды.";
                return true;
            }

            if (!Player.TryGet(sender, out var player))
            {
                response = "пошёл нахуй";
                return true;
            }
            if (arguments.Count > 0 && arguments.At(0) == "1")
            {
                SaveData(player);
                response = "Аргументы 1 сохранены.";
                return true;
            }

            if (arguments.Count > 0 && arguments.At(0) == "2")
            {
                response = CompareData(player);
                return true;
            }

            response = "Используйте debug 1";
            return false;
        }

        private void SaveData(Player player)
        {
            savedData.Clear();
            AddProperty("ActiveArtificialHealthProcesses", player.ActiveArtificialHealthProcesses.ToString());
            AddProperty("ActiveEffects", player.ActiveEffects?.ToString());
            AddProperty("AdminChatAccess", player.AdminChatAccess.ToString());
            AddProperty("AgreedToRecording", player.AgreedToRecording.ToString());
            AddProperty("Ammo", player.Ammo?.ToString());
            AddProperty("ArtificialHealth", player.ArtificialHealth.ToString());
            AddProperty("AuthenticationToken", player.AuthenticationToken?.ToString());
            AddProperty("AuthenticationType", player.AuthenticationType.ToString());
            AddProperty("BadgeHidden", player.BadgeHidden.ToString());
            //AddProperty("CameraTransform_childCount", player.CameraTransform?.childCount.ToString());
            //AddProperty("CameraTransform_eulerAngles", player.CameraTransform?.eulerAngles.ToString());
            //AddProperty("CameraTransform_forward", player.CameraTransform?.forward.ToString());
            //AddProperty("CameraTransform_gameObject", player.CameraTransform?.gameObject?.ToString());
            //AddProperty("CameraTransform_hasChanged", player.CameraTransform?.hasChanged.ToString());
            //AddProperty("CameraTransform_hideFlags", player.CameraTransform?.hideFlags.ToString());
            //AddProperty("CameraTransform_hierarchyCapacity", player.CameraTransform?.hierarchyCapacity.ToString());
            //AddProperty("CameraTransform_hierarchyCount", player.CameraTransform?.hierarchyCount.ToString());
            //AddProperty("CameraTransform_localEulerAngles", player.CameraTransform?.localEulerAngles.ToString());
            //AddProperty("CameraTransform_localPosition", player.CameraTransform?.localPosition.ToString());
            //AddProperty("CameraTransform_localRotation", player.CameraTransform?.localRotation.ToString());
            //AddProperty("CameraTransform_localScale", player.CameraTransform?.localScale.ToString());
            //AddProperty("CameraTransform_localToWorldMatrix", player.CameraTransform?.localToWorldMatrix.ToString());
            //AddProperty("CameraTransform_lossyScale", player.CameraTransform?.lossyScale.ToString());
            //AddProperty("CameraTransform_name", player.CameraTransform?.name?.ToString());
            //AddProperty("CameraTransform_parent", player.CameraTransform?.parent?.ToString());
            //AddProperty("CameraTransform_position", player.CameraTransform?.position.ToString());
            //AddProperty("CameraTransform_right", player.CameraTransform?.right.ToString());
            //AddProperty("CameraTransform_root", player.CameraTransform?.root?.ToString());
            //AddProperty("CameraTransform_rotation", player.CameraTransform?.rotation.ToString());
            //AddProperty("CameraTransform_tag", player.CameraTransform?.tag?.ToString());
            //AddProperty("CameraTransform_transform", player.CameraTransform?.transform?.ToString());
            //AddProperty("CameraTransform_up", player.CameraTransform?.up.ToString());
            //AddProperty("CameraTransform_worldToLocalMatrix_decomposeProjection_determinant", player.CameraTransform?.worldToLocalMatrix.determinant.ToString());
            //AddProperty("CameraTransform_worldToLocalMatrix_decomposeProjection_isIdentity", player.CameraTransform?.worldToLocalMatrix.isIdentity.ToString());
            //AddProperty("CameraTransform_worldToLocalMatrix_decomposeProjection_lossyScale", player.CameraTransform?.worldToLocalMatrix.lossyScale.ToString());
            //AddProperty("CameraTransform_worldToLocalMatrix_decomposeProjection_rotation", player.CameraTransform?.worldToLocalMatrix.rotation.ToString());
            //AddProperty("CameraTransform_localToWorldMatrix_decomposeProjection_determinant", player.CameraTransform?.localToWorldMatrix.determinant.ToString());
            //AddProperty("CameraTransform_localToWorldMatrix_decomposeProjection_isIdentity", player.CameraTransform?.localToWorldMatrix.isIdentity.ToString());
            //AddProperty("CameraTransform_localToWorldMatrix_decomposeProjection_lossyScale", player.CameraTransform?.localToWorldMatrix.lossyScale.ToString());
            //AddProperty("CameraTransform_localToWorldMatrix_decomposeProjection_rotation", player.CameraTransform?.localToWorldMatrix.rotation.ToString());
            AddProperty("ComponentsInChildren", player.ComponentsInChildren?.ToString());
            AddProperty("Connection", player.Connection?.ToString());
            AddProperty("Cuffer", player.Cuffer?.ToString());
            AddProperty("CurrentArmor", player.CurrentArmor?.ToString());
            //AddProperty("CurrentHint", player.CurrentHint?.ToString());
            AddProperty("CurrentItem", player.CurrentItem?.ToString());
            AddProperty("CurrentRoom", player.CurrentRoom?.ToString());
            AddProperty("CurrentSpectatingPlayers", player.CurrentSpectatingPlayers?.ToString());
            AddProperty("CustomInfo", player.CustomInfo?.ToString());
            AddProperty("CustomName", player.CustomName?.ToString());
            AddProperty("CustomRoleFriendlyFireMultiplier", player.CustomRoleFriendlyFireMultiplier?.ToString());
            AddProperty("DisplayNickname", player.DisplayNickname?.ToString());
            AddProperty("DoNotTrack", player.DoNotTrack.ToString());
            AddProperty("Footprint", player.Footprint.ToString());
            AddProperty("FriendlyFireMultiplier", player.FriendlyFireMultiplier?.ToString());
            AddProperty("GameObjectActiveInHierarchy", player.GameObject?.activeInHierarchy.ToString());
            AddProperty("GameObjectActiveSelf", player.GameObject?.activeSelf.ToString());
            AddProperty("GameObjectHideFlags", player.GameObject?.hideFlags.ToString());
            AddProperty("GameObjectIsStatic", player.GameObject?.isStatic.ToString());
            AddProperty("GameObjectLayer", player.GameObject?.layer.ToString());
            AddProperty("GameObjectName", player.GameObject?.name?.ToString());
            AddProperty("GameObjectScene", player.GameObject?.scene.ToString());
            AddProperty("GameObjectSceneCullingMask", player.GameObject?.sceneCullingMask.ToString());
            AddProperty("GameObjectTag", player.GameObject?.tag?.ToString());
            //AddProperty("GameObjectTransformChildCount", player.GameObject?.transform?.childCount.ToString());
            //AddProperty("GameObjectTransformEulerAngles", player.GameObject?.transform?.eulerAngles.ToString());
            //AddProperty("GameObjectTransformForward", player.GameObject?.transform?.forward.ToString());
            //AddProperty("GameObjectTransformGameObject", player.GameObject?.transform?.gameObject.ToString());
            //AddProperty("GameObjectTransformHasChanged", player.GameObject?.transform?.hasChanged.ToString());
            //AddProperty("GameObjectTransformHideFlags", player.GameObject?.transform?.hideFlags.ToString());
            //AddProperty("GameObjectTransformHierarchyCapacity", player.GameObject?.transform?.hierarchyCapacity.ToString());
            //AddProperty("GameObjectTransformHierarchyCount", player.GameObject?.transform?.hierarchyCount.ToString());
            //AddProperty("GameObjectTransformLocalEulerAngles", player.GameObject?.transform?.localEulerAngles.ToString());
            //AddProperty("GameObjectTransformLocalPosition", player.GameObject?.transform?.localPosition.ToString());
            //AddProperty("GameObjectTransformLocalRotation", player.GameObject?.transform?.localRotation.ToString());
            //AddProperty("GameObjectTransformLocalScale", player.GameObject?.transform?.localScale.ToString());
            //AddProperty("GameObjectWorldToLocalMatrixDecomposeProjectionBottom", player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.bottom.ToString());
            //AddProperty("GameObjectWorldToLocalMatrixDecomposeProjectionLeft", player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.left.ToString());
            //AddProperty("GameObjectWorldToLocalMatrixDecomposeProjectionRight", player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.right.ToString());
            //AddProperty("GameObjectWorldToLocalMatrixDecomposeProjectionTop", player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.top.ToString());
            //AddProperty("GameObjectWorldToLocalMatrixDecomposeProjectionZFar", player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.zFar.ToString());
            //AddProperty("GameObjectWorldToLocalMatrixDecomposeProjectionZNear", player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.zNear.ToString());
            AddProperty("Group", player.Group?.ToString());
            AddProperty("GroupName", player.GroupName?.ToString());
            AddProperty("HasCustomName", player.HasCustomName.ToString());
            AddProperty("HasFlashlightModuleEnabled", player.HasFlashlightModuleEnabled.ToString());
            AddProperty("HasHint", player.HasHint.ToString());
            AddProperty("HasReservedSlot", player.HasReservedSlot.ToString());
            AddProperty("Health", player.Health.ToString());
            AddProperty("HintDisplay", player.HintDisplay.ToString());
            AddProperty("HumeShield", player.HumeShield.ToString());
            AddProperty("HumeShieldStat", player.HumeShieldStat?.ToString());
            AddProperty("Id", player.Id.ToString());
            AddProperty("InfoArea", player.InfoArea.ToString());
            AddProperty("InfoViewRange", player.InfoViewRange.ToString());
            AddProperty("Inventory", player.Inventory?.ToString());
            AddProperty("IPAddress", player.IPAddress?.ToString());
            AddProperty("IsAimingDownWeapon", player.IsAimingDownWeapon.ToString());
            AddProperty("IsAlive", player.IsAlive.ToString());
            AddProperty("IsBypassModeEnabled", player.IsBypassModeEnabled.ToString());
            AddProperty("IsCHI", player.IsCHI.ToString());
            AddProperty("IsConnected", player.IsConnected.ToString());
            AddProperty("IsCuffed", player.IsCuffed.ToString());
            AddProperty("IsDead", player.IsDead.ToString());
            AddProperty("IsFriendlyFireEnabled", player.IsFriendlyFireEnabled.ToString());
            AddProperty("IsGlobalModerator", player.IsGlobalModerator.ToString());
            AddProperty("IsGlobalMuted", player.IsGlobalMuted.ToString());
            AddProperty("IsGodModeEnabled", player.IsGodModeEnabled.ToString());
            AddProperty("IsHost", player.IsHost.ToString());
            AddProperty("IsHuman", player.IsHuman.ToString());
            AddProperty("IsInPocketDimension", player.IsInPocketDimension.ToString());
            AddProperty("IsIntercomMuted", player.IsIntercomMuted.ToString());
            AddProperty("IsInventoryEmpty", player.IsInventoryEmpty.ToString());
            AddProperty("IsInventoryFull", player.IsInventoryFull.ToString());
            AddProperty("IsJumping", player.IsJumping.ToString());
            AddProperty("IsMuted", player.IsMuted.ToString());
            AddProperty("IsNoclipPermitted", player.IsNoclipPermitted.ToString());
            AddProperty("IsNorthwoodStaff", player.IsNorthwoodStaff.ToString());
            AddProperty("IsNPC", player.IsNPC.ToString());
            AddProperty("IsNTF", player.IsNTF.ToString());
            AddProperty("IsOverwatchEnabled", player.IsOverwatchEnabled.ToString());
            AddProperty("IsReloading", player.IsReloading.ToString());
            AddProperty("IsScp", player.IsScp.ToString());
            AddProperty("IsSpawnProtected", player.IsSpawnProtected.ToString());
            AddProperty("IsSpeaking", player.IsSpeaking.ToString());
            AddProperty("IsStaffBypassEnabled", player.IsStaffBypassEnabled.ToString());
            AddProperty("IsTransmitting", player.IsTransmitting.ToString());
            AddProperty("IsTutorial", player.IsTutorial.ToString());
            AddProperty("IsUsingStamina", player.IsUsingStamina.ToString());
            AddProperty("IsVerified", player.IsVerified.ToString());
            AddProperty("IsWhitelisted", player.IsWhitelisted.ToString());
            AddProperty("Items", player.Items?.ToString());
            AddProperty("KickPower", player.KickPower.ToString());
            AddProperty("LeadingTeam", player.LeadingTeam.ToString());
            AddProperty("Lift", player.Lift?.ToString());
            AddProperty("MaxArtificialHealth", player.MaxArtificialHealth.ToString());
            AddProperty("MaxHealth", player.MaxHealth.ToString());
            AddProperty("NetId", player.NetId.ToString());
            AddProperty("NetworkIdentity", player.NetworkIdentity?.ToString());
            AddProperty("Nickname", player.Nickname?.ToString());
            AddProperty("Ping", player.Ping.ToString());
            AddProperty("Position", player.Position.ToString());
            AddProperty("Preferences", player.Preferences?.ToString());
            AddProperty("RadioPlayback", player.RadioPlayback?.ToString());
            AddProperty("RankColor", player.RankColor?.ToString());
            AddProperty("RankName", player.RankName?.ToString());
            AddProperty("RawUserId", player.RawUserId?.ToString());
            AddProperty("ReferenceHubAuthority", player.ReferenceHub?.authority.ToString());
            AddProperty("ReferenceHubComponentIndex", player.ReferenceHub?.ComponentIndex.ToString());
            AddProperty("ReferenceHubConnectionToClient", player.ReferenceHub?.connectionToClient?.ToString());
            AddProperty("ReferenceHubConnectionToServer", player.ReferenceHub?.connectionToServer?.ToString());
            AddProperty("ReferenceHubEnabled", player.ReferenceHub?.enabled.ToString());
            AddProperty("ReferenceHubHasAuthority", player.ReferenceHub?.hasAuthority.ToString());
            AddProperty("ReferenceHubHideFlags", player.ReferenceHub?.hideFlags.ToString());
            AddProperty("ReferenceHubIsActiveAndEnabled", player.ReferenceHub?.isActiveAndEnabled.ToString());
            AddProperty("ReferenceHubIsClient", player.ReferenceHub?.isClient.ToString());
            AddProperty("ReferenceHubIsClientOnly", player.ReferenceHub?.isClientOnly.ToString());
            AddProperty("ReferenceHubIsHost", player.ReferenceHub?.IsHost.ToString());
            AddProperty("ReferenceHubIsLocalPlayer", player.ReferenceHub?.isLocalPlayer.ToString());
            AddProperty("ReferenceHubIsOwned", player.ReferenceHub?.isOwned.ToString());
            AddProperty("ReferenceHubIsServer", player.ReferenceHub?.isServer.ToString());
            AddProperty("ReferenceHubIsServerOnly", player.ReferenceHub?.isServerOnly.ToString());
            AddProperty("ReferenceHubMode", player.ReferenceHub?.Mode.ToString());
            AddProperty("ReferenceHubName", player.ReferenceHub?.name?.ToString());
            AddProperty("ReferenceHubNetId", player.ReferenceHub?.netId.ToString());
            AddProperty("ReferenceHubNetIdentity", player.ReferenceHub?.netIdentity?.ToString());
            AddProperty("ReferenceHubNetworkPlayerId", player.ReferenceHub?.Network_playerId.ToString());
            AddProperty("ReferenceHubPlayerId", player.ReferenceHub?.PlayerId.ToString());
            AddProperty("ReferenceHubTag", player.ReferenceHub?.tag?.ToString());
            AddProperty("ReferenceHubTransform", player.ReferenceHub?.transform?.ToString());
            AddProperty("ReferenceHubUseGUILayout", player.ReferenceHub?.useGUILayout.ToString());
            AddProperty("RelativePosition", player.RelativePosition.ToString());
            AddProperty("RemoteAdminAccess", player.RemoteAdminAccess.ToString());
            AddProperty("RemoteAdminPermissions", player.RemoteAdminPermissions.ToString());
            AddProperty("Role", player.Role?.ToString());
            AddProperty("RoleManager", player.RoleManager?.ToString());
            AddProperty("Rotation", player.Rotation.ToString());
            AddProperty("Scale", player.Scale.ToString());
            AddProperty("ScpPreferences", player.ScpPreferences.ToString());
            AddProperty("Sender", player.Sender?.ToString());
            AddProperty("SessionVariables", player.SessionVariables?.ToString());
            AddProperty("Stamina", player.Stamina.ToString());
            AddProperty("StaminaStat", player.StaminaStat?.ToString());
            //AddProperty("TransformChildCount", player.Transform?.childCount.ToString());
            //AddProperty("TransformEulerAngles", player.Transform?.eulerAngles.ToString());
            //AddProperty("TransformForward", player.Transform?.forward.ToString());
            //AddProperty("TransformGameObject", player.Transform?.gameObject?.ToString());
            //AddProperty("TransformHasChanged", player.Transform?.hasChanged.ToString());
            //AddProperty("TransformHideFlags", player.Transform?.hideFlags.ToString());
            //AddProperty("TransformHierarchyCapacity", player.Transform?.hierarchyCapacity.ToString());
            //AddProperty("TransformHierarchyCount", player.Transform?.hierarchyCount.ToString());
            //AddProperty("TransformLocalEulerAngles", player.Transform?.localEulerAngles.ToString());
            //AddProperty("TransformLocalPosition", player.Transform?.localPosition.ToString());
            //AddProperty("TransformLocalRotation", player.Transform?.localRotation.ToString());
            //AddProperty("TransformLocalScale", player.Transform?.localScale.ToString());
            //AddProperty("TransformName", player.Transform?.name?.ToString());
            //AddProperty("TransformRight", player.Transform?.right.ToString());
            AddProperty("UniqueRole", player.UniqueRole?.ToString());
            AddProperty("UnitId", player.UnitId.ToString());
            AddProperty("UnitName", player.UnitName?.ToString());
            AddProperty("UserId", player.UserId?.ToString());
            AddProperty("Velocity", player.Velocity.ToString());
            AddProperty("VoiceChannel", player.VoiceChannel.ToString());
            AddProperty("VoiceChatMuteFlags", player.VoiceChatMuteFlags.ToString());
            AddProperty("VoiceColor", player.VoiceColor.ToString());
            AddProperty("VoiceModule", player.VoiceModule?.ToString());
            AddProperty("Zone", player.Zone.ToString());
        }

        private string CompareData(Player player)
        {
            if (savedData.Count == 0)
                return "Сначала сохраните данные с помощью debug 1.";

            string difference = "Разница:\n";

            foreach (var kvp in savedData)
            {
                string currentValue = GetPlayerPropertyValue(player, kvp.Key);
                if (currentValue != kvp.Value)
                    difference += $"{kvp.Key}: {kvp.Value} -> {currentValue}\n";
            }

            return difference;
        }

        private void AddProperty(string propertyName, string value)
        {
            if (value != null)
                savedData.Add(propertyName, value);
        }

        private string GetPlayerPropertyValue(Player player, string propertyName)
        {
            switch (propertyName)
            {
                // Player
                case "ActiveArtificialHealthProcesses":
                    return player.ActiveArtificialHealthProcesses.ToString();
                case "ActiveEffects":
                    return player.ActiveEffects?.ToString();
                case "AdminChatAccess":
                    return player.AdminChatAccess.ToString();
                case "AgreedToRecording":
                    return player.AgreedToRecording.ToString();
                case "Ammo":
                    return player.Ammo?.ToString();
                case "ArtificialHealth":
                    return player.ArtificialHealth.ToString();
                case "AuthenticationToken":
                    return player.AuthenticationToken?.ToString();
                case "AuthenticationType":
                    return player.AuthenticationType.ToString();
                case "BadgeHidden":
                    return player.BadgeHidden.ToString();
                case "CameraTransform_childCount":
                    return player.CameraTransform?.childCount.ToString();
                case "CameraTransform_eulerAngles":
                    return player.CameraTransform?.eulerAngles.ToString();
                case "CameraTransform_forward":
                    return player.CameraTransform?.forward.ToString();
                case "CameraTransform_gameObject":
                    return player.CameraTransform?.gameObject?.ToString();
                case "CameraTransform_hasChanged":
                    return player.CameraTransform?.hasChanged.ToString();
                case "CameraTransform_hideFlags":
                    return player.CameraTransform?.hideFlags.ToString();
                case "CameraTransform_hierarchyCapacity":
                    return player.CameraTransform?.hierarchyCapacity.ToString();
                case "CameraTransform_hierarchyCount":
                    return player.CameraTransform?.hierarchyCount.ToString();
                case "CameraTransform_localEulerAngles":
                    return player.CameraTransform?.localEulerAngles.ToString();
                case "CameraTransform_localPosition":
                    return player.CameraTransform?.localPosition.ToString();
                case "CameraTransform_localRotation":
                    return player.CameraTransform?.localRotation.ToString();
                case "CameraTransform_localScale":
                    return player.CameraTransform?.localScale.ToString();
                case "CameraTransform_localToWorldMatrix":
                    return player.CameraTransform?.localToWorldMatrix.ToString();
                case "CameraTransform_lossyScale":
                    return player.CameraTransform?.lossyScale.ToString();
                case "CameraTransform_name":
                    return player.CameraTransform?.name?.ToString();
                case "CameraTransform_parent":
                    return player.CameraTransform?.parent?.ToString();
                case "CameraTransform_position":
                    return player.CameraTransform?.position.ToString();
                case "CameraTransform_right":
                    return player.CameraTransform?.right.ToString();
                case "CameraTransform_root":
                    return player.CameraTransform?.root?.ToString();
                case "CameraTransform_rotation":
                    return player.CameraTransform?.rotation.ToString();
                case "CameraTransform_tag":
                    return player.CameraTransform?.tag?.ToString();
                case "CameraTransform_transform":
                    return player.CameraTransform?.transform?.ToString();
                case "CameraTransform_up":
                    return player.CameraTransform?.up.ToString();
                case "CameraTransform_worldToLocalMatrix_decomposeProjection_determinant":
                    return player.CameraTransform?.worldToLocalMatrix.determinant.ToString();
                case "CameraTransform_worldToLocalMatrix_decomposeProjection_isIdentity":
                    return player.CameraTransform?.worldToLocalMatrix.isIdentity.ToString();
                case "CameraTransform_worldToLocalMatrix_decomposeProjection_lossyScale":
                    return player.CameraTransform?.worldToLocalMatrix.lossyScale.ToString();
                case "CameraTransform_worldToLocalMatrix_decomposeProjection_rotation":
                    return player.CameraTransform?.worldToLocalMatrix.rotation.ToString();
                case "CameraTransform_localToWorldMatrix_decomposeProjection_determinant":
                    return player.CameraTransform?.localToWorldMatrix.determinant.ToString();
                case "CameraTransform_localToWorldMatrix_decomposeProjection_isIdentity":
                    return player.CameraTransform?.localToWorldMatrix.isIdentity.ToString();
                case "CameraTransform_localToWorldMatrix_decomposeProjection_lossyScale":
                    return player.CameraTransform?.localToWorldMatrix.lossyScale.ToString();
                case "CameraTransform_localToWorldMatrix_decomposeProjection_rotation":
                    return player.CameraTransform?.localToWorldMatrix.rotation.ToString();
                case "ComponentsInChildren":
                    return player.ComponentsInChildren?.ToString();
                case "Connection":
                    return player.Connection?.ToString();
                case "Cuffer":
                    return player.Cuffer?.ToString();
                case "CurrentArmor":
                    return player.CurrentArmor?.ToString();
                case "CurrentHint":
                    return player.CurrentHint?.ToString();
                case "CurrentItem":
                    return player.CurrentItem?.ToString();
                case "CurrentRoom":
                    return player.CurrentRoom?.ToString();
                case "CurrentSpectatingPlayers":
                    return player.CurrentSpectatingPlayers?.ToString();
                case "CustomInfo":
                    return player.CustomInfo?.ToString();
                case "CustomName":
                    return player.CustomName?.ToString();
                case "CustomRoleFriendlyFireMultiplier":
                    return player.CustomRoleFriendlyFireMultiplier?.ToString();
                case "DisplayNickname":
                    return player.DisplayNickname?.ToString();
                case "DoNotTrack":
                    return player.DoNotTrack.ToString();
                case "Footprint":
                    return player.Footprint.ToString();
                case "FriendlyFireMultiplier":
                    return player.FriendlyFireMultiplier?.ToString();
                case "GameObjectActiveInHierarchy":
                    return player.GameObject?.activeInHierarchy.ToString();
                case "GameObjectActiveSelf":
                    return player.GameObject?.activeSelf.ToString();
                case "GameObjectHideFlags":
                    return player.GameObject?.hideFlags.ToString();
                case "GameObjectIsStatic":
                    return player.GameObject?.isStatic.ToString();
                case "GameObjectLayer":
                    return player.GameObject?.layer.ToString();
                case "GameObjectName":
                    return player.GameObject?.name?.ToString();
                case "GameObjectScene":
                    return player.GameObject?.scene.ToString();
                case "GameObjectSceneCullingMask":
                    return player.GameObject?.sceneCullingMask.ToString();
                case "GameObjectTag":
                    return player.GameObject?.tag?.ToString();
                case "GameObjectTransformChildCount":
                    return player.GameObject?.transform?.childCount.ToString();
                case "GameObjectTransformEulerAngles":
                    return player.GameObject?.transform?.eulerAngles.ToString();
                case "GameObjectTransformForward":
                    return player.GameObject?.transform?.forward.ToString();
                case "GameObjectTransformGameObject":
                    return player.GameObject?.transform?.gameObject.ToString();
                case "GameObjectTransformHasChanged":
                    return player.GameObject?.transform?.hasChanged.ToString();
                case "GameObjectTransformHideFlags":
                    return player.GameObject?.transform?.hideFlags.ToString();
                case "GameObjectTransformHierarchyCapacity":
                    return player.GameObject?.transform?.hierarchyCapacity.ToString();
                case "GameObjectTransformHierarchyCount":
                    return player.GameObject?.transform?.hierarchyCount.ToString();
                case "GameObjectTransformLocalEulerAngles":
                    return player.GameObject?.transform?.localEulerAngles.ToString();
                case "GameObjectTransformLocalPosition":
                    return player.GameObject?.transform?.localPosition.ToString();
                case "GameObjectTransformLocalRotation":
                    return player.GameObject?.transform?.localRotation.ToString();
                case "GameObjectTransformLocalScale":
                    return player.GameObject?.transform?.localScale.ToString();
                case "GameObjectWorldToLocalMatrixDecomposeProjectionBottom":
                    return player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.bottom.ToString();
                case "GameObjectWorldToLocalMatrixDecomposeProjectionLeft":
                    return player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.left.ToString();
                case "GameObjectWorldToLocalMatrixDecomposeProjectionRight":
                    return player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.right.ToString();
                case "GameObjectWorldToLocalMatrixDecomposeProjectionTop":
                    return player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.top.ToString();
                case "GameObjectWorldToLocalMatrixDecomposeProjectionZFar":
                    return player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.zFar.ToString();
                case "GameObjectWorldToLocalMatrixDecomposeProjectionZNear":
                    return player.GameObject?.transform?.localToWorldMatrix.decomposeProjection.zNear.ToString();
                case "Group":
                    return player.Group?.ToString();
                case "GroupName":
                    return player.GroupName?.ToString();
                case "HasCustomName":
                    return player.HasCustomName.ToString();
                case "HasFlashlightModuleEnabled":
                    return player.HasFlashlightModuleEnabled.ToString();
                case "HasHint":
                    return player.HasHint.ToString();
                case "HasReservedSlot":
                    return player.HasReservedSlot.ToString();
                case "Health":
                    return player.Health.ToString();
                case "HintDisplay":
                    return player.HintDisplay.ToString();
                case "HumeShield":
                    return player.HumeShield.ToString();
                case "HumeShieldStat":
                    return player.HumeShieldStat?.ToString();
                case "Id":
                    return player.Id.ToString();
                case "InfoArea":
                    return player.InfoArea.ToString();
                case "InfoViewRange":
                    return player.InfoViewRange.ToString();
                case "Inventory":
                    return player.Inventory?.ToString();
                case "IPAddress":
                    return player.IPAddress?.ToString();
                case "IsAimingDownWeapon":
                    return player.IsAimingDownWeapon.ToString();
                case "IsAlive":
                    return player.IsAlive.ToString();
                case "IsBypassModeEnabled":
                    return player.IsBypassModeEnabled.ToString();
                case "IsCHI":
                    return player.IsCHI.ToString();
                case "IsConnected":
                    return player.IsConnected.ToString();
                case "IsCuffed":
                    return player.IsCuffed.ToString();
                case "IsDead":
                    return player.IsDead.ToString();
                case "IsFriendlyFireEnabled":
                    return player.IsFriendlyFireEnabled.ToString();
                case "IsGlobalModerator":
                    return player.IsGlobalModerator.ToString();
                case "IsGlobalMuted":
                    return player.IsGlobalMuted.ToString();
                case "IsGodModeEnabled":
                    return player.IsGodModeEnabled.ToString();
                case "IsHost":
                    return player.IsHost.ToString();
                case "IsHuman":
                    return player.IsHuman.ToString();
                case "IsInPocketDimension":
                    return player.IsInPocketDimension.ToString();
                case "IsIntercomMuted":
                    return player.IsIntercomMuted.ToString();
                case "IsInventoryEmpty":
                    return player.IsInventoryEmpty.ToString();
                case "IsInventoryFull":
                    return player.IsInventoryFull.ToString();
                case "IsJumping":
                    return player.IsJumping.ToString();
                case "IsMuted":
                    return player.IsMuted.ToString();
                case "IsNoclipPermitted":
                    return player.IsNoclipPermitted.ToString();
                case "IsNorthwoodStaff":
                    return player.IsNorthwoodStaff.ToString();
                case "IsNPC":
                    return player.IsNPC.ToString();
                case "IsNTF":
                    return player.IsNTF.ToString();
                case "IsOverwatchEnabled":
                    return player.IsOverwatchEnabled.ToString();
                case "IsReloading":
                    return player.IsReloading.ToString();
                case "IsScp":
                    return player.IsScp.ToString();
                case "IsSpawnProtected":
                    return player.IsSpawnProtected.ToString();
                case "IsSpeaking":
                    return player.IsSpeaking.ToString();
                case "IsStaffBypassEnabled":
                    return player.IsStaffBypassEnabled.ToString();
                case "IsTransmitting":
                    return player.IsTransmitting.ToString();
                case "IsTutorial":
                    return player.IsTutorial.ToString();
                case "IsUsingStamina":
                    return player.IsUsingStamina.ToString();
                case "IsVerified":
                    return player.IsVerified.ToString();
                case "IsWhitelisted":
                    return player.IsWhitelisted.ToString();
                case "Items":
                    return player.Items?.ToString();
                case "KickPower":
                    return player.KickPower.ToString();
                case "LeadingTeam":
                    return player.LeadingTeam.ToString();
                case "Lift":
                    return player.Lift?.ToString();
                case "MaxArtificialHealth":
                    return player.MaxArtificialHealth.ToString();
                case "MaxHealth":
                    return player.MaxHealth.ToString();
                case "NetId":
                    return player.NetId.ToString();
                case "NetworkIdentity":
                    return player.NetworkIdentity?.ToString();
                case "Nickname":
                    return player.Nickname?.ToString();
                case "Ping":
                    return player.Ping.ToString();
                case "Position":
                    return player.Position.ToString();
                case "Preferences":
                    return player.Preferences?.ToString();
                case "RadioPlayback":
                    return player.RadioPlayback?.ToString();
                case "RankColor":
                    return player.RankColor?.ToString();
                case "RankName":
                    return player.RankName?.ToString();
                case "RawUserId":
                    return player.RawUserId?.ToString();
                case "ReferenceHubAuthority":
                    return player.ReferenceHub?.authority.ToString();
                case "ReferenceHubComponentIndex":
                    return player.ReferenceHub?.ComponentIndex.ToString();
                case "ReferenceHubConnectionToClient":
                    return player.ReferenceHub?.connectionToClient?.ToString();
                case "ReferenceHubConnectionToServer":
                    return player.ReferenceHub?.connectionToServer?.ToString();
                case "ReferenceHubEnabled":
                    return player.ReferenceHub?.enabled.ToString();
                case "ReferenceHubHasAuthority":
                    return player.ReferenceHub?.hasAuthority.ToString();
                case "ReferenceHubHideFlags":
                    return player.ReferenceHub?.hideFlags.ToString();
                case "ReferenceHubIsActiveAndEnabled":
                    return player.ReferenceHub?.isActiveAndEnabled.ToString();
                case "ReferenceHubIsClient":
                    return player.ReferenceHub?.isClient.ToString();
                case "ReferenceHubIsClientOnly":
                    return player.ReferenceHub?.isClientOnly.ToString();
                case "ReferenceHubIsHost":
                    return player.ReferenceHub?.IsHost.ToString();
                case "ReferenceHubIsLocalPlayer":
                    return player.ReferenceHub?.isLocalPlayer.ToString();
                case "ReferenceHubIsOwned":
                    return player.ReferenceHub?.isOwned.ToString();
                case "ReferenceHubIsServer":
                    return player.ReferenceHub?.isServer.ToString();
                case "ReferenceHubIsServerOnly":
                    return player.ReferenceHub?.isServerOnly.ToString();
                case "ReferenceHubMode":
                    return player.ReferenceHub?.Mode.ToString();
                case "ReferenceHubName":
                    return player.ReferenceHub?.name?.ToString();
                case "ReferenceHubNetId":
                    return player.ReferenceHub?.netId.ToString();
                case "ReferenceHubNetIdentity":
                    return player.ReferenceHub?.netIdentity?.ToString();
                case "ReferenceHubNetworkPlayerId":
                    return player.ReferenceHub?.Network_playerId.ToString();
                case "ReferenceHubPlayerId":
                    return player.ReferenceHub?.PlayerId.ToString();
                case "ReferenceHubTag":
                    return player.ReferenceHub?.tag?.ToString();
                case "ReferenceHubTransform":
                    return player.ReferenceHub?.transform?.ToString();
                case "ReferenceHubUseGUILayout":
                    return player.ReferenceHub?.useGUILayout.ToString();
                case "RelativePosition":
                    return player.RelativePosition.ToString();
                case "RemoteAdminAccess":
                    return player.RemoteAdminAccess.ToString();
                case "RemoteAdminPermissions":
                    return player.RemoteAdminPermissions.ToString();
                case "Role":
                    return player.Role?.ToString();
                case "RoleManager":
                    return player.RoleManager?.ToString();
                case "Rotation":
                    return player.Rotation.ToString();
                case "Scale":
                    return player.Scale.ToString();
                case "ScpPreferences":
                    return player.ScpPreferences.ToString();
                case "Sender":
                    return player.Sender?.ToString();
                case "SessionVariables":
                    return player.SessionVariables?.ToString();
                case "Stamina":
                    return player.Stamina.ToString();
                case "StaminaStat":
                    return player.StaminaStat?.ToString();
                case "TransformChildCount":
                    return player.Transform?.childCount.ToString();
                case "TransformEulerAngles":
                    return player.Transform?.eulerAngles.ToString();
                case "TransformForward":
                    return player.Transform?.forward.ToString();
                case "TransformGameObject":
                    return player.Transform?.gameObject?.ToString();
                case "TransformHasChanged":
                    return player.Transform?.hasChanged.ToString();
                case "TransformHideFlags":
                    return player.Transform?.hideFlags.ToString();
                case "TransformHierarchyCapacity":
                    return player.Transform?.hierarchyCapacity.ToString();
                case "TransformHierarchyCount":
                    return player.Transform?.hierarchyCount.ToString();
                case "TransformLocalEulerAngles":
                    return player.Transform?.localEulerAngles.ToString();
                case "TransformLocalPosition":
                    return player.Transform?.localPosition.ToString();
                case "TransformLocalRotation":
                    return player.Transform?.localRotation.ToString();
                case "TransformLocalScale":
                    return player.Transform?.localScale.ToString();
                case "TransformName":
                    return player.Transform?.name?.ToString();
                case "TransformRight":
                    return player.Transform?.right.ToString();
                case "UniqueRole":
                    return player.UniqueRole?.ToString();
                case "UnitId":
                    return player.UnitId.ToString();
                case "UnitName":
                    return player.UnitName?.ToString();
                case "UserId":
                    return player.UserId?.ToString();
                case "Velocity":
                    return player.Velocity.ToString();
                case "VoiceChannel":
                    return player.VoiceChannel.ToString();
                case "VoiceChatMuteFlags":
                    return player.VoiceChatMuteFlags.ToString();
                case "VoiceColor":
                    return player.VoiceColor.ToString();
                case "VoiceModule":
                    return player.VoiceModule?.ToString();
                case "Zone":
                    return player.Zone.ToString();
                default:
                    return "Недоступно";
            }
        }
    }
}

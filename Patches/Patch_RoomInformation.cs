using HarmonyLib;
using Il2Cpp;
using Il2CppPlayer.Lobby;
using Il2CppRoom;

namespace DDSS_LobbyGuard.Patches
{
    [HarmonyPatch]
    internal class Patch_RoomInformation
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(RoomInformation), nameof(RoomInformation.Update))]
        private static bool Update_Prefix(RoomInformation __instance)
        {
            // Get Trigger
            if ((__instance.roomTrigger == null)
                || __instance.roomTrigger.WasCollected)
            {
                // Validate Local Player
                LobbyPlayer localPlayer = LobbyManager.instance.GetLocalPlayer();
                if ((localPlayer == null)
                    || localPlayer.WasCollected
                    || (localPlayer.NetworkplayerController == null)
                    || localPlayer.NetworkplayerController.WasCollected)
                    return false;

                // Get Trigger from Player Controller
                __instance.roomTrigger = localPlayer.NetworkplayerController.GetComponent<RoomTrigger>();
            }

            // Validate Trigger
            if ((__instance.roomTrigger == null)
                || __instance.roomTrigger.WasCollected
                || (__instance.roomTrigger.currentRoom == null)
                || __instance.roomTrigger.currentRoom.WasCollected)
                return false;

            // Apply Room Name
            if ((LocalizationManager.instance != null)
                && !LocalizationManager.instance.WasCollected)
                __instance.roomName.text = LocalizationManager.instance.GetLocalizedValue(__instance.roomTrigger.currentRoom.roomName);
            else
                __instance.roomName.text = __instance.roomTrigger.currentRoom.roomName;

            // Prevent Original
            return false;
        }

    }
}

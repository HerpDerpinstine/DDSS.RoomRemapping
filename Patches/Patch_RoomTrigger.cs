using HarmonyLib;
using Il2CppRoom;
using UnityEngine;

namespace DDSS_LobbyGuard.Patches
{
    [HarmonyPatch]
    internal class Patch_RoomTrigger
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(RoomTrigger), nameof(RoomTrigger.OnTriggerEnter))]
        private static bool OnTriggerEnter_Prefix(RoomTrigger __instance, Collider __0)
        {
            // Validate RoomController
            RoomController component = __0.GetComponent<RoomController>();
            if ((component != null)
                && !component.WasCollected)
            {
                // Set Current Room
                __instance.currentRoom = component;

                // Add Room Name
                if (!__instance.roomNames.Contains(component.roomName))
                    __instance.roomNames.Add(component.roomName);
            }

            // Prevent Original
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(RoomTrigger), nameof(RoomTrigger.OnTriggerExit))]
        private static bool OnTriggerExit_Prefix()
        {
            // Prevent Original
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(RoomTrigger), nameof(RoomTrigger.UpdateCurrentRoom))]
        private static bool UpdateCurrentRoom_Prefix()
        {
            // Prevent Original
            return false;
        }

    }
}

using HarmonyLib;
using Il2Cpp;
using Il2CppRoom;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DDSS_RoomRemapping.Patches
{
    [HarmonyPatch]
    internal class Patch_MapCreator
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MapCreator), nameof(MapCreator.CreateRoom))]
        private static bool CreateRoom_Prefix(MapCreator __instance, RoomController __0)
        {
            // Validate Collider
            BoxCollider component = __0.GetComponent<BoxCollider>();
            if ((component == null)
                || component.WasCollected)
                return false;

            // Create Room
            int num = ((__0.transform.position.y < -5f) ? 0 : 1);
            GameObject gameObject = GameObject.Instantiate(__instance.roomPrefab, __instance.mapParents[num]);

            // Apply Room Position, Size, and Color
            RectTransform component2 = gameObject.GetComponent<RectTransform>();
            if ((component2 != null)
                && !component2.WasCollected)
            {
                // Get Room Information
                Vector3 center = component.center;
                Vector3 size = component.size;
                Vector2 vector = __instance.ProjectTo2D(__0.transform.TransformPoint(center));
                Vector2 vector2 = new Vector2(size.x, size.z) * __instance.scale;
                Color color = new Color(__0.color.r, __0.color.g, __0.color.b, 0.04f);

                // Apply Position and Size
                component2.anchoredPosition = vector;
                component2.sizeDelta = vector2;

                // Apply Room Color to Image
                Image img = component2.GetComponent<Image>();
                if ((img != null)
                    && !img.WasCollected)
                    img.color = color;
            }

            // Apply Room Name
            TextMeshProUGUI component3 = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            if ((component3 != null)
                && !component3.WasCollected)
            {
                // Check if Name should be shown
                if (__0.showInMap)
                    component3.text = __0.roomName;
                else
                    component3.text = "";
            }

            // Prevent Original
            return false;
        }
    }
}
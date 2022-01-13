using UnityEngine;
using HarmonyLib;

namespace Mole_Miner
{
    public class Mole_Miner
    {
        [HarmonyPatch(typeof(AutoMinerConfig))]
        [HarmonyPatch(nameof(AutoMinerConfig.CreateBuildingDef))]

        public static class AutoMinerConfig_CreateBuildingDef_Patch
        {
            public static void Postfix(ref BuildingDef __result)
            {
                __result.Entombable = false;
            }
        }
        [HarmonyPatch(typeof(AutoMinerConfig))]
        [HarmonyPatch(nameof(AutoMinerConfig.DoPostConfigureComplete))]
        public class AutoMinerConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(ref GameObject go)
            {
                go.GetComponent<KPrefabID>().AddTag(GameTags.Bunker, false);
            }
        }
    }
}

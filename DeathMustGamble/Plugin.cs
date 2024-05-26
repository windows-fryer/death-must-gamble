using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.Mono;

using HarmonyLib;
using Death.Run.Core;

namespace DeathMustGamble
{
    [BepInPlugin("84b561e0-aac0-4dbe-b839-ba8fdf52cd35", "Death Must Gamble", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake() {
            var harmonyInstance = new Harmony("DeathMustGamble");

            harmonyInstance.PatchAll(typeof(FudgeStatPatch));

            Logger.LogInfo("Patched FudgeStats");
        }
    }

    internal class FudgeStatPatch
    {
        [HarmonyPatch(typeof(FudgeStats), "HadStat")]
        [HarmonyPrefix]
        private static bool HadStatPatch(FudgeStatId stat, ref bool __result)
        {
            if (stat == FudgeStatId.Revivals)
                return true;

            __result = true;

            return false;
        }

        [HarmonyPatch(typeof(FudgeStats), "Get")]
        [HarmonyPrefix]
        private static bool GetPatch(FudgeStatId stat, ref int __result)
        {
            if (stat == FudgeStatId.Revivals)
                return true;

            __result = 99;

            return false;
        }

        [HarmonyPatch(typeof(FudgeStats), "Use")]
        [HarmonyPrefix]
        private static bool UsePatch(FudgeStatId stat)
        {
            if (stat == FudgeStatId.Revivals)
                return true;

            return false;
        }

        [HarmonyPatch(typeof(FudgeStats), "AddMax")]
        [HarmonyPrefix]
        private static bool AddMaxPatch(FudgeStatId stat)
        {
            if (stat == FudgeStatId.Revivals)
                return true;

            return false;
        }

        [HarmonyPatch(typeof(FudgeStats), "GetMax")]
        [HarmonyPrefix]
        private static bool GetMax(FudgeStatId stat, ref int __result)
        {
            if (stat == FudgeStatId.Revivals)
                return true;

            __result = 99;

            return false;
        }
    }
}

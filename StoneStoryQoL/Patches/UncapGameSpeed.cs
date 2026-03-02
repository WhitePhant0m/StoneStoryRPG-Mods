using HarmonyLib;
using System;
using UnityEngine;

namespace StoneStoryQoL.Patches;

internal class UncapGameSpeed {
    [HarmonyPatch(typeof(SlowMotion), nameof(SlowMotion.Update))]
    [HarmonyPrefix]
    private static bool Update(SlowMotion __instance) {
        __instance.timeScale += __instance.recoveryVelocity;
        __instance.timeScale =  Mathf.Clamp(__instance.timeScale, __instance.minimumScale, float.MaxValue);
        return false;
    }

    [HarmonyPatch(typeof(SlowMotion), nameof(SlowMotion.Add))]
    [HarmonyPrefix]
    private static bool Add(SlowMotion __instance, float amount) {
        __instance.timeScale -= amount;
        return false;
    }
}
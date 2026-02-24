using HarmonyLib;
using System;
using System.Reflection;

namespace StoneStoryQoL.Patches;

[HarmonyPatch(typeof(TriskelionScreen))]
public static class FastFuse
{
    [HarmonyPatch(nameof(TriskelionScreen.UpdateTic))]
    [HarmonyPrefix]
    private static void UpdateTic(TriskelionScreen __instance)
    {
        __instance.elapsedTriskelionStateTics += 59;
    }
}
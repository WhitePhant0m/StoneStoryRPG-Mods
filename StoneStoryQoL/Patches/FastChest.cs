using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoneStoryQoL.Patches;

[HarmonyPatch(typeof(OpenTreasureDialog))]
public static class FastChest
{
    [HarmonyPatch(nameof(OpenTreasureDialog.UpdateTic))]
    [HarmonyPrefix]
    private static void UpdateTic(OpenTreasureDialog __instance)
    {
        if (__instance.currentIsLostItem)
            __instance.treasureStateElapsedTics += 9;
        else
            __instance.treasureStateElapsedTics += 19;
        __instance.autoSkip = true;
    }
}
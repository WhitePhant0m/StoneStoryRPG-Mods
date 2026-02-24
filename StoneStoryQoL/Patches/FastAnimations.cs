using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace StoneStoryQoL.Patches;

public static class FastAnimations
{
    [HarmonyPatch(typeof(FissureStoneScreen), nameof(FissureStoneScreen.UpdateTic))]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);

        for (int i = 0; i < codes.Count; i++)
        {
            // Check if the current instruction is loading 'elapsedFissureStateTics' onto the stack
            if (i + 2 < codes.Count &&
                codes[i].opcode == OpCodes.Ldarg_0 &&
                codes[i + 1].opcode == OpCodes.Ldfld && codes[i + 1].operand.ToString().Contains("elapsedFissureStateTics") &&
                codes[i + 2].opcode == OpCodes.Ldc_I4_S)
            {
                // Change the value checked against 'elapsedFissureStateTics'
                // Replace the value (originally 30) with a lower value, e.g., 10
                codes[i + 2] = new CodeInstruction(OpCodes.Ldc_I4_S, 1);
            }

            // Check for the sequence related to 'this.automationEnabled'
            if (i + 3 < codes.Count &&
                codes[i].opcode == OpCodes.Ldarg_0 &&
                codes[i + 1].opcode == OpCodes.Call && codes[i + 1].operand.ToString().Contains("get_automationEnabled") &&
                codes[i + 2].opcode == OpCodes.Brfalse_S)
            {
                // Next, check for the loading of 'elapsedFissureStateTics' and its comparison to '11'
                if (codes[i + 3].opcode == OpCodes.Ldarg_0 &&
                    codes[i + 4].opcode == OpCodes.Ldfld && codes[i + 4].operand.ToString().Contains("elapsedFissureStateTics") &&
                    codes[i + 5].opcode == OpCodes.Ldc_I4_S)
                {
                    // Replace the value (originally 11) with your desired value, e.g., 5
                    codes[i + 5] = new CodeInstruction(OpCodes.Ldc_I4_S, 1);
                }
            }
        }
        return codes.AsEnumerable();
    }

    [HarmonyPatch(typeof(OpenTreasureDialog), nameof(OpenTreasureDialog.UpdateTic))]
    [HarmonyPrefix]
    private static void UpdateTic(OpenTreasureDialog __instance)
    {
        if (__instance.currentIsLostItem)
            __instance.treasureStateElapsedTics += 9;
        else
            __instance.treasureStateElapsedTics += 19;
        __instance.autoSkip = true;
    }

    [HarmonyPatch(typeof(TriskelionScreen), nameof(TriskelionScreen.UpdateTic))]
    [HarmonyPrefix]
    private static void UpdateTic(TriskelionScreen __instance)
    {
        __instance.elapsedTriskelionStateTics += 59;
    }
}
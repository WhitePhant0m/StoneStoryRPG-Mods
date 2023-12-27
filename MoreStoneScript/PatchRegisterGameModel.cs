using HarmonyLib;
using Stonescript;
using System.Collections.Generic;

namespace MoreStonescript;

[HarmonyPatch(typeof(StonescriptGlobals), nameof(StonescriptGlobals.RegisterGameModel))]
internal class PatchRegisterGameModel
{
    [HarmonyPrefix]
    private static void Prefix(Machine machine, AStonescriptGameModel gameModel)
    {
        machine.RegisterFunction("restart", RestartQuest);
    }

    public static object RestartQuest(List<object> parameters, InvocationContext ctx)
    {
        var gameState = GameStates.Singleton;
        if (gameState.GetTotalTime() >= 120)
        {
            Data.Quest quest = ((gameState.parentQuest != null) ? gameState.parentQuest : gameState.level.QuestData);
            gameState.StartQuest(quest, true, true);
            return true;
        }
        return false;
    }

    //[HarmonyPostfix]
    //static void Postfix()
    //{
    //    // Code executed after the original method
    //}
}
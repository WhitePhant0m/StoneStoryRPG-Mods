//using HarmonyLib;
//using Stonescript;
//using Stonescript.Runtime;
//using System.Collections.Generic;

//namespace MoreStonescript;

//[HarmonyPatch(typeof(StonescriptGlobals))]
//internal class PatchStoneScriptGlobals
//{
//    private PatchItemScreen itemScreen;

//    [HarmonyPostfix]
//    public bool Command_ChestOpen(List<StonescriptResult> results, InvocationContext ctx)
//    {
//        if (Inventory.Singleton.GetTreasures().Count == 0 || GameStates.Singleton.CurrentState == GameStates.State.PlayItemScreen)
//        {
//            return false;
//        }
//        GameStates.Singleton.SetState(GameStates.State.PlayItemScreen);
//        TreasureItem lastTreasure = Inventory.Singleton.GetLastTreasure();
//        if (lastTreasure != null)
//        {
//            //itemScreen.OpenTreasure(lastTreasure, true);
//            return true;
//        }
//        return false;
//    }
//}
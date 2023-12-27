//using HarmonyLib;

//namespace MoreStonescript;

//[HarmonyPatch(typeof(ItemScreen))]
//internal class PatchItemScreen
//{
//    [HarmonyPostfix]
//    public static void OpenTreasure(TreasureItem treasureItem, bool skip)
//    {
//        SetState(ItemScreen.State.OpeningTreasure);
//        openTreasureDialog.Setup(treasureItem, skip);
//        openTreasureDialog.Show();
//        AnalyticsMacros.OpenTreasure(treasureItem);
//    }
//}
//using HarmonyLib;
//using Stonescript;
//using System.Collections.Generic;

//namespace MoreStonescript;

//[HarmonyPatch(typeof(StonescriptGlobals), nameof(StonescriptGlobals.RegisterGlobals))]
//internal class PatchRegisterGlobals
//{
//    [HarmonyPrefix]
//    private static void Prefix(Machine machine)
//    {
//        //machine.RegisterFunction("chest.Open", new NativeFunction.Callback(PatchStoneScriptGlobals.Command_ChestOpen), null);
//    }

//    [HarmonyPostfix]
//    private static void Postfix()
//    {
//        // Code executed after the original method
//    }
//}
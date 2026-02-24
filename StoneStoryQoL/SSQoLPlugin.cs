using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using StoneStoryQoL.Patches;

namespace StoneStoryQoL;

[BepInPlugin(MyGUID, PluginName, VersionString)]
public class SSQoLPlugin : BaseUnityPlugin
{
    public const string MyGUID = "com.wp.StoneStoryQoL";
    public const string PluginName = "StoneStoryQoL";
    public const string VersionString = "1.2.0";

    private static readonly Harmony Harmony = new(MyGUID);
    public static ManualLogSource Log = new(PluginName);

    private void Awake()
    {
        Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");

        SSQoLConfig.Start();

        try
        {
            Harmony.PatchAll(typeof(MoreStoneScript));
            Harmony.PatchAll(typeof(TickTime));

            if (SSQoLConfig.Fast_Break.Value)
                Harmony.PatchAll(typeof(FastBreak));
            if (SSQoLConfig.Fast_Fuse.Value)
                Harmony.PatchAll(typeof(FastFuse));
            if (SSQoLConfig.Fast_Chest.Value)
                Harmony.PatchAll(typeof(FastChest));

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
        }
        catch (System.Exception e)
        {
            Logger.LogError($"PluginName: {PluginName}, VersionString: {VersionString} failed to patch something." +
                $"\nPlease message @white.phantom on discord with the error." +
                "\n" + e);
            throw;
        }
        Log = Logger;
    }
}
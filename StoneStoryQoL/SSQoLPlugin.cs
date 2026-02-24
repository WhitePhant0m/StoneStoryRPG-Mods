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
            if (SSQoLConfig.FastAnimations.Value)
                Harmony.PatchAll(typeof(FastAnimations));
            if (SSQoLConfig.MoreStoneScript.Value)
                Harmony.PatchAll(typeof(MoreStoneScript));
            if (SSQoLConfig.UncapGameSpeed.Value)
                Harmony.PatchAll(typeof(UncapGameSpeed));

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
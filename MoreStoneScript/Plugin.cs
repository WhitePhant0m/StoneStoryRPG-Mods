using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace MoreStonescript;

[BepInPlugin(MyGUID, PluginName, VersionString)]
public class Plugin : BaseUnityPlugin
{
    private const string MyGUID = "com.wp.MoreStonescript";
    private const string PluginName = "MoreStonescript";
    private const string VersionString = "1.0.0";

    private static readonly Harmony Harmony = new Harmony(MyGUID);
    public static ManualLogSource Log = new ManualLogSource(PluginName);

    private void Awake()
    {
        Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
        Harmony.PatchAll();
        Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
        Log = Logger;
    }
}
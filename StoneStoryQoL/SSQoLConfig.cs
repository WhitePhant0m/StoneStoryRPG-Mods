using BepInEx;
using BepInEx.Configuration;

namespace StoneStoryQoL;

public class SSQoLConfig {
    private static ConfigFile ConfigFile = new(Paths.ConfigPath + $"\\{SSQoLPlugin.MyGUID}.cfg", true);

    private const string catGeneral = "General";

    public static ConfigEntry<bool> FastAnimations;
    public static ConfigEntry<bool> MoreStoneScript;
    public static ConfigEntry<bool> UncapGameSpeed;

    public static void Start() {
        InitConfig();
    }

    private static void InitConfig() {
        FastAnimations = ConfigFile.Bind(catGeneral, "FastAnimations", true,
            "Speed up animations for fissure stone, triskellion stone, and opening chests." +
            "\nNOTE: This only speeds up the animation. Later I'll try to see if I can somehow make fusing happen in bulk.");
        MoreStoneScript = ConfigFile.Bind(catGeneral, "MoreStoneScript", true,
            "Adds more functions and variables to Stonescript.");
        UncapGameSpeed = ConfigFile.Bind(catGeneral, "UncapGameSpeed", true, "Removes the cap on game speed.");
    }
}
using BepInEx;
using BepInEx.Configuration;

namespace StoneStoryQoL;

public class SSQoLConfig
{
    public static ConfigFile ConfigFile = new(Paths.ConfigPath + $"\\{SSQoLPlugin.MyGUID}.cfg", true);

    private const string catGeneral = "General";

    public static ConfigEntry<bool> Fast_Break;
    public static ConfigEntry<bool> Fast_Fuse;
    public static ConfigEntry<bool> Fast_Chest;

    public static void Start()
    {
        InitConfig();
    }

    public static void InitConfig()
    {
        Fast_Break = ConfigFile.Bind(catGeneral, "FastBreak", true, "Fissure stone breaks items apart really fast.");
        Fast_Fuse = ConfigFile.Bind(catGeneral, "FastFuse", true, "Triskellion stone fuses enchantments really fast." +
            "\nNOTE: If only using level 1 enchants, It can still take a long time to fuse." +
            "\nThis only speeds up the animation. Later I'll try to see if I can somehow make fusing happen in bulk.");
        Fast_Chest = ConfigFile.Bind(catGeneral, "FastChest", true, "Open chests much faster.");
    }
}
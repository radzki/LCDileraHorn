using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using YourThunderstoreTeam.patch;
//using YourThunderstoreTeam.service;

namespace YourThunderstoreTeam;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    public static string location = ((BaseUnityPlugin) Instance).Info.Location.TrimEnd("DileraHorn.dll".ToCharArray());

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);


    public Plugin()
    {
        Instance = this;
    }

    private void Awake()
    {

        Log.LogInfo($"Applying patches...");
        ApplyPluginPatch();
        Log.LogInfo($"Patches applied");
    }

    /// <summary>
    /// Applies the patch to the game.
    /// </summary>
    private void ApplyPluginPatch()
    {
        _harmony.PatchAll(typeof(NoisemakerPropAirhornPatch));
    }
}

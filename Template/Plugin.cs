using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using radzki.DileraHornMod.patch;
using System.IO;
using UnityEngine;

namespace radzki.DileraHornMod;


[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    private static AssetBundle _bundle;


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

    public AssetBundle GetBundle()
    {
        string assets_dir = Path.Combine(Path.GetDirectoryName(Plugin.Instance.Info.Location), "dilerahorn");

        _bundle = AssetBundle.LoadFromFile(assets_dir);

        return _bundle;
    }
}

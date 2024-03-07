using BepInEx;
using HarmonyLib;

namespace YourThunderstoreTeam.patch;

/// <summary>
/// Patch to modify the behavior of the ship lights.
/// </summary>
[HarmonyPatch(typeof(NoisemakerProp))]
public class NoisemakerPropAirhornPatch
{
    /// <summary>
    /// Method called when instantiating NoisemakerProp.
    ///
    /// Check the link below for more information about Harmony patches.
    /// Class patches: https://github.com/BepInEx/HarmonyX/wiki/Class-patches
    /// Patch parameters: https://github.com/BepInEx/HarmonyX/wiki/Patch-parameters
    /// </summary>
    /// <param name="__instance">Instance that called the method.</param>
    /// <param name="__args">Arguments passed to the method.</param>
    /// <returns>True if the original method should be called, false otherwise.</returns>
    [HarmonyPatch(nameof(NoisemakerProp.Start))]
    [HarmonyPostfix]
    private static void PatchAudioSource(ref NoisemakerProp __instance, object[] __args)
    {

        
        Plugin.Log.LogInfo("RADZKI: DileraHorn location: " +  Plugin.location);
        Plugin.Log.LogInfo("RADZKI: Patching Airhorn sound!");

        if (__instance.itemProperties.itemName != "Airhorn")
            return;

        Plugin.Log.LogInfo("RADZKI: Airhorn NoiseMaker was instantiated!");
    }
}

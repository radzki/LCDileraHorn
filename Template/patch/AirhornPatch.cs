using HarmonyLib;
using UnityEngine;

namespace radzki.DileraHornMod.patch;


/// <summary>
/// Patch to modify the behavior of the ship lights.
/// </summary>
[HarmonyPatch(typeof(NoisemakerProp))]
public class NoisemakerPropAirhornPatch
{

    private static AssetBundle _bundle = Plugin.Instance.GetBundle();
    private static AudioClip _sound = _bundle.LoadAsset<AudioClip>("buzina.wav");
    private static AudioClip _soundFar = _bundle.LoadAsset<AudioClip>("buzinaFar.wav");

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

        if (__instance.itemProperties.itemName != "Airhorn")
            return;

        __instance.noiseSFX[0] = _sound;
        __instance.noiseSFXFar[0] = _soundFar;

    }
}

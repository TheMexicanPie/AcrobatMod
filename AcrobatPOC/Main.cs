using HarmonyLib;
using System.Text;
using System.Reflection;
using UnityModManagerNet;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using AcrobatPOC.Feats;
using AcrobatPOC.Class;
using AcrobatPOC.Class.Features;
using AcrobatPOC.Class.Features.OpportunisticManipulations;

namespace AcrobatPOC;

public static class Main {
    internal static Harmony HarmonyInstance;
    internal static UnityModManager.ModEntry.ModLogger Log;

    public static bool Load(UnityModManager.ModEntry modEntry) {
        Log = modEntry.Logger;
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        try {
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        } catch {
            HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
            throw;
        }
        return true;
    }

    public static void OnGUI(UnityModManager.ModEntry modEntry) {

    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    public static class BlueprintsCaches_Patch {

        private static readonly LogWrapper FeatLogger = LogWrapper.Get("TestFeat");
        private static readonly LogWrapper ProgressionLogger = LogWrapper.Get("AcrobatProgression");
        private static readonly LogWrapper ClassLogger = LogWrapper.Get("AcrobatClass");
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        public static void Init_Postfix() {
            try {
                if (Initialized) {
                    Log.Log("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;

                Log.Log("Patching blueprints.");

                //TestFeat.Configure();
                ImprovedGrapple.Configure();
                GreaterGrapple.Configure();

                AcrobatProficiency.Configure();
                AcrobatBonusFeatSelectionLevel1.Configure();
                AcrobatBonusFeatSelectionLevel9.Configure();
                ManeuverMastery.Configure();

                SuccessGuarantee.Configure();
                OpportunisticManipulationSelection.Configure();
                DualManipulations.Configure();

                SpecialtyManeuverSelection.Configure();

                AcrobatProgression.Configure();
                AcrobatClass.Configure();
                
                // Insert your mod's patching methods here
                // Example
                // SuperAwesomeFeat.Configure()
            } catch (Exception e) {
                Log.Log(string.Concat("Failed to initialize.", e));
            }
        }
    }
}

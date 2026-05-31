using BlueprintCore.Blueprints.Configurators.Root.Fx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils.Types;
using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features.OpportunisticManipulations
{
    /*[HarmonyPatch(typeof(ActivatableAbility), "ActivatableAbilityGroup")]
    static class ActivatableAbility_GetActivatableAbilityGroup_Patch
    {

        
    
    }*/


    public static class OpportunisticManipulationSelection
    {
        private static readonly string FeatureName = "OpportunisticManipulationSelection";
        private static readonly string FeatureGuid = "C596DF10-04A8-48D2-85F4-D10041585D51";

        


        public static void Configure()
        {


            FeatureSelectionConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("OpportunisticManipulation.Name")
                .SetDescription("OpportunisticManipulation.Description")
                //.AddIncreaseActivatableAbilityGroupSize((ActivatableAbilityGroup)073)
                .SetIsClassFeature(true)
                .AddToAllFeatures
                ([
                    // Add Opportunistic Manipulations
                ])
                //.SetRanks(7)
                .Configure();


            
        }
    }
}

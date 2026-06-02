using MicroWrath.Extensions;
using BlueprintCore.Blueprints.Configurators.Root.Fx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils.Types;
using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        internal static readonly ExtraActivatableAbilityGroup OpportunisticManipulationAbilityGroup = new(01981041);

        internal partial class AddActivatableAbilityGroup : UnitFactComponentDelegate
        {
           
        }


        public static void Configure()
        {
            OMRepel.Configure();
            OMKnockOff.Configure();
            OMRestrain.Configure();
            OMDismantle.Configure();
            OMTumble.Configure();
            OMMisdirect.Configure();

            OMBefuddle.Configure();
            OMAstonish.Configure();
            OMStupefy.Configure();
            OMSpook.Configure();
            OMTerrify.Configure();


            FeatureSelectionConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("OpportunisticManipulation.Name")
                .SetDescription("OpportunisticManipulation.Description")
                //.AddIncreaseActivatableAbilityGroupSize((ActivatableAbilityGroup)073)
                .SetIsClassFeature(true)
                .AddToAllFeatures
                ([
                    "20B3961E-2E41-4E28-8D85-8D8DD5961E53", // Repel
                    "AB36EF3B-D7D3-4089-A7D7-74701077F997", // Knock Off
                    "0B96C20B-47B2-421A-8CDB-251953EE7DF3", // Restrain
                    "7145A58D-BA36-4009-AF36-09CD278FE79D", // Dismantle
                    "2C88C2E1-A272-496E-A407-29255488F631", // Tumble
                    "BFA02F63-1DEF-4E19-AD0D-41C36EFF18F5", // Misdirect

                    "BC522267-9C21-4D47-B085-9DF90536887D", // Befuddle
                    "B203288F-118C-451C-8416-3289260BC98A", // Astonish
                    "80F02A11-4464-4C3A-A326-B9ECCD097621", //Stupefy
                    "B47EDADB-478E-4F7E-8052-1FECFE987A77", // Spook
                    "770D50B1-47C5-4C8D-9B86-8E6EA7712506"  // Terrify
                    // Add Opportunistic Manipulations
                ])
                //.SetRanks(7)
                .Configure();


            
        }
    }
}

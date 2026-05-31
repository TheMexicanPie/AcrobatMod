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
    internal class OMRepel
    {
        private static readonly string FeatureName = "OpportunisticManipulationSelection";
        private static readonly string FeatureGuid = "";

        private static readonly string AbilityName = "OpportunisticManipulationSelection";
        private static readonly string AbilityGuid = "";

        public static void Configure()
        {
            AbilityConfigurator.New(AbilityName,AbilityGuid)
                
                .Configure();


        }
    }
}

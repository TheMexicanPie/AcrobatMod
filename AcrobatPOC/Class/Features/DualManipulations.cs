using AcrobatPOC.Class.Features.OpportunisticManipulations;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using MicroWrath.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features
{
    internal class DualManipulations
    {
        private static readonly string FeatureName = "DualManipulations";
        private static readonly string FeatureGuid = "3200B2EB-D577-4642-8057-B17D5BD7275B";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("DualManipulations.Name")
                .SetDescription("DualManipulations.Description")
                .AddIncreaseActivatableAbilityGroupSize(OpportunisticManipulationSelection.OpportunisticManipulationAbilityGroup)
                .Configure();

            
        }
    }
}

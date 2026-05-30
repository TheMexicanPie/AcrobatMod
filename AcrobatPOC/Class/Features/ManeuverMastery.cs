using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features
{
    public class ManeuverMastery
    {
        private static readonly string FeatureName = "Maneuver Mastery";
        private static readonly string FeatureGuid = "7C8B00CA-69D9-4F14-957B-1D9542A204DB";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("ManeuverMasteryFeature.Name")
                .SetDescription("ManeuverMasteryFeature.Description")
                .SetIsClassFeature(true)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.None, stat: Kingmaker.EntitySystem.Stats.StatType.AdditionalCMB, value: 1)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.None, stat: Kingmaker.EntitySystem.Stats.StatType.AdditionalCMD, value: 1)
                .SetRanks(5)
                .Configure();

        }
    }
}

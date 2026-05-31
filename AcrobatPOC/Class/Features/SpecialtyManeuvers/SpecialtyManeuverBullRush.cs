using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Features.SpecialtyManeuvers
{
    public class SpecialtyManeuverBullRush
    {
        private static readonly string FeatureName = "SpecialtyManeuverBullrush";
        private static readonly string FeatureGuid = "C40B53F1-51E8-40E3-88FA-2A7989C62DE7";

        public static void Configure() 
        {
            FeatureConfigurator.New(FeatureName, FeatureGuid)
                .SetDisplayName("SpecialtyManeuverBullRush.Name")
                .SetDescription("")
                .AddContextRankConfig
                (
                    ContextRankConfigs.ClassLevel(["08636672-3547-4DC5-AE9B-BAA8DCF4164B"], type : Kingmaker.Enums.AbilityRankType.Default)
                    .WithCustomProgression((4, 1), (8, 2), (12, 3), (16, 4), (17,5))
                )
                .AddCMBBonusForManeuver(maneuvers: [CombatManeuver.BullRush, CombatManeuver.AwesomeBlow], value: ContextValues.Rank())
                .SetRanks(1)
                .Configure();
        }
    }
}

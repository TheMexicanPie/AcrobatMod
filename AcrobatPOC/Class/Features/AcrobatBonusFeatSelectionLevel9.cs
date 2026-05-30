using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Class.Features
{
    public class AcrobatBonusFeatSelectionLevel9
    {
       
            private static readonly string FeatureName = "AcrobatBonusFeatSelectionLevel9";
            private static readonly string FeatureGuid = "568C3AE8-9EF4-4505-A6C9-82D3635736B7";

            public static void Configure()
            {
                var config = FeatureSelectionConfigurator.New(FeatureName, FeatureGuid)
                    .SetDisplayName("AcrobatBonusFeatSelection.Name")
                    .SetDescription("AcrobatBonusFeatSelection.Description")
                    .SetIsClassFeature(true)
                    .SetIgnorePrerequisites(true)
                    .AddToAllFeatures
                    ([
                        FeatureRefs.CoordinatedDefense.Reference.Get(),
                        FeatureRefs.CoordinatedManeuvers.Reference.Get(),
                        FeatureRefs.TandemTrip.Reference.Get(),
                        FeatureRefs.AgileManeuvers.Reference.Get(),
                        FeatureRefs.DefensiveCombatTraining.Reference.Get(),
                        FeatureRefs.ImprovedBullRush.Reference.Get(),
                        FeatureRefs.GreaterBullRush.Reference.Get(),
                        FeatureRefs.ImprovedDirtyTrick.Reference.Get(),
                        FeatureRefs.GreaterDirtyTrick.Reference.Get(),
                        FeatureRefs.ImprovedDisarm.Reference.Get(),
                        FeatureRefs.GreaterDisarm.Reference.Get(),
                        // add Grapple Feats
                        FeatureRefs.ImprovedSunder.Reference.Get(),
                        FeatureRefs.GreaterSunder.Reference.Get(),
                        FeatureRefs.ImprovedTrip.Reference.Get(),
                        FeatureRefs.GreaterTrip.Reference.Get(),
                        FeatureRefs.DisarmingStrike.Reference.Get(),
                        FeatureRefs.FurysFall.Reference.Get()
                    ])
                    .SetRanks(3);
                
                // Check for prerequisite feats before adding the next ones to the list.   

                config.Configure();

            }
        
    }
}

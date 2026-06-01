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
    public class AcrobatBonusFeatSelectionLevel1
    {
       
            private static readonly string FeatureName = "AcrobatBonusFeatSelectionLevel1";
            private static readonly string FeatureGuid = "A735C5B7-6328-4442-A7F2-8F32D00ED6F8";

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
                        //FeatureRefs.GreaterBullRush.Reference.Get(),
                        FeatureRefs.ImprovedDirtyTrick.Reference.Get(),
                        //FeatureRefs.GreaterDirtyTrick.Reference.Get(),
                        FeatureRefs.ImprovedDisarm.Reference.Get(),
                        //FeatureRefs.GreaterDisarm.Reference.Get(),
                        "34CF93AC-0C65-410B-9FDA-5B9C90D2148D", //Improved Grapple
                        // "0A250137-6ECA-49B8-939B-60843D96BA66", // Greater Grapple
                        FeatureRefs.ImprovedSunder.Reference.Get(),
                        //FeatureRefs.GreaterSunder.Reference.Get(),
                        FeatureRefs.ImprovedTrip.Reference.Get(),
                        //FeatureRefs.GreaterTrip.Reference.Get(),
                        //FeatureRefs.DisarmingStrike.Reference.Get(),
                        FeatureRefs.FurysFall.Reference.Get()
                    ])
                    //.SetRanks(3)
                    ;

            
                
                // Check for prerequisite feats before adding the next ones to the list.   

                config.Configure();

            }
        
    }
}

using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcrobatPOC.Feats
{
    public class TestFeat
    {
        private static readonly string FeatName = "TestFeat";
        private static readonly string FeatGuid = "4D9D8D25-0AAF-4810-840A-33A9C28A3CEE";

        public static void Configure() 
        {
            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                .SetDisplayName("TestFeat.Name")
                .SetDescription("TestFeat.Description")
                .AddFeatureTagsComponent(featureTags: Kingmaker.Blueprints.Classes.Selection.FeatureTag.Defense)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.None, stat: Kingmaker.EntitySystem.Stats.StatType.HitPoints, value: 69)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.None, stat: Kingmaker.EntitySystem.Stats.StatType.AC, value: 69)
                .AddContextRankConfig
                (
                    ContextRankConfigs.BaseStat(Kingmaker.EntitySystem.Stats.StatType.Intelligence)
                    .WithCustomProgression((9, 67), (15, 69), (16,42))
                )
                .AddContextStatBonus(stat: Kingmaker.EntitySystem.Stats.StatType.SaveWill, ContextValues.Rank())
                .Configure();
            //FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection).AddToAllFeatures(FeatName).Configure();

        }
    }
}
